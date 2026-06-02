using Microsoft.AspNetCore.Mvc;

namespace Areas.Areas.Prive.Controllers
{
    [Area("Prive")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
