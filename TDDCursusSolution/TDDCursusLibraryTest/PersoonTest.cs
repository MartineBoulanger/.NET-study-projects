using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class PersoonTest
    {
        // lokale helper method vanwege DRY
        private static Persoon MaakPersoon(params string[] voornamen) => new([.. voornamen]);

        // Tests voor requirements: Een persoon heeft minstens één voornaam of iedere voornaam moet minstens één teken bevatten.
        [DataRow("Gert")]
        [DataRow("Samson")]
        [DataRow("Roberto")]
        [DataRow("G")]                          // testen voor requirement: Iedere voornaam moet minstens één teken bevatten.
        [TestMethod]
        public void MetEenVoornaam_OfInitiaal_Maakt_Persoon(string voornaam)
        {
            var persoon = MaakPersoon(voornaam);
            Assert.AreEqual(voornaam, persoon.ToString());
        }

        [DataRow("Gert", "Samson")]
        [DataRow("Gert", "Samson", "Roberto")]
        [DataRow("Gert", "Samson", "Roberto", "Marie")]
        [DataRow("Gert", "Samson", "Roberto", "Marie", "Walter")]
        [DataRow("G", "S")]                     // testen voor requirement: Iedere voornaam moet minstens één teken bevatten.
        [DataRow("G", "S", "R")]
        [DataRow("G", "S", "R", "M")]
        [DataRow("G", "S", "R", "M", "W")]
        [DataRow("G", "Samson", "R")]           // variatie met initialen en volledige voornamen
        [TestMethod]
        public void MetMeerdereVoornamen_OfMeerdereInitialen_Maakt_Persoon(params string[] voornamen)
        {
            var persoon = MaakPersoon(voornamen);
            Assert.AreEqual(string.Join(" ", voornamen), persoon.ToString());
        }

        // grenswaarde testen voor requirement: Een persoon heeft minstens één voornaam.
        [TestMethod]
        public void MetEenLangeVoornaam_Maakt_Persoon()
        {
            var langeNaam = new string('A', 1000);
            var persoon = MaakPersoon(langeNaam);
            Assert.AreEqual(langeNaam, persoon.ToString());
        }

        [TestMethod]
        public void MetHeelVeelVoornamen_Maakt_Persoon()
        {
            var veelVoornamen = Enumerable.Range(1, 100).Select(i => $"Naam{i}").ToArray();
            var persoon = MaakPersoon(veelVoornamen);
            Assert.AreEqual(string.Join(" ", veelVoornamen), persoon.ToString());
        }

        // Tests voor requirement: Een persoon heeft minstens één voornaam. -- foutieve gevallen
        [TestMethod]
        public void MetEmptyList_Geeft_Fout()
        {
            var persoon = new List<string>();
            Assert.Throws<ArgumentException>(() => new Persoon(persoon));
        }

        [TestMethod]
        public void MetNull_Geeft_fout()
        {
            Assert.Throws<ArgumentNullException>(() => new Persoon(null!));
        }

        // Tests voor requirement: Een persoon kan geen twee keer dezelfde voornaam hebben.
        [DataRow("Gert", "Samson", "Gert")]    // Dubbele Gert
        [DataRow("Gert", "Gert", "Gert")]      // Allemaal Gert
        [DataRow("Gert", "Samson", "Samson")]  // Dubbele Samson
        [TestMethod]
        public void MetDubbeleVoornamen_Geeft_Fout(params string[] voornamen)
        {
            Assert.Throws<ArgumentException>(() => new Persoon([.. voornamen]));
        }

        // Tests voor requirement: Iedere voornaam moet minstens één teken bevatten. -- foutieve gevallen
        [DataRow("Gert", "", "Samson")]        // lege string als tweede voornaam
        [DataRow("Gert", " ", "Samson")]       // string met alleen een spatie ertussen
        [DataRow("Gert", "\t", "Samson")]      // string met alleen een tab ertussen
        [DataRow("Gert", "\n", "Samson")]      // string met alleen een new line ertussen
        [DataRow("")]                          // lege string als voornaam
        [DataRow(" ")]                         // string met alleen spaties als voornaam
        [DataRow("  ")]                        // string met alleen spaties als voornaam
        [TestMethod]
        public void MetLege_OfSpaties_InVoornamen_Geeft_Fout(params string[] voornamen)
        {
            Assert.Throws<ArgumentException>(() => new Persoon([.. voornamen]));
        }
    }
}
