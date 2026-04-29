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
                return RedirectToAction("Create", "Klant");

            var bestemmingen = new BestemmingViewModel
            {
                Bestemmingen = _bestemmingService.GetAll()
            };

            return View(bestemmingen);
        }

        // kijk of je hier een model aan kunt koppelen en dan kijken of je die partiel view async kunt maken indien nodig
        public IActionResult KlantInfo()
        {
            KlantInfo klantInfo = new();
            var voornaam = Request.Cookies["KlantVoornaam"];
            if (string.IsNullOrEmpty(voornaam))
                return RedirectToAction("Create", "Klant");
            klantInfo.Voornaam = voornaam.ToString();
            return PartialView("_KlantInfo", klantInfo);
        }

        [HttpPost]
        public IActionResult AddBestemming(BestemmingViewModel vm)
        {
            var bestemmingen = _bestemmingService.GetAll();

            if (!this.ModelState.IsValid)
            {
                vm.Bestemmingen = bestemmingen;
                return View("Index", vm);
            }

            // er mogen geen dubbele bestemmingen zijn
            var trimmed = vm.Bestemming.Trim();
            bool bestemmingBestaat = bestemmingen.Any(b => b.Equals(trimmed, StringComparison.OrdinalIgnoreCase));

            if (bestemmingBestaat)
            {
                vm.Bestemmingen = bestemmingen;
                this.ModelState.AddModelError("Bestemming", "De bestemming staat al in de lijst");
                return View("Index", vm);
            }

            _bestemmingService.Add(trimmed);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveBestemming(string bestemming)
        {
            _bestemmingService.Remove(bestemming);
            return Redirect("/home");
        }

        [HttpPost]
        public IActionResult ClearBestemmingen()
        {
            _bestemmingService.Opslaan(null!);
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
