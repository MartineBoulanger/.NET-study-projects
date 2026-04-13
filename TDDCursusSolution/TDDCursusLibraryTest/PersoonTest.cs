using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class PersoonTest
    {
        // lokale helper method vanwege DRY
        private Persoon MaakPersoon(params string[] voornamen) => new Persoon(voornamen.ToList());

        // Tests voor requirement: Een persoon heeft minstens één voornaam.
        [TestMethod]
        public void MetEenVoornaam_Maakt_Persoon()
        {
            var persoon = MaakPersoon("Gert");
            Assert.AreEqual("Gert", persoon.ToString());
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
        public void MetEmptyList_Geeft_Fout()
        {
            Assert.Throws<ArgumentException>(() => new Persoon(new List<string>()));
        }

        [TestMethod]
        public void MetNull_Geeft_fout()
        {
            Assert.Throws<ArgumentNullException>(() => new Persoon(null!));
        }

        // Tests voor requirement: Een persoon kan geen twee keer dezelfde voornaam hebben.
        [TestMethod]
        public void MetMeerdereUniekeVoornamen_Maakt_Persoon()
        {
            var persoon = MaakPersoon("Gert", "Samson", "Roberto");
            Assert.AreEqual("Gert Samson Roberto", persoon.ToString());
        }

        [TestMethod]
        public void MetTweeDezelfdeVoornamen_Geeft_Fout()
        {
            var persoon = MaakPersoon("Gert", "Samson", "Gert");
            Assert.Throws<ArgumentException>(() => persoon.ToString());
        }

        // Tests voor requirement: Iedere voornaam moet minstens één teken bevatten.
        [TestMethod]
        public void MetEenInitiaal_Maakt_Persoon()
        {
            var persoon = MaakPersoon("G");
            Assert.AreEqual("G", persoon.ToString());
        }

        [TestMethod]
        public void MetMeerdereInitialen_Maakt_Persoon()
        {
            var persoon = MaakPersoon("G", "S", "R");
            Assert.AreEqual("G S R", persoon.ToString());
        }

        [TestMethod]
        public void MetInitialenEnVoornamen_Maakt_Persoon()
        {
            var persoon = MaakPersoon("G", "Samson", "R");
            Assert.AreEqual("G Samson R", persoon.ToString());
        }

        [TestMethod]
        public void MetLegeStringInVoornamen_Geeft_Fout()
        {
            var persoon = MaakPersoon("Gert", "", "Samson");
            Assert.Throws<ArgumentException>(() => persoon.ToString());
        }

        [TestMethod]
        public void MetEenSpatieInEenLegeStringInVoornamen_Geeft_Fout()
        {
            var persoon = MaakPersoon("Gert", " ", "Samson");
            Assert.Throws<ArgumentException>(() => persoon.ToString());
        }
    }
}
