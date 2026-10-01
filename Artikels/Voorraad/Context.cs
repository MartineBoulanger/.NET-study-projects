using Microsoft.EntityFrameworkCore;
using Voorraad.Models;

namespace Voorraad
{
    public class Context(DbContextOptions<Context> options):DbContext(options)
    {
        public required DbSet<Artikel> Artikels { init; get; }
    }
}
