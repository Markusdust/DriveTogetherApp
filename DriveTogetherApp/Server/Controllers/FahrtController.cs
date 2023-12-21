using Microsoft.AspNetCore.Mvc;

namespace DriveTogetherApp.Server.Controllers
{
    public class FahrtController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
