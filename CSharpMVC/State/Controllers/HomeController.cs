using Microsoft.AspNetCore.Mvc;
using State.Models;
using System.Diagnostics;
using System.Text.Json;

namespace State.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            // gebruik van cookie
            string resultaat = "Dit is jouw eerste bezoek";
            // checken of de cookie al bestaat
            if (Request.Cookies["lastvisit"] != null)
            {
                resultaat = "Welkom terug. Jouw laatste bezoek was op " + Request.Cookies["lastvisit"];
            }
            string laatsteBezoek = DateTime.Now.ToString();
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(365);
            Response.Cookies.Append("lastvisit", laatsteBezoek, option);
            ViewBag.Tijdstip = resultaat;

            // gebruik van session
            var sessionVariabeleAantalBezoeken = HttpContext.Session.GetInt32("aantalBezoeken");
            if (sessionVariabeleAantalBezoeken == null)
                sessionVariabeleAantalBezoeken = 1;
            else
                sessionVariabeleAantalBezoeken += 1;
            HttpContext.Session.SetInt32("aantalBezoeken", (int)sessionVariabeleAantalBezoeken);
            ViewBag.aantalBezoeken = (int)sessionVariabeleAantalBezoeken;

            // object omzetten naar JSON
            var laatsteBez = HttpContext.Session.GetString("lastvisit");
            if (string.IsNullOrEmpty(laatsteBez))
                ViewBag.lastvisit = "geen";
            else
                ViewBag.lastvisit = JsonSerializer.Deserialize<DateTime>(laatsteBez);
            var geserializeerdeDatum = JsonSerializer.Serialize(DateTime.Now);
            HttpContext.Session.SetString("lastvisit", geserializeerdeDatum);

            // met meerdere sessies -- verzameling
            var sessionVariabeleBezoeken = HttpContext.Session.GetString("visits");
            List<DateTime>? lijstBezoeken;
            if (string.IsNullOrEmpty(sessionVariabeleBezoeken))
                lijstBezoeken = new List<DateTime>();
            else
                lijstBezoeken = JsonSerializer.Deserialize<List<DateTime>>(sessionVariabeleBezoeken);
            lijstBezoeken?.Add(DateTime.Now);
            var geserializeerdeLijst = JsonSerializer.Serialize(lijstBezoeken);
            HttpContext.Session.SetString("visits", geserializeerdeLijst);
            ViewBag.visits = lijstBezoeken;

            return View();
        }

        public IActionResult Wissen()
        {
            // cookie verwijderen
            if (Request.Cookies["lastvisit"] != null)
                Response.Cookies.Delete("lastvisit");

            // session resetten
            if (HttpContext.Session.GetInt32("aantalBezoeken") != null)
                HttpContext.Session.Remove("aantalBezoeken");

            // object resetten
            if (HttpContext.Session.GetString("lastvisit") != null)
                HttpContext.Session.Remove("lastvisit");

            // list resetten
            if (HttpContext.Session.GetString("visits") != null)
                HttpContext.Session.Remove("visits");

            return View();
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
