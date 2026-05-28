using Microsoft.AspNetCore.Mvc;

namespace Tuincentrum.ViewComponents
{
    public class Afbeelding:ViewComponent
    {
        private readonly IWebHostEnvironment env;
        public Afbeelding(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public IViewComponentResult Invoke(int plantnummer)
        {
            var imgFileNameWithPath = Path.Combine(env.WebRootPath, "images", plantnummer + ".jpg");
            var imgSrc = File.Exists(imgFileNameWithPath) ? plantnummer.ToString() : "default";
            return View((object)imgSrc);
        }
    }
}
