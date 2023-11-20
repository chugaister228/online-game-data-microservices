using Microsoft.AspNetCore.Mvc;
using Skins.BLL.Services.Interfaces;
using Skins.Data.Dtos;

namespace Skins.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : Controller
    {
        private readonly IWeaponService _service;

        public WeaponController(IWeaponService service)
        {
            _service = service;
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<WeaponDTO>> GetById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<WeaponDTO>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] WeaponDTO modelDTO)
        {
            return Ok(await _service.Insert(modelDTO));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteById(Guid id)
        {
            return Ok(await _service.DeleteById(id));
        }
    }
}
