
using DriveTogetherApp.Server.Services.BuchungService;
using DriveTogetherApp.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace DriveTogetherApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuchungController : Controller
    {
        private readonly IBuchungService _buchungService;
        public BuchungController(IBuchungService buchungService)
        {
            _buchungService = buchungService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Buchung>>> CreateBuchung([FromBody] Buchung buchung)
        {
            var serviceResponse = await _buchungService.AddBuchung(buchung);
            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse.Message);
            }
            return Ok(serviceResponse);
        }
    }
}
