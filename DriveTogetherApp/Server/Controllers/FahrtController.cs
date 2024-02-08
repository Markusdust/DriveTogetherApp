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


        [HttpGet("{fahrtId}")]
        public async Task<ActionResult<ServiceResponse<Fahrt>>> GetFahrt(int fahrtId)
        {
            var result = await _fahrtService.GetFahrtAsync(fahrtId);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFahrt([FromBody] Fahrt fahrt)
        {
            var serviceResponse = await _fahrtService.UpdateFahrt(fahrt);

            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse.Message);
            }

            return Ok(serviceResponse);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<ServiceResponse<List<Auto>>>> GetAutosByUserId(string userId)
        {
            var result = await _fahrtService.GetFahrtenByUserIdAsync(userId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Fahrt>>> GetFahrten(int fahrtId)
        {
            var result = await _fahrtService.GetFahrtenAsync();
            return Ok(result);
        }
    }
}
