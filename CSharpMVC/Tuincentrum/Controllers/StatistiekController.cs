using Microsoft.AspNetCore.Mvc;

namespace Tuincentrum.Controllers
{
    public class StatistiekController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
