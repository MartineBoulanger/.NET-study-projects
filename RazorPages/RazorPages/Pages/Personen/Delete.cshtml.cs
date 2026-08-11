using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data.Models;
using RazorPages.Data.Repos;

namespace RazorPages.Pages.Personen
{
    public class DeleteModel(IPersonenRepo personenRepo):PageModel
    {
        [BindProperty]
        public Persoon? Persoon { get; set; }
        public IActionResult OnGet(int id)
        {
            Persoon = personenRepo.GetPersoon(id);
            if (Persoon == null)
                return RedirectToPage(nameof(NotFound));
            return Page();
        }
        public IActionResult OnPost()
        {
            personenRepo.DeletePersoon(Persoon.Id);
            return RedirectToPage(nameof(Index));
        }
    }
}
