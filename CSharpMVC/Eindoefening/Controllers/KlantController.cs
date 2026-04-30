using Eindoefening.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eindoefening.Controllers
{
    public class KlantController:Controller
    {
        public IActionResult Aanmelden()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Aanmelden(KlantViewModel kvm)
        {
            if (this.ModelState.IsValid)
            {
                // cookie opslaan
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddHours(1); // cookie is maar 1 uur geldig ivm persoonlijke data
                //option.Expires = DateTime.Now.AddMinutes(2); // voor development en testing
                Response.Cookies.Append("KlantVoornaam", kvm.Voornaam, option);
                return RedirectToAction("Index", "Home");
            }
            else return View(kvm);
        }
    }
}
