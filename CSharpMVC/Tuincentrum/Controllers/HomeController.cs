using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using Tuincentrum.Models;
using Tuincentrum.Resources;

namespace Tuincentrum.Controllers
{
    //[Route("Home")] // prefix voor alle routes in deze controller
    [Route("[controller]")] // prefix voor alle routes in deze controller
    public class HomeController:Controller
    {
        private readonly IStringLocalizer<HomeController> localizer;
        private readonly IStringLocalizer<SharedResource> sharedLocalizer;
        public HomeController(IStringLocalizer<HomeController> localizer, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            this.localizer = localizer;
            this.sharedLocalizer = sharedLocalizer;
        }

        [Route("")] // matched de route "Home"
        [Route("/")] // matched de route ""
        [Route("Index")]
        public IActionResult Index()
        {
            //ViewBag.Welkomstekst = localizer["Welkom"];
            ViewBag.Planten = sharedLocalizer["Planten"];
            return View();
        }

        [Route("Prive")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("StatusCodeErrorPage")]
        public IActionResult StatusCodeErrorPage(int statusCode)
        {
            Response.StatusCode = statusCode;
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "De gevraagde URL werd niet gevonden.";
                    break;
            }
            return View();
        }

        [Route("TaalInstellen")]
        public IActionResult TaalInstellen(string culture, string returnUrl)
        {
            RequestCulture requestCulture = new RequestCulture(culture);
            string cultureCookie = CookieRequestCultureProvider.MakeCookieValue(requestCulture);
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, cultureCookie, option);
            return LocalRedirect(returnUrl); // refresh the current page
        }

        [HttpGet("Invulform")]
        public IActionResult FormTonen()
        {
            return View();
        }

        [HttpPost("Invulform")]
        public IActionResult FormVerwerken()
        {
            // Verwerk de formuliergegevens hier
            return Redirect("/");
        }
    }
}
