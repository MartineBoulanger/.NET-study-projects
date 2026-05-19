using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Model.Entities
{
    public class EFTakenContext : DbContext
    {
        public static IConfigurationRoot configuration = null!;

        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Rekening> Rekeningen { get; set; }
        public DbSet<Personeelslid> PersoneelsLeden { get; set; }
        public DbSet<ArtikelGroep> ArtikelGroepen { get; set; }
        public DbSet<Artikel> Artikels { get; set; }
        public DbSet<NonFoodArtikel> NonFoodArtikels { get; set; }
        public DbSet<FoodArtikel> FoodArtikels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFBank;Trusted_Connection=true;Encrypt=false", options => options.MaxBatchSize(150));
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFBank;Trusted_Connection=true;Encrypt=false", options => options.MaxBatchSize(150)).UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artikel>().ToTable("Artikels").HasDiscriminator<string>("ArtikelType").HasValue<FoodArtikel>("F").HasValue<NonFoodArtikel>("N");
            modelBuilder.Entity<Klant>().Property(a => a.KlantNr).IsConcurrencyToken();
            modelBuilder.Entity<Klant>().Property(a => a.Voornaam).IsConcurrencyToken();

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
            #region personeelsdata
            modelBuilder.Entity<Personeelslid>().HasData(
                new Personeelslid { PersoneelsNr = 01, Voornaam = "Diane" },
                new Personeelslid { PersoneelsNr = 02, Voornaam = "Mary", ManagerNr = 1 },
                new Personeelslid { PersoneelsNr = 03, Voornaam = "Jeff", ManagerNr = 1 },
                new Personeelslid { PersoneelsNr = 04, Voornaam = "William", ManagerNr = 2 },
                new Personeelslid { PersoneelsNr = 05, Voornaam = "Gerard", ManagerNr = 2 },
                new Personeelslid { PersoneelsNr = 06, Voornaam = "Anthony", ManagerNr = 2 },
                new Personeelslid { PersoneelsNr = 07, Voornaam = "Leslie", ManagerNr = 6 },
                new Personeelslid { PersoneelsNr = 08, Voornaam = "July", ManagerNr = 6 },
                new Personeelslid { PersoneelsNr = 09, Voornaam = "Steve", ManagerNr = 6 },
                new Personeelslid { PersoneelsNr = 10, Voornaam = "Foon Yue", ManagerNr = 6 },
                new Personeelslid { PersoneelsNr = 11, Voornaam = "George", ManagerNr = 6 },
                new Personeelslid { PersoneelsNr = 12, Voornaam = "Loui", ManagerNr = 5 },
                new Personeelslid { PersoneelsNr = 13, Voornaam = "Pamela", ManagerNr = 5 },
                new Personeelslid { PersoneelsNr = 14, Voornaam = "Larry", ManagerNr = 5 },
                new Personeelslid { PersoneelsNr = 15, Voornaam = "Barry", ManagerNr = 5 },
                new Personeelslid { PersoneelsNr = 16, Voornaam = "Andy", ManagerNr = 4 },
                new Personeelslid { PersoneelsNr = 17, Voornaam = "Peter", ManagerNr = 4 },
                new Personeelslid { PersoneelsNr = 18, Voornaam = "Tom", ManagerNr = 4 },
                new Personeelslid { PersoneelsNr = 19, Voornaam = "Mami", ManagerNr = 2 },
                new Personeelslid { PersoneelsNr = 20, Voornaam = "Yoshimi", ManagerNr = 19 },
                new Personeelslid { PersoneelsNr = 21, Voornaam = "Martin", ManagerNr = 5 }
            );
            #endregion
        }
    }
}
