using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Model.Entities
{
    public class EFTakenContext : DbContext
    {
        public static IConfigurationRoot configuration = null!;

        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Rekening> Rekeningen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFBank;Trusted_Connection=true;Encrypt=false", options => options.MaxBatchSize(150));
        }
    }
}
