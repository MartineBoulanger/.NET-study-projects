using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchuttersData.Models;
using SchuttersServices;

namespace SchuttersWeb.Controllers
{
    public class ClubController : Controller
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(Club club)
        {
            if (clubService.StamnummerBestaat(club.Stamnummer))
            {
                ModelState.AddModelError("Stamnummer", "Een club met dit stamnummer komt al voor in de database. Kies een ander nummer.");
            }
            if (ModelState.IsValid)
            {
                clubService.AddClub(club);
                return RedirectToAction(nameof(Index));
            }
            return View(club);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var club = clubService.GetClub(id);
            if (club == null)
            {
                ViewBag.ErrorMessage = $"Geen club gevonden met stamnummer {id}.";
                return View((Club?)null);
            }
            return View(club);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Club club)
        {
            if (id != club.Stamnummer) return NotFound();
            if (ModelState.IsValid)
            {
                clubService.UpdateClub(club);
                return RedirectToAction(nameof(Index));
            }
            return View(club);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var club = clubService.GetClub(id);
            if (club == null)
            {
                ViewBag.ErrorMessage = $"Geen club gevonden met stamnummer {id}.";
            }
            return View(club);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            clubService.DeleteClub(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
