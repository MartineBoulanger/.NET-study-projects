using Microsoft.AspNetCore.Mvc;

namespace Areas.Areas.Publiek.Controllers
{
    [Area("Publiek")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
