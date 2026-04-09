using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class ISBNTest
    {
        [TestMethod]
        public void HetNummer0IsVerkeerd()
        {
            Assert.Throws<ArgumentException>(() => new ISBN(0));
        }

        [TestMethod]
        public void EenNegatiefNummerIsVerkeerd()
        {
            Assert.Throws<ArgumentException>(() => new ISBN(-9789027439642L));
        }

        [TestMethod]
        public void EenNummerMet12CijfersIsVerkeerd()
        {
            Assert.Throws<ArgumentException>(() => new ISBN(978902743964L));
        }

        [TestMethod]
        public void EenNummerMet14CijfersIsVerkeerd()
        {
            Assert.Throws<ArgumentException>(() => new ISBN(97890274396421L));
        }

        [TestMethod]
        public void EenNummerMet13CijfersMetVerkeerdControleGetal2()
        {
            Assert.Throws<ArgumentException>(() => new ISBN(8789027439642L));
        }

        [TestMethod]
        public void EenNummerMet13CijfersMetCorrectControleGetal2()
        {
            new ISBN(9789027439642L);
        }

        [TestMethod]
        public void EenNummerMet13CijfersMetVerkeerdControleGetal0()
        {
            Assert.Throws<ArgumentException>(() => new ISBN(7789227439640L));
        }

        [TestMethod]
        public void EenNummerMet13CijfersMetCorrectControleGetal0()
        {
            new ISBN(9789227439640L);
        }

        [TestMethod]
        public void ToString_ISBNNummer_MoetHetNummerTeruggeven()
        {
            var nummer = 9789027439640L;
            var isbn = new ISBN(nummer);
            Assert.AreEqual(nummer.ToString(), isbn.ToString());
        }
    }
}
