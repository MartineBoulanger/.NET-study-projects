using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Security.Controllers
{
    [Authorize(Roles = "Leraar")]
    public class LeraarController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
