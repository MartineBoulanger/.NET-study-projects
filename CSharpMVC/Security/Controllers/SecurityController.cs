using Microsoft.AspNetCore.Mvc;

namespace Security.Controllers
{
    public class SecurityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
