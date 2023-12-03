using DriveTogetherApp.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace DriveTogetherApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
            private static List<Auto> Autos = new List<Auto>
        {
            new Auto
            {
            AutoId = 1,
            Fahrtenanbieter = "Markus Transporte",
            Marke = "Volkswagen",
            Modell = "Golf",
            Farbe = "Blau",
            Kennzeichen = "B-MK 1234",
            Baujahr = new DateTime(2018, 1, 1), // 1. Januar 2018 als Beispiel für das Baujahr
            Typ = "Kompakt"
            },

           new Auto
            {
            AutoId = 2,
            Fahrtenanbieter = "Markus Transporte",
            Marke = "Volkswagen",
            Modell = "Golf",
            Farbe = "Blau",
            Kennzeichen = "B-MK 1234",
            Baujahr = new DateTime(2018, 1, 1), // 1. Januar 2018 als Beispiel für das Baujahr
            Typ = "Kompakt"
            },
        };

        [HttpGet]
        public async Task<ActionResult<List<Auto>>> GetAuto()
        {
            return Ok(Autos);
        }
    }
}
