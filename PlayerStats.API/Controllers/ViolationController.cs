using Microsoft.AspNetCore.Mvc;
using PlayerStats.BLL.Services.Interfaces;
using PlayerStats.Data.Dtos;

namespace PlayerStats.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViolationController : ControllerBase
    {
        private readonly IViolationService _service;

        public ViolationController(IViolationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViolationDTO>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] ViolationDTO modelDTO)
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
