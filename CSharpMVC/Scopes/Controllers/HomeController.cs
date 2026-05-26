using Microsoft.AspNetCore.Mvc;
using Scopes.Models;
using System.Diagnostics;

namespace Scopes.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService service;
        public HomeController(IService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            service.Pad += "indexaction/";
            return View();
        }

        public IActionResult Privacy()
        {
            service.Pad += "privacyaction/";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
