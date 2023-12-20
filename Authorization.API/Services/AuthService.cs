using Authorization.API.Services.Interfaces;
using Authorization.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authorization.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ILogger<AuthService> logger)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<(int, string)> Registeration(RegistrationModel model, string role)
        {
            try
            {
                var userExists = await userManager.FindByNameAsync(model.Username);
                if (userExists != null)
                    return (0, "User already exists");

                ApplicationUser user = new ApplicationUser()
                {
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Username,
                    Name = model.Name
                };
                var createUserResult = await userManager.CreateAsync(user, model.Password);
                if (!createUserResult.Succeeded)
                    return (0, "User creation failed! Please check user details and try again.");

                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));

                if (await roleManager.RoleExistsAsync(UserRoles.User))
                    await userManager.AddToRoleAsync(user, role);

                _logger.LogInformation($"---CUSTOM LOG--- new user registered: {model.Username}, {DateTime.Now}");

                return (1, "User created successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"---CUSTOM LOG--- ERROR during registration: {ex.Message}");
                throw;
            }
        }

        public async Task<(int, string)> Login(LoginModel model)
        {
            try
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if (user == null)
                    return (0, "Invalid username");
                if (!await userManager.CheckPasswordAsync(user, model.Password))
                    return (0, "Invalid password");

                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.UserName),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                string token = GenerateToken(authClaims);

                _logger.LogInformation($"---CUSTOM LOG--- user logined: {model.Username}, {DateTime.Now}");

                return (1, token);
            }
            catch (Exception ex)
            {
                _logger.LogError($"---CUSTOM LOG--- ERROR during login: {ex.Message}");
                throw;
            }
        }


        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
