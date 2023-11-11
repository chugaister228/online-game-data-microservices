using Microsoft.AspNetCore.Mvc;
using Skins.BLL.Services.Interfaces;
using Skins.Data.Dtos;

namespace Skins.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : Controller
    {
        private readonly IPetService _service;

        public PetController(IPetService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PetDTO>> GetById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetDTO>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] PetDTO modelDTO)
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
