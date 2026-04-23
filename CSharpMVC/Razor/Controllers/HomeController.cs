using Microsoft.AspNetCore.Mvc;
using Razor.Models;
using Razor.Services;
using System.Diagnostics;
using System.Text.Json;

namespace Razor.Controllers
{ 
    public class HomeController : Controller
    {
        // DI voor de filiaal service
        private readonly FiliaalService _filiaalService;
        public HomeController(FiliaalService filiaalService)
        {
            _filiaalService = filiaalService;
        }

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

            // het tempdta gebruiken van de verwijderde vestiging
            var recentVerwijderdFiliaal = (string?)this.TempData["filiaal"];
            if (recentVerwijderdFiliaal != null) ViewBag.recenteVerwijdering = JsonSerializer.Deserialize<Filiaal?>(recentVerwijderdFiliaal)?.Naam;
            
            return View(_filiaalService.FindAll());
        }

        public IActionResult Verwijderen(int id)
        {
            var filiaal = _filiaalService.Read(id);
            if (filiaal == null) ViewBag.filiaalnummer = id;
            return View(filiaal);
        }

        // action dat de verwijdering van de vestiging doet
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var filiaal = _filiaalService.Read(id);
            this.TempData["filiaal"] = JsonSerializer.Serialize(filiaal);
            _filiaalService.Delete(id);
            return RedirectToAction(nameof(Verwijderd));
        }

        // redirect action
        public IActionResult Verwijderd()
        {
            //var tempdata = (string?)this.TempData["filiaal"];
            var tempdata = (string?)this.TempData.Peek("filiaal"); // met de Peek method

            if (tempdata != null)
            {
                //this.TempData.Keep("filiaal");
                Filiaal? filiaal = JsonSerializer.Deserialize<Filiaal?>(tempdata);
                return View(filiaal);

            }
            else return RedirectToAction("Vestigingen");
        }
    }
}
