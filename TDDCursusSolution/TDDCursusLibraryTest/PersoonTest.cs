using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class PersoonTest
    {
        // Tests voor requirement: Een persoon heeft minstens één voornaam. -- foutieve gevallen
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

        // Tests voor requirements: Een persoon heeft minstens één voornaam of bevat minstens één teken.
        // DataRow's hier om verschillende mogelijkheden van voornamen/initialen te testen
        [DataRow("Gert")] // één voornaam
        [DataRow("Gert", "samson")] // meerdere voornamen
        [DataRow("G")] // één initiaal
        [DataRow("G", "S", "r")] // meerdere initialen
        [DataRow("G", "Samson", "R")] // variatie van initialen en volledige voornamen
        [TestMethod]
        public void MetEénOfMeerdereVoornamen_OfInitialen_Maakt_Persoon(params string[] voornamen)
        {
            new Persoon([.. voornamen]);
        }

        // Test voor requirement: Een persoon kan geen twee keer dezelfde voornaam hebben.
        [DataRow("Gert", "Samson", "Gert")] // Dubbele Gert met beide Gert met hoofdletter
        [DataRow("Gert", "Samson", "samson")] // Dubbele Samson met één Samson met kleine letter -- case-insensitive vergelijking
        [TestMethod]
        public void MetDubbeleVoornamen_Geeft_Fout(params string[] voornamen)
        {
            Assert.Throws<ArgumentException>(() => new Persoon([.. voornamen]));
        }

        // Tests voor requirement: Iedere voornaam moet minstens één teken bevatten. -- foutieve gevallen
        [DataRow("Gert", "")] // lege string als voornaam
        [DataRow("Gert", " ")] // spatie als voornaam
        [DataRow("Gert", "\t")] // tab als voornaam
        [DataRow("Gert", "\n")] // newline als voornaam
        [TestMethod]
        public void MetLege_OfSpaties_InVoornamen_Geeft_Fout(params string[] voornamen)
        {
            Assert.Throws<ArgumentException>(() => new Persoon([.. voornamen]));
        }

        // Test voor requirement: De ToString() geeft de voornamen weer, gescheiden door een spatie.
        [TestMethod]
        public void ToString_Geeft_Voornamen_Gescheiden_Door_Spatie()
        {
            var voornamen = new Persoon(new List<string> { "Gert", "Samson", "R" });
            Assert.AreEqual("Gert Samson R", voornamen.ToString());
        }
    }
}
