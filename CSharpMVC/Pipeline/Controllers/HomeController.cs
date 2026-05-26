using Microsoft.AspNetCore.Mvc;

namespace Pipeline.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //throw new Exception();
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
