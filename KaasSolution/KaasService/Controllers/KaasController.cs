using KaasService.Models;
using KaasService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KaasService.Controllers
{
    [Route("kazen")]
    [ApiController]
    public class KaasController(IKaasRepository repository):ControllerBase
    {
        [HttpGet]
        public ActionResult FindAll() => base.Ok(repository.FindAll());

        [HttpGet("{id}")]
        public ActionResult FindById(int id) => repository.FindById(id) is Kaas kaas ? base.Ok(kaas) : base.NotFound();

        [HttpGet("naam")]
        public ActionResult FindByBeginNaam(string begin) => base.Ok(repository.FindByBeginNaam(begin));
    }
}
