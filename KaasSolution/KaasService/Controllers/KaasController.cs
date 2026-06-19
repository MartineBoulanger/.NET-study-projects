using KaasService.Models;
using KaasService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KaasService.Controllers
{
    [Route("kazen"), ApiController]
    public class KaasController(IKaasRepository repository):ControllerBase
    {
        [HttpGet]
        //public ActionResult FindAll() => base.Ok(repository.FindAll());
        public async Task<ActionResult> FindAll() => base.Ok(await repository.FindAllAsync());

        [HttpGet("{id}")]
        //public ActionResult FindById(int id) => repository.FindById(id) is Kaas kaas ? base.Ok(kaas) : base.NotFound();
        public async Task<ActionResult> FindById(int id) => await repository.FindByIdAsync(id) is Kaas kaas ? base.Ok(kaas) : base.NotFound();

        [HttpGet("smaken")]
        //public ActionResult FindBySmaak(string smaak) => base.Ok(repository.FindBySmaak(smaak));
        public async Task<ActionResult> FindBySmaak(string smaak) => base.Ok(await repository.FindBySmaakAsync(smaak));

        [HttpPost]
        //public ActionResult Post(Kaas kaas)
        public async Task<ActionResult> Post(Kaas kaas)
        {
            //repository.Insert(kaas);
            await repository.InsertAsync(kaas);
            return base.CreatedAtAction(nameof(FindById), new { id = kaas.Id }, null);
        }

        [HttpDelete("{id}")]
        //public ActionResult Delete(int id)
        public async Task<ActionResult> Delete(int id)
        {
            //var kaas = repository.FindById(id);
            var kaas = await repository.FindByIdAsync(id);
            if (kaas == null)
                return base.NotFound();
            //repository.Delete(kaas);
            await repository.DeleteAsync(kaas);
            return base.Ok();
        }

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
