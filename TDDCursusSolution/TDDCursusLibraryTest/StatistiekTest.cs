using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class StatistiekTest
    {
        [TestMethod]
        public void HetGemiddeldeVan10En15Is12Punt5()
        {
            Assert.AreEqual(12.5m, Statistiek.Gemiddelde(new decimal[] { 10m, 15m }));
        }

        [TestMethod]
        public void HetGemiddeldeVanEenGetalIsDatGetal()
        {
            var enigGetal = 1.23m;
            Assert.AreEqual(enigGetal, Statistiek.Gemiddelde(new decimal[] { enigGetal }));
        }

        [TestMethod]
        public void GemiddeldeVanEenLegeVerzamelingKanJeNietBerekenen()
        {
            Assert.Throws<ArgumentException>(() => Statistiek.Gemiddelde(new decimal[] {}));
        }

        [TestMethod]
        public void GemiddeldeVanNullKanJeNietBerekenen()
        {
            Assert.Throws<ArgumentNullException>(() => Statistiek.Gemiddelde(null!));
        }
    }
}
