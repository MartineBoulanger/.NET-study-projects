using Microsoft.AspNetCore.Mvc;

namespace Voorbeeld1.Controllers
{
    public class FiliaalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult Read(int? id)
        {
            return View();
        }
    }
}
