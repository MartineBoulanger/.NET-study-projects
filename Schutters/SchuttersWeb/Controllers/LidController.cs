using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchuttersData.Models;
using SchuttersServices;
using SchuttersWeb.Models;

namespace SchuttersWeb.Controllers
{
    [Authorize(Roles = "Leden, Admin")]
    public class LidController:Controller
    {
        private readonly LidService lidService;
        public LidController(LidService lidService)
        {
            this.lidService = lidService;
        }

        public IActionResult Index()
        {
            return View(lidService.GetAllLeden());
        }

        public IActionResult Details(long id)
        {
            var lid = lidService.GetLid(id);
            if (lid == null)
                ViewBag.ErrorMessage = $"Geen lid gevonden met lidnummer {id}";
            return View(lid);
        }

        public IActionResult Search()
        {
            var model = new ZoekLedenViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Search(ZoekLedenViewModel model)
        {
            model.Resultaten = lidService.Search(model.Voornaam, model.Naam, model.Geslacht, model.Niveau, model.Clubnaam);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var model = new LidFormViewModel
            {
                Clubs = GetClubSelectList(),
                GeslachtOpties = GetGeslachtSelectList(),
                NiveauOpties = GetNiveauSelectList()
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(LidFormViewModel model)
        {
            if (lidService.LidnummerBestaat(model.Lidnummer))
                ModelState.AddModelError("Lidnummer", "Een lid met dit lidnummer komt al voor in de database. Kies een ander nummer.");
            if (ModelState.IsValid)
            {
                var lid = new Lid
                {
                    Lidnummer = model.Lidnummer,
                    Naam = model.Naam,
                    Voornaam = model.Voornaam,
                    Geslacht = model.Geslacht,
                    Niveau = model.Niveau,
                    ClubId = model.ClubId
                };
                lidService.AddLid(lid);
                return RedirectToAction(nameof(Index));
            }
            model.Clubs = GetClubSelectList();
            model.GeslachtOpties = GetGeslachtSelectList();
            model.NiveauOpties = GetNiveauSelectList();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(long id)
        {
            var lid = lidService.GetLid(id);
            if (lid == null)
            {
                ViewBag.ErrorMessage = $"Geen lid gevonden met lidnummer {id}";
                return View((LidFormViewModel?)null);
            }
            var model = new LidFormViewModel
            {
                Lidnummer = lid.Lidnummer,
                Naam = lid.Naam,
                Voornaam = lid.Voornaam,
                Geslacht = lid.Geslacht,
                Niveau = lid.Niveau,
                ClubId = lid.ClubId,
                Clubs = GetClubSelectList(lid.ClubId),
                GeslachtOpties = GetGeslachtSelectList(lid.Geslacht),
                NiveauOpties = GetNiveauSelectList(lid.Niveau)
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(LidFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var lid = new Lid
                {
                    Lidnummer = model.Lidnummer,
                    Naam = model.Naam,
                    Voornaam = model.Voornaam,
                    Geslacht = model.Geslacht,
                    Niveau = model.Niveau,
                    ClubId = model.ClubId
                };
                lidService.UpdateLid(lid);
                return RedirectToAction(nameof(Index));
            }
            model.Clubs = GetClubSelectList(model.ClubId);
            model.GeslachtOpties = GetGeslachtSelectList(model.Geslacht);
            model.NiveauOpties = GetNiveauSelectList(model.Niveau);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(long id)
        {
            var lid = lidService.GetLid(id);
            if (lid == null)
                ViewBag.ErrorMessage = $"Geen lid gevonden met lidnummer {id}";
            return View(lid);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(long id)
        {
            lidService.DeleteLid(id);
            return RedirectToAction(nameof(Index));
        }

        // functies die de selectie opties samenstellen voor de dropdown velden in de formulieren
        private IEnumerable<SelectListItem> GetClubSelectList(int? selected = null)
        {
            return lidService.GetAllClubs().Select(c => new SelectListItem
            {
                Text = c.Naam,
                Value = c.Stamnummer.ToString(),
                Selected = c.Stamnummer == selected
            });
        }

        private static IEnumerable<SelectListItem> GetGeslachtSelectList(string? selected = null)
        {
            var opties = new[] { "M", "V", "X" };
            return opties.Select(o => new SelectListItem
            {
                Text = o,
                Value = o,
                Selected = o == selected
            });
        }

        private static IEnumerable<SelectListItem> GetNiveauSelectList(string? selected = null)
        {
            var opties = new[]
            {
                new SelectListItem { Text = "C (Competitiespeler)", Value = "C" },
                new SelectListItem { Text = "R (Recreant)", Value = "R" },
                new SelectListItem { Text = "J (Jeugd)", Value = "J" }
            };
            foreach (var optie in opties)
                optie.Selected = optie.Value == selected;
            return opties;
        }
    }
}
