using KaasService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KaasService.Controllers
{
    [Route("kazen")]
    [ApiController]
    public class KaasController(IKaasRepository repository):ControllerBase
    {
    }
}
