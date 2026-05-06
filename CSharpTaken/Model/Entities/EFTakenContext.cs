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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding
            #region klantdata
            modelBuilder.Entity<Klant>().HasData(
                new Klant { KlantNr = 1, Voornaam = "Marge" },
                new Klant { KlantNr = 2, Voornaam = "Homer" },
                new Klant { KlantNr = 3, Voornaam = "Lisa" },
                new Klant { KlantNr = 4, Voornaam = "Maggie" },
                new Klant { KlantNr = 5, Voornaam = "Bart" }
            );
            #endregion
            #region rekeningdata
            modelBuilder.Entity<Rekening>().HasData(
                new Rekening { RekeningNr = "BE12-4567-8900-0212", KlantNr = 1, Saldo = 1000m, Soort = 'Z' },
                new Rekening { RekeningNr = "BE23-4567-8901-6954", KlantNr = 1, Saldo = 1000m, Soort = 'S' },
                new Rekening { RekeningNr = "BE34-5678-9012-1214", KlantNr = 2, Saldo = 1000m, Soort = 'S' }
            );
            #endregion
        }
    }
}
