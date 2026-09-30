using Catalogus.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalogus
{
    public class Context(DbContextOptions<Context> options):DbContext(options)
    {
        public required DbSet<Artikel> Artikels { get; set; }
        public required DbSet<TeVersturenBericht> TeVersturenBerichten { init; get; }
    }
}
