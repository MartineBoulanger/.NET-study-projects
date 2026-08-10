using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data.Models;
using RazorPages.Data.Repos;

namespace RazorPages.Pages.Personen
{
    public class EditModel(IPersonenRepo personenRepo) : PageModel
    {
        public Persoon? Persoon { get; set; }
        public IActionResult OnGet(int id)
        {
            Persoon = personenRepo.GetPersoon(id);
            if (Persoon == null) return RedirectToPage(nameof(NotFound));
            return Page();
        }
        public IActionResult OnPost(Persoon persoon)
        {
            if (ModelState.IsValid)
            {
                personenRepo.UpdatePersoon(persoon);
                if (persoon != null) TempData["boodschap"] = $"De gegevens van {persoon.Voornaam} {persoon.Familienaam} werden gewijzigd";
                return RedirectToPage(nameof(Index));
            }
            return Page();
        }
    }
}
