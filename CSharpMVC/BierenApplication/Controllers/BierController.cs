using Microsoft.AspNetCore.Mvc;
using BierenApplication.Services;
using System.Text.Json;
using BierenApplication.Models;

namespace BierenApplication.Controllers
{
    public class BierController : Controller
    {
        private readonly BierService _bierService;
        public BierController(BierService bierService)
        {
            _bierService = bierService;
        }

        public IActionResult Index()
        {
            var recentVerwijderdBier = (string?)this.TempData["bier"];
            if (recentVerwijderdBier != null) ViewBag.recentVerwijderdBier = JsonSerializer.Deserialize<Bier?>(recentVerwijderdBier)?.Naam;
            return View(_bierService.FindAll());
        }

        public IActionResult Verwijderen(int id)
        {
            var bier = _bierService.Read(id);
            if (bier == null) ViewBag.biernummer = id;
            return View(bier);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var bier = _bierService.Read(id);
            this.TempData["bier"] = JsonSerializer.Serialize(bier);
            _bierService.Delete(id);
            return Redirect("~/bier/verwijderd");
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
            else return RedirectToAction("Index");
        }
    }
}
