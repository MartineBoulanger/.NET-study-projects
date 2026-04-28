using Microsoft.AspNetCore.Mvc;
using Razor.Models;
using Razor.Services;

namespace Razor.Controllers
{
    public class PersoonController:Controller
    {
        private readonly PersoonService _persoonService;
        public PersoonController(PersoonService persoonService)
        {
            _persoonService = persoonService;
        }

        public IActionResult Index()
        {
            return View(_persoonService.FindAll());
        }

        [HttpGet]
        public IActionResult VerwijderForm(int id)
        {
            Persoon? persoon = _persoonService.FindByID(id);
            if (persoon is null)
                ViewBag.id = id;
            return View(persoon);

        }

        [HttpPost]
        public IActionResult Verwijderen(int id)
        {
            _persoonService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Opslag()
        {
            OpslagViewModel opslagViewModel = new();
            opslagViewModel.Percentage = 10m;
            return View(opslagViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Opslag(OpslagViewModel opslagViewModel)
        {
            if (this.ModelState.IsValid)
            {                
                _persoonService.Opslag(opslagViewModel.VanWedde, opslagViewModel.TotWedde, opslagViewModel.Percentage);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(opslagViewModel);
            }
        }

        [HttpGet]
        public IActionResult VanTotWedde()
        {
            var vanTotWeddeViewModel = new VanTotWeddeViewModel();
            return View(vanTotWeddeViewModel);
        }

        [HttpGet]
        public IActionResult VanTotWeddeResultaat(VanTotWeddeViewModel vanTotWeddeViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var lijst = _persoonService.VanTotWedde(vanTotWeddeViewModel.VanWedde, vanTotWeddeViewModel.TotWedde);
                if (lijst.Count <= 3) vanTotWeddeViewModel.Personen = lijst;
                else this.ModelState.AddModelError("", "Te veel resultaten");
                //vanTotWeddeViewModel.Personen = _persoonService.VanTotWedde(vanTotWeddeViewModel.VanWedde, vanTotWeddeViewModel.TotWedde);
            }
            return View(nameof(VanTotWedde), vanTotWeddeViewModel);
        }
    }
}
