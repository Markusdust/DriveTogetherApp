using DriveTogetherApp.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace DriveTogetherApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FahrtController : ControllerBase
    {
        private readonly IFahrtService _fahrtService;

        public FahrtController(IFahrtService fahrtService)
        {
            _fahrtService = fahrtService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Fahrt>>> CreateFahrt([FromBody] Fahrt fahrt)
        {
            var serviceResponse = await _fahrtService.CreateFahrtAsync(fahrt);
            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse.Message);
            }
            return Ok(serviceResponse);
        }
    }
}
