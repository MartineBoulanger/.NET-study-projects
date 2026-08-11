using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data.Models;
using RazorPages.Data.Repos;

namespace RazorPages.Pages.Personen
{
    public class CreateModel(IPersonenRepo personenRepo):PageModel
    {
        [BindProperty]
        public Persoon Persoon { get; set; } = new Persoon()
        {
            Geboren = DateTime.Now
        };
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                personenRepo.AddPersoon(Persoon);
                return RedirectToPage(nameof(Index));
            }
            return Page();
        }
    }
}
