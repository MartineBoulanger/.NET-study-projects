using Microsoft.AspNetCore.Mvc;
using BierenApplication.Models;

namespace BierenApplication.Controllers
{
    public class BierController : Controller
    {
        public IActionResult Index()
        {
            var bieren = new List<Bier>();
            bieren.Add(new Bier { Id = 1, Naam = "Romy Pils", Alcohol = 5f });
            bieren.Add(new Bier { Id = 2, Naam = "Kasteelbier", Alcohol = 12f });
            bieren.Add(new Bier { Id = 3, Naam = "Maes Radler", Alcohol = 0f });
            return View(bieren);
        }
    }
}
