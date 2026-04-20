using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Razor.Models;
using System.Diagnostics;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Persoon eddy = new Persoon { Voornaam = "Eddy", Familienaam = "Wally" };
            return View(eddy);
        }

        [ActionName("werknemerslijst")]
        public IActionResult AlleWerknemers()
        {
            var werknemers = new List<Werknemer>();
            werknemers.Add(new Werknemer { Voornaam = "Steven", Wedde = 1000, Indienst = DateTime.Today });
            werknemers.Add(new Werknemer { Voornaam = "Prosper", Wedde = 2000, Indienst = DateTime.Today.AddDays(2) });
            return View("AlleWerknemers", werknemers);
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

        public IActionResult Palindroom(string woord)
        {
            char[] woordAlsCharArr = woord.ToCharArray();
            Array.Reverse(woordAlsCharArr);
            string omgekeerd =  new string(woordAlsCharArr);
            ViewBag.palindroom = woord == omgekeerd;
            ViewBag.ingetiktwoord = woord;
            return View();
        }

        public IActionResult Vestigingen()
        {
            Hoofdzetel deHoofdzetel = new Hoofdzetel { Straat = "Keizerslaan", HuisNr = "11", PostCode = "1000", Gemeente = "Brussel" };
            ViewBag.deHoofdzetel = deHoofdzetel;
            List<Filiaal> deFilialen = new List<Filiaal>() { 
                new Filiaal { ID = 1, Naam = "Antwerpen", Gebouwd = new DateTime(2003,1,1), Waarde = 2000000m },
                new Filiaal { ID = 2, Naam = "Wondelgem", Gebouwd = new DateTime(1979,1,1), Waarde = 2500000m },
                new Filiaal { ID = 3, Naam = "Haasrode", Gebouwd = new DateTime(1976,1,1), Waarde = 1000000m },
                new Filiaal { ID = 4, Naam = "Wevelgem", Gebouwd = new DateTime(1981,1,1), Waarde = 1600000m },
                new Filiaal { ID = 5, Naam = "Genk", Gebouwd = new DateTime(1990,1,1), Waarde = 4000000m },
            };
            return View(deFilialen);
        }
    }
}
