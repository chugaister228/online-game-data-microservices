using Donations.BLL.Services.Interfaces;
using Donations.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Donations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IDonationService _service;

        public DonationController(IDonationService service)
        {
            _service = service;
        }

        [HttpGet("GetDonationById/{id}")]
        public async Task<ActionResult<DonationDTO>> GetById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpGet("GetDonations")]
        public async Task<ActionResult<IEnumerable<DonationDTO>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] DonationDTO modelDTO)
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
