using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class WoordTellerTest
    {
        private WoordTeller woordTeller = null!;

        [TestInitialize]
        public void Initialize()
        {
            woordTeller = new WoordTeller();
        }

        [TestMethod]
        public void TelWoorden_Null_IsNietGeldig()
        {
            Assert.Throws<NullReferenceException>(() => woordTeller.TelWoorden(null!));
        }

        [DataRow("")]
        [DataRow(" ")]
        [DataRow("  ")]
        [DataRow(",")]
        [DataRow(",,,")]
        [DataRow(" , ,, ")]
        [TestMethod]
        public void TelWoorden_BevatGeenWoorden(string woord)
        {
            Assert.AreEqual(0, woordTeller.TelWoorden(woord));
        }

        [DataRow("woord")]
        [DataRow(" woord")]
        [DataRow("woord ")]
        [TestMethod]
        public void TelWoorden_Bevat1Woord(string woord)
        {
            Assert.AreEqual(1, woordTeller.TelWoorden(woord));
        }

        [DataRow("ik ook")]
        [DataRow("ik  ook")]
        [DataRow("ik,ook")]
        [DataRow("ik, ook  ")]
        [DataRow("ik , ook,")]
        [TestMethod]
        public void TelWoorden_Bevat2Woorden(string woord)
        {
            Assert.AreEqual(2, woordTeller.TelWoorden(woord));
        }
    }
}
