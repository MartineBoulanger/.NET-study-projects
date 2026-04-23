using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace ViewComponenten.ViewComponents
{
    public class Reclame : ViewComponent
    {
        static string[] powerbars = { "mars", "bounty", "snickers", "twix" };
        //public IViewComponentResult Invoke()
        public IViewComponentResult Invoke(string tekst, bool html)
        {
            //Random random = new Random();
            //int randomNumber = random.Next(0, 4);
            //return View((object)powerbars[randomNumber]);
            //return Content("Deze tekst zal <letterlijk> worden weergegeven");
            //return new HtmlContentViewComponentResult(new HtmlString("Deze tekst zal <letterlijk> worden weergegeven"));
            if (html)
                return new HtmlContentViewComponentResult(new HtmlString(tekst));
            else
                return Content(tekst);
        }

        // als invake met async
        //public async Task<IViewComponentResult> InvokeAsync(string tekst, bool html)
        //{
        //    await ...;
        //    if (html)
        //        return new HtmlContentViewComponentResult(new HtmlString(tekst));
        //    else return Content(tekst);
        //}
    }
}
