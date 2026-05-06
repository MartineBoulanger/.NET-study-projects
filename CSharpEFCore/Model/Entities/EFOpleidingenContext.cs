using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Model.Entities
{
    public class EFOpleidingenContext : DbContext
    {
        public static IConfigurationRoot? configuration;

        // entity collections
        public DbSet<Campus> Campussen { get; set; }
        public DbSet<Docent> Docenten { get; set; }
        public DbSet<Land> Landen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // connectionstring hardcoded
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFOpleidingen;Trusted_Connection=true;encrypt=false", options => options.MaxBatchSize(150));
            // connection string ophalen uit the configuratie bestand
            //var parent = Directory.GetParent(AppContext.BaseDirectory)?.FullName;
            //configuration = new ConfigurationBuilder().SetBasePath(parent ?? null!).AddJsonFile("appsettings.json", false).Build();
            //var connectionString = configuration.GetConnectionString("EFOpleidingen");
            //if (connectionString != null) optionsBuilder.UseSqlServer(connectionString, options => options.MaxBatchSize(150));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campus>().HasKey(c => c.CampusId);

            // seeding
            #region campusdata
            modelBuilder.Entity<Campus>().HasData(
                new Campus { CampusId = 1, Naam = "Andros", Straat = "Somersstraat", Huisnummer = "22", Postcode = "2018", Gemeente = "Antwerpen" },
                new Campus { CampusId = 2, Naam = "Delos", Straat = "Industrieweg", Huisnummer = "50", Postcode = "9032", Gemeente = "Wondelgem" },
                new Campus { CampusId = 3, Naam = "Gavdos", Straat = "Europalaan", Huisnummer = "37", Postcode = "3600", Gemeente = "Genk" },
                new Campus { CampusId = 4, Naam = "Hydra", Straat = "Interleuvenlaan", Huisnummer = "2", Postcode = "3001", Gemeente = "Heverlee" },
                new Campus { CampusId = 5, Naam = "Ikaria", Straat = "Vlamingstraat", Huisnummer = "10", Postcode = "8560", Gemeente = "Wevelgem" },
                new Campus { CampusId = 6, Naam = "Oinouses", Straat = "Akkerstraat", Huisnummer = "4", Postcode = "8400", Gemeente = "Oostende" }
            );
            #endregion
            #region landdata
            modelBuilder.Entity<Land>().HasData(
                new Land { LandCode = "BE", Naam = "België" },
                new Land { LandCode = "NL", Naam = "Nederland" },
                new Land { LandCode = "DE", Naam = "Duitsland" },
                new Land { LandCode = "FR", Naam = "Frankrijk" },
                new Land { LandCode = "IT", Naam = "Italië" },
                new Land { LandCode = "LU", Naam = "Luxemburg" },
                new Land { LandCode = "GB", Naam = "Groot-Brittannië" }
            );
            #endregion
            #region docentdata
            modelBuilder.Entity<Docent>().HasData(
                new Docent { DocentId = 001, Voornaam = "Willy", Familienaam = "Abbeloos", Wedde = 1400m, HeeftRijbewijs = new Nullable<bool>(), InDienst = new DateTime(2019, 1, 1), CampusId = 4, LandCode = "BE" },
                new Docent { DocentId = 002, Voornaam = "Joseph", Familienaam = "Abelshausen", Wedde = 1800m, HeeftRijbewijs = true, InDienst = new DateTime(2019, 1, 2), CampusId = 2, LandCode = "BE" },
                new Docent { DocentId = 003, Voornaam = "Joseph", Familienaam = "Achten", Wedde = 1300m, HeeftRijbewijs = false, InDienst = new DateTime(2019, 1, 3), CampusId = 3, LandCode = "BE" },
                new Docent { DocentId = 004, Voornaam = "Francois", Familienaam = "Adam", Wedde = 1700m, HeeftRijbewijs = new Nullable<bool>(), InDienst = new DateTime(2019, 1, 4), CampusId = 1, LandCode = "BE" }
            );
            #endregion
        }
    }
}
