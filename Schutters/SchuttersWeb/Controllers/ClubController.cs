using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchuttersData.Models;
using SchuttersServices;
using SchuttersWeb.Models;

namespace SchuttersWeb.Controllers
{
    [Authorize(Roles = "Leden, Admin")]
    public class ClubController:Controller
    {
        private readonly ClubService clubService;
        public ClubController(ClubService clubService)
        {
            this.clubService = clubService;
        }

        public IActionResult Index()
        {
            return View(clubService.GetAllClubs());
        }

        public IActionResult Details(int id)
        {
            var club = clubService.GetClub(id);
            if (club == null)
            {
                ViewBag.ErrorMessage = $"Geen club gevonden met stamnummer {id}";
            }
            return View(club);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ClubFormViewModel model)
        {
            if (clubService.StamnummerBestaat(model.Stamnummer))
            {
                ModelState.AddModelError("Stamnummer", "Een club met dit stamnummer komt al voor in de database. Kies een ander nummer.");
            }
            if (ModelState.IsValid)
            {
                var club = new Club
                {
                    Stamnummer = model.Stamnummer,
                    Naam = model.Naam,
                    Postcode = model.Postcode,
                    Gemeente = model.Gemeente,
                    Adres = model.Adres
                };
                clubService.AddClub(club);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var club = clubService.GetClub(id);
            if (club == null)
            {
                ViewBag.ErrorMessage = $"Geen club gevonden met stamnummer {id}.";
                return View((ClubFormViewModel?)null);
            }
            var model = new ClubFormViewModel
            {
                Stamnummer = club.Stamnummer,
                Naam = club.Naam,
                Postcode = club.Postcode,
                Gemeente = club.Gemeente,
                Adres = club.Adres,
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(ClubFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var club = new Club
                {
                    Stamnummer = model.Stamnummer,
                    Naam = model.Naam,
                    Postcode = model.Postcode,
                    Gemeente = model.Gemeente,
                    Adres = model.Adres
                };
                clubService.UpdateClub(club);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var club = clubService.GetClub(id);
            if (club == null)
                ViewBag.ErrorMessage = $"Geen club gevonden met stamnummer {id}.";
            return View(club);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            clubService.DeleteClub(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
