using Microsoft.AspNetCore.Mvc;
using Tuincentrum.Models;

namespace Tuincentrum.Controllers
{
    public class LeverancierController : Controller
    {
        private readonly ILeveranciersRepository leveranciersRepository;
        public LeverancierController(ILeveranciersRepository leveranciersRepository)
        {
            this.leveranciersRepository = leveranciersRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await leveranciersRepository.GetLeveranciers());
        }

        [Route("Leveranciers/{postnr?}")]
        public async Task<IActionResult> FindLeveranciersMetPostNr(string postnr)
        {
            if (postnr == null) return View(nameof(Index), await leveranciersRepository.GetLeveranciers());
            else
            {
                List<Leverancier> leveranciersLijst = await leveranciersRepository.GetLeveranciersMetPostNr(postnr);
                ViewBag.PostNr = postnr;
                return View(leveranciersLijst);
            }
        }
    }
}
