using Microsoft.EntityFrameworkCore;

namespace Model.Entities
{
    public class EFEindoefeningContext:DbContext
    {
        // DbSets van de entities
        public DbSet<Land> Landen { get; set; }
        public DbSet<Stad> Steden { get; set; }
        public DbSet<Taal> Talen { get; set; }
        public DbSet<LandTaal> LandenTalen { get; set; }

        // configuratie van de database connectie
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFEindoefening;Trusted_Connection=true;Encrypt=false;", options => options.MaxBatchSize(150));
            }
        }

        // model creatie en configuratie van de relaties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // samengestelde PK voor LandTaal entiteit
            modelBuilder.Entity<LandTaal>().HasKey(l => new { l.LandCode, l.TaalCode });
            // configuratie van de relaties tussen Land, Taal en LandTaal
            modelBuilder.Entity<LandTaal>().HasOne(l => l.Land).WithMany(l => l.LandTalen).HasForeignKey(l => l.LandCode);
            modelBuilder.Entity<LandTaal>().HasOne(l => l.Taal).WithMany(l => l.LandTalen).HasForeignKey(l => l.TaalCode);
            // configuratie van de relatie tussen Land en Stad
            modelBuilder.Entity<Stad>().HasOne(s => s.Land).WithMany(s => s.Steden).HasForeignKey(s => s.ISOLandCode);
            // unieke indexen op de eniteiten
            modelBuilder.Entity<Land>().HasIndex(l => l.NISLandCode).IsUnique();
            modelBuilder.Entity<Land>().HasIndex(l => l.Naam).IsUnique();
            modelBuilder.Entity<Stad>().HasIndex(s => s.Naam).IsUnique();
            modelBuilder.Entity<Taal>().HasIndex(s => s.NaamNL).IsUnique();
            modelBuilder.Entity<Taal>().HasIndex(s => s.NaamTaal).IsUnique();

            // data seeding
            #region landenData
            modelBuilder.Entity<Land>().HasData(
                new Land { ISOLandCode = "AT", NISLandCode = "105", Naam = "Oostenrijk", AantalInwoners = 8754413, Oppervlakte = 83871f },
                new Land { ISOLandCode = "BE", NISLandCode = "150", Naam = "België", AantalInwoners = 11500000, Oppervlakte = 30689f },
                new Land { ISOLandCode = "CH", NISLandCode = "127", Naam = "Zwitserland", AantalInwoners = 8236303, Oppervlakte = 41285f },
                new Land { ISOLandCode = "DE", NISLandCode = "103", Naam = "Duitsland", AantalInwoners = 80594017, Oppervlakte = 357022f },
                new Land { ISOLandCode = "DK", NISLandCode = "108", Naam = "Denemarken", AantalInwoners = 5605948, Oppervlakte = 43094f },
                new Land { ISOLandCode = "ES", NISLandCode = "109", Naam = "Spanje", AantalInwoners = 48958159, Oppervlakte = 505992f },
                new Land { ISOLandCode = "FR", NISLandCode = "111", Naam = "Frankrijk", AantalInwoners = 62814233, Oppervlakte = 674843f },
                new Land { ISOLandCode = "GB", NISLandCode = "112", Naam = "Verenigd Koninkrijk", AantalInwoners = 64769452, Oppervlakte = 242495f },
                new Land { ISOLandCode = "IT", NISLandCode = "128", Naam = "Italië", AantalInwoners = 62137802, Oppervlakte = 300000f },
                new Land { ISOLandCode = "LU", NISLandCode = "113", Naam = "Luxemburg", AantalInwoners = 594130, Oppervlakte = 2586f },
                new Land { ISOLandCode = "NL", NISLandCode = "129", Naam = "Nederland", AantalInwoners = 17424978, Oppervlakte = 41873f },
                new Land { ISOLandCode = "NO", NISLandCode = "121", Naam = "Noorwegen", AantalInwoners = 5367580, Oppervlakte = 385207f },
                new Land { ISOLandCode = "PL", NISLandCode = "139", Naam = "Polen", AantalInwoners = 38476269, Oppervlakte = 311888f },
                new Land { ISOLandCode = "PT", NISLandCode = "123", Naam = "Portugal", AantalInwoners = 10839541, Oppervlakte = 92212f },
                new Land { ISOLandCode = "SE", NISLandCode = "126", Naam = "Zweden", AantalInwoners = 9960487, Oppervlakte = 450295f },
                new Land { ISOLandCode = "UA", NISLandCode = "380", Naam = "Oekraïne", AantalInwoners = 43922939, Oppervlakte = 603500f },
                new Land { ISOLandCode = "US", NISLandCode = "402", Naam = "Verenigde Staten", AantalInwoners = 326625791, Oppervlakte = 9826675f }
            );
            #endregion
            #region talenData
            modelBuilder.Entity<Taal>().HasData(
                new Taal { ISOTaalCode = "bg", NaamNL = "Bulgaars", NaamTaal = "български" },
                new Taal { ISOTaalCode = "cs", NaamNL = "Tsjechisch", NaamTaal = "čeština" },
                new Taal { ISOTaalCode = "da", NaamNL = "Deens", NaamTaal = "dansk" },
                new Taal { ISOTaalCode = "de", NaamNL = "Duits", NaamTaal = "Deutsch" },
                new Taal { ISOTaalCode = "el", NaamNL = "Grieks", NaamTaal = "ελληνικά" },
                new Taal { ISOTaalCode = "en", NaamNL = "Engels", NaamTaal = "English" },
                new Taal { ISOTaalCode = "es", NaamNL = "Spaans", NaamTaal = "español" },
                new Taal { ISOTaalCode = "et", NaamNL = "Ests", NaamTaal = "eesti keel" },
                new Taal { ISOTaalCode = "fi", NaamNL = "Fins", NaamTaal = "suomi" },
                new Taal { ISOTaalCode = "fr", NaamNL = "Frans", NaamTaal = "français" },
                new Taal { ISOTaalCode = "ga", NaamNL = "Iers", NaamTaal = "Gaeilge" },
                new Taal { ISOTaalCode = "hu", NaamNL = "Hongaars", NaamTaal = "magyar" },
                new Taal { ISOTaalCode = "it", NaamNL = "Italiaans", NaamTaal = "italiano" },
                new Taal { ISOTaalCode = "lt", NaamNL = "Litouws", NaamTaal = "lietuvių kalba" },
                new Taal { ISOTaalCode = "lv", NaamNL = "Lets", NaamTaal = "latviešu valoda" },
                new Taal { ISOTaalCode = "mt", NaamNL = "Maltees", NaamTaal = "malti" },
                new Taal { ISOTaalCode = "nl", NaamNL = "Nederlands", NaamTaal = "Nederlands" },
                new Taal { ISOTaalCode = "pl", NaamNL = "Pools", NaamTaal = "polski" },
                new Taal { ISOTaalCode = "pt", NaamNL = "Portugees", NaamTaal = "português" },
                new Taal { ISOTaalCode = "ro", NaamNL = "Roemeens", NaamTaal = "română" },
                new Taal { ISOTaalCode = "sk", NaamNL = "Slovaaks", NaamTaal = "slovenčina" },
                new Taal { ISOTaalCode = "sl", NaamNL = "Sloveens", NaamTaal = "slovenščina" },
                new Taal { ISOTaalCode = "sv", NaamNL = "Zweeds", NaamTaal = "svenska" },
                new Taal { ISOTaalCode = "uk", NaamNL = "Oekraïens", NaamTaal = "Soerzjyk" }
            );
            #endregion
            #region stedenData
            modelBuilder.Entity<Stad>().HasData(
                new Stad { StadId = 1, Naam = "Brussel", ISOLandCode = "BE" },
                new Stad { StadId = 2, Naam = "Antwerpen", ISOLandCode = "BE" },
                new Stad { StadId = 3, Naam = "Luik", ISOLandCode = "BE" },
                new Stad { StadId = 4, Naam = "Amsterdam", ISOLandCode = "NL" },
                new Stad { StadId = 5, Naam = "Den Haag", ISOLandCode = "NL" },
                new Stad { StadId = 6, Naam = "Rotterdam", ISOLandCode = "NL" },
                new Stad { StadId = 7, Naam = "Berlijn", ISOLandCode = "DE" },
                new Stad { StadId = 8, Naam = "Hamburg", ISOLandCode = "DE" },
                new Stad { StadId = 9, Naam = "München", ISOLandCode = "DE" },
                new Stad { StadId = 10, Naam = "Luxemburg", ISOLandCode = "LU" },
                new Stad { StadId = 11, Naam = "Parijs", ISOLandCode = "FR" },
                new Stad { StadId = 12, Naam = "Marseille", ISOLandCode = "FR" },
                new Stad { StadId = 13, Naam = "Lyon", ISOLandCode = "FR" }
            );
            #endregion
            #region landenTalenData
            modelBuilder.Entity<LandTaal>().HasData(
                new LandTaal { LandCode = "BE", TaalCode = "de" },
                new LandTaal { LandCode = "DE", TaalCode = "de" },
                new LandTaal { LandCode = "LU", TaalCode = "de" },
                new LandTaal { LandCode = "BE", TaalCode = "fr" },
                new LandTaal { LandCode = "FR", TaalCode = "fr" },
                new LandTaal { LandCode = "LU", TaalCode = "fr" },
                new LandTaal { LandCode = "BE", TaalCode = "nl" },
                new LandTaal { LandCode = "NL", TaalCode = "nl" }
            );
            #endregion
        }
    }
}
