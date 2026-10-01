using Aankopen.Models;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text.Json;

namespace Aankopen.Controllers
{
    [Route("aankopen"), ApiController]
    public class AankoopController(Context context, IChannel channel):ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post(Aankoop aankoop)
        {
            await context.Aankopen.AddAsync(aankoop);
            await context.SaveChangesAsync();
            var aankoopGedaan = new { aankoop.Id, aankoop.ArtikelId, aankoop.Aantal };
            var inBytes = JsonSerializer.SerializeToUtf8Bytes(aankoopGedaan);
            await channel.BasicPublishAsync("aankopen", string.Empty, inBytes);
            return Ok();
        }
    }
}
