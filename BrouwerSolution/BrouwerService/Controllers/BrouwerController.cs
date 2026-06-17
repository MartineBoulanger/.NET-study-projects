using BrouwerService.Models;
using BrouwerService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BrouwerService.Controllers
{
    [Route("brouwers")]
    [ApiController]
    public class BrouwerController(IBrouwerRepository repository):ControllerBase
    {
        [HttpGet]
        public ActionResult FindAll() => base.Ok(repository.FindAll());

        [HttpGet("{id}")]
        public ActionResult FindById(int id) => repository.FindById(id) is Brouwer brouwer ? base.Ok(brouwer) : base.NotFound(); // verkorte versie
        // normale versie hieronder
        //{
        //    var brouwer = repository.FindById(id);
        //    return brouwer == null ? base.NotFound() : base.Ok(brouwer);
        //}

        [HttpGet("naam")]
        public ActionResult FindByBeginNaam(string begin) => base.Ok(repository.FindByBeginNaam(begin));
    }
}
