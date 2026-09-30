using Catalogus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Catalogus.Controllers
{
    [Route("artikels"), ApiController]
    public class ArtikelController(Context context):ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string naam)
        {
            using var transactie = await context.Database.BeginTransactionAsync();
            var artikel = new Artikel { Naam = naam };
            await context.Artikels.AddAsync(artikel);
            await context.SaveChangesAsync();
            var artikelGemaakt = new { artikel.Id, Naam = naam };
            var bericht = new TeVersturenBericht
            {
                Exchange = "catalogus",
                Bericht = JsonSerializer.Serialize(artikelGemaakt)
            };
            await context.TeVersturenBerichten.AddAsync(bericht);
            await context.SaveChangesAsync();
            await transactie.CommitAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> FindAll() => Ok(await context.Artikels.AsNoTracking().ToListAsync());
    }
}
