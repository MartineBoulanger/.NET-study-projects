using BrouwerService.Models;
using BrouwerService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrouwerService.Controllers
{
    [Route("brouwers")]
    [ApiController]
    public class BrouwerController(IBrouwerRepository repository):ControllerBase
    {
        [HttpGet]
        //public ActionResult FindAll() => base.Ok(repository.FindAll());
        public async Task<ActionResult> FindAll() => base.Ok(await repository.FindAllAsync());

        [HttpGet("{id}")]
        //public ActionResult FindById(int id) => repository.FindById(id) is Brouwer brouwer ? base.Ok(brouwer) : base.NotFound(); // verkorte versie
        public async Task<ActionResult> FindById(int id) => await repository.FindByIdAsync(id) is Brouwer brouwer ? base.Ok(brouwer) : base.NotFound(); // verkorte versie
        // normale versie hieronder
        //{
        //    var brouwer = repository.FindById(id);
        //    return brouwer == null ? base.NotFound() : base.Ok(brouwer);
        //}

        [HttpGet("naam")]
        //public ActionResult FindByBeginNaam(string begin) => base.Ok(repository.FindByBeginNaam(begin));
        public async Task<ActionResult> FindByBeginNaam(string begin) => base.Ok(await repository.FindByBeginNaamAsync(begin));

        [HttpDelete("{id}")]
        //public ActionResult Delete(int id)
        //{
        //    var brouwer = repository.FindById(id);
        //    if (brouwer == null)
        //        return base.NotFound();
        //    repository.Delete(brouwer);
        //    return base.Ok();
        //}
        public async Task<ActionResult> Delete(int id)
        {
            var brouwer = await repository.FindByIdAsync(id);
            if (brouwer == null)
                return base.NotFound();
            await repository.DeleteAsync(brouwer);
            return base.Ok();
        }

        [HttpPost]
        //public ActionResult Post(Brouwer brouwer)
        //{
        //    repository.Insert(brouwer);
        //    return base.CreatedAtAction(nameof(FindById), new { id = brouwer.Id }, null);
        //}
        public async Task<ActionResult> Post(Brouwer brouwer)
        {
            await repository.InsertAsync(brouwer);
            return base.CreatedAtAction(nameof(FindById), new { id = brouwer.Id }, null);
        }

        [HttpPut("{id}")]
        //public ActionResult Put(int id, Brouwer brouwer)
        //{
        //    try
        //    {
        //        brouwer.Id = id;
        //        repository.Update(brouwer);
        //        return base.Ok();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        return base.NotFound();
        //    }
        //    catch
        //    {
        //        return base.Problem();
        //    }
        //}
        public async Task<ActionResult> Put(int id, Brouwer brouwer)
        {
            try
            {
                brouwer.Id = id;
                await repository.UpdateAsync(brouwer);
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
