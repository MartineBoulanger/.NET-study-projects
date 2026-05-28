using Microsoft.AspNetCore.Mvc;
using Tuincentrum.Models;

namespace Tuincentrum.Controllers
{
    public class LeverancierController:Controller
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
    }
}
