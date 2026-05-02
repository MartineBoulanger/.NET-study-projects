using Eindoefening.Models;
using Eindoefening.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Eindoefening.Controllers
{
    public class HomeController:Controller
    {
        private readonly BestemmingService _bestemmingService;
        public HomeController(BestemmingService bestemmingService)
        {
            _bestemmingService = bestemmingService;
        }

        public IActionResult Index()
        {
            var klantCookie = Request.Cookies["KlantVoornaam"];
            if (string.IsNullOrEmpty(klantCookie))
                return RedirectToAction("Aanmelden", "Klant");

            // bestemmingen uit de session ophalen
            var bestemmingen = new BestemmingViewModel
            {
                Bestemmingen = _bestemmingService.GetAll()
            };

            // cookie meegeven aan ViewBag voor de partial view in de header
            ViewBag.voornaam = klantCookie;

            return View(bestemmingen);
        }

        [HttpPost]
        public IActionResult AddBestemming(BestemmingViewModel bvm)
        {
            var bestemmingen = _bestemmingService.GetAll();

            if (!this.ModelState.IsValid)
            {
                bvm.Bestemmingen = bestemmingen;
                return View("Index", bvm);
            }

            // er mogen geen dubbele bestemmingen zijn - validatie
            var trimmed = bvm.Bestemming.Trim();
            bool bestemmingBestaat = bestemmingen.Any(b => b.Equals(trimmed, StringComparison.OrdinalIgnoreCase));

            if (bestemmingBestaat)
            {
                bvm.Bestemmingen = bestemmingen;
                this.ModelState.AddModelError("Bestemming", "De bestemming staat al in de lijst");
                return View("Index", bvm);
            }

            _bestemmingService.Add(trimmed);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveBestemming(string bestemming)
        {
            _bestemmingService.Remove(bestemming);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ClearBestemmingen()
        {
            _bestemmingService.Opslaan(null!); // null doorgeven om hele lijst leeg te maken
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
