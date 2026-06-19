using KaasService.Models;
using Microsoft.EntityFrameworkCore;

namespace KaasService.Repositories
{
    public class KaaslandContext(DbContextOptions<KaaslandContext> options):DbContext(options)
    {
        public required DbSet<Kaas> Kazen { get; set; }
    }
}
