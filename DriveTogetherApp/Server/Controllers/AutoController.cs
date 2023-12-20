using DriveTogetherApp.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DriveTogetherApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private readonly IAutoService _autoService;
        public AutoController(IAutoService autoService)
        {
            _autoService = autoService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Auto>>>> GetAutos()
        {
            var result = await _autoService.GetAutosAsync();
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<ServiceResponse<List<Auto>>>> GetAutosByUserId(string userId)
        {
            var result = await _autoService.GetAutosByUserIdAsync(userId);
            return Ok(result);
        }

        [HttpGet("{autoId}")]
        public async Task<ActionResult<ServiceResponse<Auto>>> GetAuto(int autoId)
        {
            var result = await _autoService.GetAutoAsync(autoId);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuto([FromBody] Auto auto)
        {
            var serviceResponse = await _autoService.UpdateAuto(auto);

            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse.Message);
            }

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Auto>>> CreateAuto([FromBody] Auto auto)
        {
            var serviceResponse = await _autoService.AddAuto(auto);
            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse.Message);
            }
            return Ok(serviceResponse);
        }
    }
}
