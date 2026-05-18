using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Model.Entities;
using Model.Services;

namespace Tests
{
    [TestClass]
    public class UnitTestsSqlite
    {
        DbContextOptions<EFOpleidingenContext> options;
        SqliteConnection connection;

        [TestInitialize]
        public void Initialize()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            connection = new SqliteConnection(connectionStringBuilder.ToString());
            options = new DbContextOptionsBuilder<EFOpleidingenContext>().UseSqlite(connection).Options;
            connection.Open();
            using var context = new EFOpleidingenContext(options);
            context.Database.EnsureCreated();
        }

        [TestMethod]
        public void GetDocentenVoorCampus_Docenten_AantalIsZesDocenten()
        {
            connection.Open();
            using var context = new EFOpleidingenContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Toevoegen land
            context.Landen.Add(new Land() { LandCode = "BE", Naam = "België" });

            // Toevoegen campussen
            context.Campussen.Add(new Campus()
            {
                CampusId = 1,
                Naam = "Andros",
                Adres = new Adres
                {
                    Straat = "Somersstraat",
                    Huisnummer = "22",
                    Postcode = "2018",
                    Gemeente = "Antwerpen"
                }
            });
            context.Campussen.Add(new Campus()
            {
                CampusId = 2,
                Naam = "Delos",
                Adres = new Adres
                {
                    Straat = "Oude Vest",
                    Huisnummer = "17",
                    Postcode = "9200",
                    Gemeente = "Dendermonde"
                }
            });

            // Toevoegen docenten
            context.Docenten.Add(new Docent()
            {
                DocentId = 001,
                Voornaam = "Willy",
                Familienaam = "Abbeloos",
                Wedde = 1500m,
                HeeftRijbewijs = new Nullable<bool>(),
                InDienst = new DateTime(2019, 1, 1),
                CampusId = 1,
                LandCode = "BE"
            });
            context.Docenten.Add(new Docent()
            {
                DocentId = 002,
                Voornaam = "Joseph",
                Familienaam = "Abelshausen",
                Wedde = 1800m,
                HeeftRijbewijs = true,
                InDienst = new DateTime(2019, 1, 2),
                CampusId = 2,
                LandCode = "BE"
            });
            context.Docenten.Add(new Docent()
            {
                DocentId = 003,
                Voornaam = "Joseph",
                Familienaam = "Achten",
                Wedde = 1300m,
                HeeftRijbewijs = false,
                InDienst = new DateTime(2019, 1, 3),
                CampusId = 1,
                LandCode = "BE"
            });
            context.Docenten.Add(new Docent()
            {
                DocentId = 004,
                Voornaam = "François",
                Familienaam = "Adam",
                Wedde = 1700m,
                HeeftRijbewijs = new Nullable<bool>(),
                InDienst = new DateTime(2019, 1, 4),
                CampusId = 2,
                LandCode = "BE"
            });
            context.Docenten.Add(new Docent()
            {
                DocentId = 005,
                Voornaam = "Jan",
                Familienaam = "Adriaensens",
                Wedde = 2100m,
                HeeftRijbewijs = true,
                InDienst = new DateTime(2019, 1, 5),
                CampusId = 1,
                LandCode = "BE"
            });
            context.Docenten.Add(new Docent()
            {
                DocentId = 006,
                Voornaam = "René",
                Familienaam = "Adriaensens",
                Wedde = 1600m,
                HeeftRijbewijs = false,
                InDienst = new DateTime(2019, 1, 6),
                CampusId = 2,
                LandCode = "BE"
            });
            context.Docenten.Add(new Docent()
            {
                DocentId = 007,
                Voornaam = "Frans",
                Familienaam = "Aerenhouts",
                Wedde = 1300m,
                HeeftRijbewijs = new Nullable<bool>(),
                InDienst = new DateTime(2019, 1, 7),
                CampusId = 1,
                LandCode = "BE"
            });
            context.Docenten.Add(new Docent()
            {
                DocentId = 008,
                Voornaam = "Emile",
                Familienaam = "Aerts",
                Wedde = 1700m,
                HeeftRijbewijs = true,
                InDienst = new DateTime(2019, 1, 8),
                CampusId = 1,
                LandCode = "BE"
            });
            context.Docenten.Add(new Docent()
            {
                DocentId = 009,
                Voornaam = "Jean",
                Familienaam = "Aerts",
                Wedde = 1200m,
                HeeftRijbewijs = false,
                InDienst = new DateTime(2019, 1, 9),
                CampusId = 2,
                LandCode = "BE" // (4)
            });
            context.Docenten.Add(new Docent()
            {
                DocentId = 010,
                Voornaam = "Mario",
                Familienaam = "Aerts",
                Wedde = 1600m,
                HeeftRijbewijs = new Nullable<bool>(),
                InDienst = new DateTime(2019, 1, 10),
                CampusId = 1,
                LandCode = "BE"
            });

            context.SaveChanges();

            var docentService = new DocentService(context);
            var docenten = docentService.GetDocentenVoorCampus(1);
            Assert.AreEqual(6, docenten.Count());
        }

        [TestMethod]
        public void GetDocent_Docent0_ThrowArgumentException()
        {
            connection.Open();
            using var context = new EFOpleidingenContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var docentService = new DocentService(context);
            Assert.Throws<ArgumentException>(() => docentService.GetDocent(0));
        }

        [TestMethod]
        public void ToevoegenDocent_DocentZonderLand_DocentHeeftLandBE()
        {
            connection.Open();
            using var context = new EFOpleidingenContext(options);
            context.Database.EnsureDeleted(); // verwijder bestaande test database
            context.Database.EnsureCreated(); // maak een nieuwe test database
            context.Landen.Add(new Land() { LandCode = "BE", Naam = "België" });
            context.Campussen.Add(new Campus()
            {
                CampusId = 1,
                Naam = "Andros",
                Adres = new Adres
                {
                    Straat = "Somersstraat",
                    Huisnummer = "22",
                    Postcode = "2018",
                    Gemeente = "Antwerpen"
                }
            });
            context.SaveChanges();
            var docentService = new DocentService(context);
            var docent = new Docent()
            {
                DocentId = 20,
                Voornaam = "Fanny",
                Familienaam = "Kiekeboe",
                Wedde = 10100m,
                InDienst = new DateTime(2019, 1, 1),
                CampusId = 1
            };
            docentService.ToevoegenDocent(docent);
            context.SaveChanges();

            var docent1 = docentService.GetDocent(20);
            Assert.AreEqual("BE", docent1.LandCode);
        }
    }
}
