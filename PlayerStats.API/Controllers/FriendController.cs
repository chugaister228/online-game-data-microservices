using Microsoft.AspNetCore.Mvc;
using PlayerStats.BLL.Services.Interfaces;
using PlayerStats.Data.Dtos;

namespace PlayerStats.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _service;

        public FriendController(IFriendService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FriendDTO>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] FriendDTO modelDTO)
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
