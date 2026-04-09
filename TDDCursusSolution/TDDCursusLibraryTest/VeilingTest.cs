using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class VeilingTest
    {
        [TestMethod]
        public void NieuweVeilingHoogsteBodIsNul()
        {
            Assert.AreEqual(0m, new Veiling().HoogsteBod);
        }

        [TestMethod]
        public void DoeEersteBodHoogsteBodIsDatBod()
        {
            var veiling = new Veiling();
            var bod = 100m;
            veiling.DoeBod(bod);
            Assert.AreEqual(bod, veiling.HoogsteBod);
        }

        [TestMethod]
        public void DoeTweeBodHoogsteBodIsHetHoogsteVanDieTweeBod()
        {
            var veiling = new Veiling();
            veiling.DoeBod(2.5m);
            veiling.DoeBod(1.2m);
            veiling.DoeBod(2.3m);
            Assert.AreEqual(2.5m, veiling.HoogsteBod);
        }
    }
}
