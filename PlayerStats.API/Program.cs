using Microsoft.EntityFrameworkCore;
using PlayerStats.BLL;
using PlayerStats.BLL.Services;
using PlayerStats.BLL.Services.Interfaces;
using PlayerStats.DAL;
using PlayerStats.DAL.Repositories;
using PlayerStats.DAL.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PlayerStatsContext>(options =>
    options.UseSqlite("Data Source=PlayerStatsDatabase.db")
);

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IFriendRepository, FriendRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IViolationRepository, ViolationRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IFriendService, FriendService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IViolationService, ViolationService>();

builder.Services.AddStackExchangeRedisCache(options => {
    options.Configuration = "localhost";
    options.InstanceName = "local";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
