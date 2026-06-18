using BrouwerService.DTOs;
using BrouwerService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BrouwerService.Controllers
{
    [Route("filialen"), ApiController]
    public class FiliaalController(IFiliaalRepository repository):ControllerBase
    {
        [HttpGet]
        //public async Task<ActionResult> FindAll() => base.Ok(await repository.FindAllAsync());
        public async Task<ActionResult> FindAll()
        {
            var filialen = await repository.FindAllAsync();
            var filiaalDTOs = filialen.Select(f => new FiliaalDTO(f.Id, f.Naam, f.Woonplaats.Postcode, f.Woonplaats.Naam));
            return base.Ok(filiaalDTOs);
        }
    }
}
