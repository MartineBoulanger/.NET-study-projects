using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        public string Boodschap { get; set; }
        public void OnGet()
        {
            Boodschap = "Intro Razor Pages";
        }
    }
}
