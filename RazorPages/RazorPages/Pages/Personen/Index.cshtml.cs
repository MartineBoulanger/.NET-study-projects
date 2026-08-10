using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data.Models;
using RazorPages.Data.Repos;

namespace RazorPages.Pages.Personen
{
    public class IndexModel(IPersonenRepo personenRepo) : PageModel
    {
        [TempData]
        public string Boodschap { get; set; }

        public IEnumerable<Persoon> Personen { get; set; } = null!;
        public void OnGet()
        {
            Personen = personenRepo.GetAllePersonen();
        }
    }
}
