using Microsoft.AspNetCore.Mvc;
using SterrenbeeldService.Repositories;

namespace SterrenbeeldService.Controllers
{
    [Route("sterrenbeelden"), ApiController]
    public class SterrenbeeldController(ISterrenbeeldRepository repository):ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult> GetAll() => base.Ok(await repository.GetAllAsync());

        [HttpGet("{maand}/{dag}")]
        public async Task<ActionResult> GetSterrenbeeld(int maand, int dag)
        {
            // checked of de dag en maand een geldige combinatie is
            // 2024 was een schrikkeljaar - dit is voor wanneer 29 february wordt gekozen, omdat deze dag alleen in schrikkeljaren voorkomt en dus een geldige combinatie is
            if (!DateTime.TryParse($"2024-{maand}-{dag}", out _))
                return base.BadRequest("De combinatie van de maand en de dag is niet geldig.");
            var sterrenbeeld = await repository.GetSterrenbeeldAsync(maand, dag);
            if (sterrenbeeld == null)
                return base.NotFound();
            return base.Ok(sterrenbeeld.Naam);
        }
    }
}
