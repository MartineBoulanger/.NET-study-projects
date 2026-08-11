using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data.Models;
using RazorPages.Data.Repos;

namespace RazorPages.Pages.Personen
{
    public class IndexModel(IPersonenRepo personenRepo):PageModel
    {
        [TempData]
        public string Boodschap { get; set; }

        public IEnumerable<Persoon> Personen { get; set; } = null!;

        [BindProperty(SupportsGet = true)]
        public string ZoekTerm { get; set; }

        public string MailBoodschap { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }

        public void OnGet()
        {
            VulPersonenLijst();
        }
        public void OnGetSendEmail()
        {
            VulPersonenLijst();
            MailBoodschap = $"De lijst werd verstuurd naar {Email}";
        }
        void VulPersonenLijst()
        {
            if (string.IsNullOrEmpty(ZoekTerm))
                Personen = personenRepo.GetAllePersonen();
            else
                Personen = personenRepo.ZoekPersonen(ZoekTerm);
        }
    }
}
