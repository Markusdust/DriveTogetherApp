using DriveTogetherApp.Shared.Model;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{autoId}")]
        public async Task<ActionResult<ServiceResponse<Auto>>> GetAuto(int autoId)
        {
            var result = await _autoService.GetAutoAsync(autoId);
            return Ok(result);
        }
    }
}
