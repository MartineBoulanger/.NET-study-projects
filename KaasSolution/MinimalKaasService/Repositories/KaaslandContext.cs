using Microsoft.EntityFrameworkCore;
using MinimalKaasService.Models;

namespace MinimalKaasService.Repositories
{
    public class KaaslandContext(DbContextOptions<KaaslandContext> options):DbContext(options)
    {
        public required DbSet<Kaas> Kazen { get; set; }
    }
}
