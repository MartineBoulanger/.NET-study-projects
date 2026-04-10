using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class RekeningTest
    {
        // maak een private object van de class die je wilt testen, zodat je die in alle testmethods kunt gebruiken
        private Rekening rekening = null!;

        // deze method wordt voor elke testmethod uitgevoerd, dus je hebt altijd een nieuwe rekening voordat je een test uitvoert
        [TestInitialize]
        public void Initialize()
        {
            rekening = new Rekening();
        }

        [TestMethod]
        public void HetSaldoVanEenNieuweRekeningIsNul()
        {
            //var rekening = new Rekening(); // dit hoef je dan niet meer te doen in elke testmethod
            Assert.AreEqual(decimal.Zero, rekening.Saldo);
        }

        [TestMethod]
        public void HetSaldoNaEenEersteStortingIsHetBedragVanDieStorting()
        {
            var bedrag = 2.5m;
            rekening.Storten(bedrag);
            Assert.AreEqual(bedrag, rekening.Saldo);
        }

        [TestMethod]
        public void HetSaldoNaTweeStortingenIsDeSomVanDeBedragenVanDieStortingen()
        {
            rekening.Storten(2.5m);
            rekening.Storten(1.2m);
            Assert.AreEqual(3.7m, rekening.Saldo);
        }

        // deze testmethods zijn er om te testen of de error handling wel werkt
        [TestMethod]
        public void HetBedragVanEenStortingMagNietNulZijn()
        {
            Assert.Throws<ArgumentException>(() => rekening.Storten(decimal.Zero));
        }

        [TestMethod]
        public void HetBedragVanEenStortingMagNietNegatiefZijn()
        {
            Assert.Throws<ArgumentException>(() => rekening.Storten(-1m));
        }

        // deze testmethods zijn er om de public property te testen
        [TestMethod]
        public void HetSaldoMagNietNegatiefZijn()
        {
            Assert.Throws<ArgumentException>(() => rekening.Saldo = -1m);
        }

        [TestMethod]
        public void HetSaldoMagNulZijn()
        {
           rekening.Saldo = 0m;
        }

        [TestMethod]
        public void HetSaldoMagPositiefZijn()
        {
            rekening.Saldo = 1m;
        }

        // testen met de constructor die een saldo als parameter heeft
        [TestMethod]
        public void NieuweRekeningMetJuisteSaldoIsOk()
        {
            rekening = new Rekening(10m);
        }

        [TestMethod]
        public void NieuweRekeningMetNegatiefSaldoIsFout()
        {
            Assert.Throws<ArgumentException>(() => new Rekening(-10m));
        }
    }
}
