using KaasService.Models;
using KaasService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KaasService.Controllers
{
    [Route("kazen")]
    [ApiController]
    public class KaasController(IKaasRepository repository):ControllerBase
    {
        [HttpGet]
        //public ActionResult FindAll() => base.Ok(repository.FindAll());
        public async Task<ActionResult> FindAll() => base.Ok(await repository.FindAllAsync());

        [HttpGet("{id}")]
        //public ActionResult FindById(int id) => repository.FindById(id) is Kaas kaas ? base.Ok(kaas) : base.NotFound();
        public async Task<ActionResult> FindById(int id) => await repository.FindByIdAsync(id) is Kaas kaas ? base.Ok(kaas) : base.NotFound();

        [HttpGet("naam")]
        //public ActionResult FindByBeginNaam(string begin) => base.Ok(repository.FindByBeginNaam(begin));
        public async Task<ActionResult> FindByBeginNaam(string begin) => base.Ok(await repository.FindByBeginNaamAsync(begin));

        [HttpPut("{id}")]
        //public ActionResult Put(int id, Kaas kaas)
        public async Task<ActionResult> Put(int id, Kaas kaas)
        {
            try
            {
                kaas.Id = id;
                //repository.Update(kaas);
                await repository.UpdateAsync(kaas);
                return base.Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return base.NotFound();
            }
            catch
            {
                return base.Problem();
            }
        }
    }
}
