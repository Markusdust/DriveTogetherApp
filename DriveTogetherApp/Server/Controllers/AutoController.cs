
using DriveTogetherApp.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace DriveTogetherApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    { 
        private readonly DataContext _context;
        public AutoController(DataContext _context) 
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<Auto>>> GetAuto()
        {
            return Ok(Autos);
        }
    }
}
