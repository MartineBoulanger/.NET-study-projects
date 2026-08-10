using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data.Models;
using RazorPages.Data.Repos;

namespace RazorPages.Pages.Personen
{
    public class DetailsModel(IPersonenRepo personenRepo) : PageModel
    {
        public Persoon? Persoon { get; set; }
        public IActionResult OnGet(int id)
        {
            Persoon = personenRepo.GetPersoon(id);
            if (Persoon == null) return RedirectToPage(nameof(NotFound));
            return Page();
        }
    }
}
