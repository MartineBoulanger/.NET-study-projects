using Microsoft.AspNetCore.Mvc;

namespace MeerOverControllers.Controllers
{
    public class WerknemerController:Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
            //return Content("Dit is de Index actie van de WerknemerController"); // om platte tekst, xml, etc terug te geven -- handig voor sitemaps en robot.txt bestanden
            //return File(@"images\happy.png", "image/png"); // om een bestand terug te geven
        }

        [NonAction]
        public string HuidigeDatum()
        {
            return DateTime.Now.ToShortDateString();
        }

        //public IActionResult Detail(int? id)
        //{
        //    return View();
        //}
        // met zelf een return waarde -- als voorbeeld
        public IActionResult Detail(int? id)
        {
            var viewResult = new ViewResult();
            return viewResult;
        }

        //public IActionResult Detail()
        //{
        //    return View();
        //}

        public IActionResult VerdubbelDeWeddes()
        {
            return Redirect("~/werknemer/weddesaangepast");
        }

        public IActionResult Weddesaangepast()
        {
            return View();
        }

        public IActionResult Alfa()
        {
            return View("Beta");
        }

        //Oefening
        public IActionResult EvenOfOneven(int id)
        {
            if (id % 2 == 0)
                return Content("Je tikte een even getal");
            else
                return Redirect("~/werknemer/oneven");
        }

        public IActionResult Oneven()
        {
            return Content("Je tikte een oneven getal");
        }
    }
}
