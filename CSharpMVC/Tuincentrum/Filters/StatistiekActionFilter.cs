using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Tuincentrum.Filters
{
    public class StatistiekActionFilter : ActionFilterAttribute
    {
        static Dictionary<string, int> statistiek = new Dictionary<string, int>();
        public static Dictionary<string, int> Statistiek { get => statistiek; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string url = context.HttpContext.Request.Path.ToString();
            lock (statistiek)
            {
                if (statistiek.ContainsKey(url))
                {
                    // om de pipeline te kortsluiten kun je dit doen
                    if (statistiek[url] > 3) context.Result = new ViewResult() { ViewName = "~/Views/Statistiek/Error.cshtml" };
                    else statistiek[url]++;
                }
                else statistiek[url] = 1;
            }
        }
    }
}
