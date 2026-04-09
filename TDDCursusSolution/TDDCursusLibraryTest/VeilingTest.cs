using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class VeilingTest
    {
        private Veiling veiling = null!;

        [TestInitialize]
        public void Initialize()
        {
            veiling = new Veiling();
        }

        [TestMethod]
        public void NieuweVeilingHoogsteBodIsNul()
        {
            Assert.AreEqual(0m, veiling.HoogsteBod);
        }

        [TestMethod]
        public void DoeEersteBodHoogsteBodIsDatBod()
        {
            var bod = 100m;
            veiling.DoeBod(bod);
            Assert.AreEqual(bod, veiling.HoogsteBod);
        }

        [TestMethod]
        public void DoeTweeBodHoogsteBodIsHetHoogsteVanDieTweeBod()
        {
            veiling.DoeBod(2.5m);
            veiling.DoeBod(1.2m);
            veiling.DoeBod(2.3m);
            Assert.AreEqual(2.5m, veiling.HoogsteBod);
        }
        
        // testen van error handling

    }
}
