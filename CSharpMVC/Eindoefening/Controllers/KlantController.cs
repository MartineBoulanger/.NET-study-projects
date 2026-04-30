using Eindoefening.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eindoefening.Controllers
{
    public class KlantController:Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(KlantViewModel kvm)
        {
            if (this.ModelState.IsValid)
            {
                // cookie opslaan hier
                Response.Cookies.Append("KlantVoornaam", kvm.Voornaam);
                return RedirectToAction(nameof(Index), "Home");
            }
            else return View(kvm);
        }
    }
}
