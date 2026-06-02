using BierenApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BierenApplication.Controllers
{
    public class BierController:Controller
    {
        private readonly IBierenService _bierService;
        public BierController(IBierenService bierService)
        {
            _bierService = bierService;
        }

        public IActionResult Index()
        {
            var recentVerwijderdBier = (string?)this.TempData["bier"];
            if (recentVerwijderdBier != null)
                ViewBag.recentVerwijderdBier = JsonSerializer.Deserialize<Bier?>(recentVerwijderdBier)?.Soort;
            return View(_bierService.FindAll());
        }

        public IActionResult Verwijderen(int id)
        {
            var bier = _bierService.Read(id);
            if (bier == null)
                ViewBag.biernummer = id;
            return View(bier);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var bier = _bierService.Read(id);
            this.TempData["bier"] = JsonSerializer.Serialize(bier);
            _bierService.Delete(id);
            return RedirectToAction(nameof(Verwijderd));
        }

        public IActionResult Verwijderd()
        {
            var tempdata = (string?)this.TempData["bier"];
            if (tempdata != null)
            {
                this.TempData.Keep("bier");
                Bier? bier = JsonSerializer.Deserialize<Bier?>(tempdata);
                return View(bier);
            }
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PrijsStijging()
        {
            _bierService.VerhoogPrijzen(5m);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult VanTotAlcohol()
        {
            var vanTotAlcoholViewModel = new VanTotAlcoholViewModel();
            return View(vanTotAlcoholViewModel);
        }

        [HttpGet]
        public IActionResult VanTotAlcoholResultaat(VanTotAlcoholViewModel vanTotAlcoholViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var lijst = _bierService.BierenTussen2AlcoholPercentages(vanTotAlcoholViewModel.VanAlcohol, vanTotAlcoholViewModel.TotAlcohol);
                if (lijst.Count <= 10)
                    vanTotAlcoholViewModel.Bieren = lijst;
                else
                    this.ModelState.AddModelError("", "Te veel resultaten");
                //vanTotAlcoholViewModel.Bieren = _bierService.VanTotAlcohol(vanTotAlcoholViewModel.VanAlcohol, vanTotAlcoholViewModel.TotAlcohol);
            }
            return View(nameof(VanTotAlcohol), vanTotAlcoholViewModel);
        }

        [HttpGet]
        public IActionResult Toevoegen()
        {
            var bier = new Bier();
            return View(bier);
        }

        [HttpPost]
        public IActionResult Toevoegen(Bier b)
        {
            if (this.ModelState.IsValid)
            {
                _bierService.Add(b);
                return RedirectToAction("Index");
            }
            else
                return View(b);
        }

        public IActionResult FindBierenBySoortNaam(string soortnaam)
        {
            var bierenLijst = _bierService.BierenVanEenSoort(soortnaam);
            return View(nameof(Index), bierenLijst);
        }

        public IActionResult FindBierenByPostcode(short postcode)
        {
            var bierenLijst = _bierService.BierenMetPostcode(postcode);
            return View(nameof(Index), bierenLijst);
        }
    }
}
