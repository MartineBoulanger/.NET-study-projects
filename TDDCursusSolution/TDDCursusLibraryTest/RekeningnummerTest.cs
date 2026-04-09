using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class RekeningnummerTest
    {
        [TestMethod]
        public void NewMetCorrectNummerIsOK()
        {
            new Rekeningnummer("BE72091012240116");
        }

        [TestMethod]
        public void NewMetCorrectNummerControleGetalMin10IsOK()
        {
            new Rekeningnummer("BE02063588295840");
        }

        [TestMethod]
        public void NewMetTeLangNummerIsNietOK()
        {
            Assert.Throws<ArgumentException>(() => new Rekeningnummer("BE720910122401160"));
        }

        [TestMethod]
        public void NewMetTeKortNummerIsNietOK()
        {
            Assert.Throws<ArgumentException>(() => new Rekeningnummer("BE7209101224011"));
        }

        [TestMethod]
        public void NewNietBelgischNummerIsNietOK()
        {
            Assert.Throws<ArgumentException>(() => new Rekeningnummer("FR72091012240116"));
        }

        [TestMethod]
        public void NewNummerMetOngeldigeTekensIsNietOK()
        {
            Assert.Throws<ArgumentException>(() => new Rekeningnummer("BEX209101224011Y"));
        }

        [TestMethod]
        public void NewNummerMetTeGrootControlegetalIsNietOK()
        {
            Assert.Throws<ArgumentException>(() => new Rekeningnummer("BE99091012240116"));
        }

        [TestMethod]
        public void NewNummerMetVerkeerdeControleberekeningIsNietOK()
        {
            Assert.Throws<ArgumentException>(() => new Rekeningnummer("BE72091012240115"));
        }

        [TestMethod]
        public void NewLeegNummerIsNietOK()
        {
            Assert.Throws<ArgumentException>(() => new Rekeningnummer(string.Empty));
        }

        [TestMethod]
        public void ToStringRekeningNummerMoetHetNummerTeruggeven()
        {
            var nummer = "BE72091012240116";
            var rekeningnummer = new Rekeningnummer(nummer);
            Assert.AreEqual(nummer, rekeningnummer.ToString());
        }

        [TestMethod]
        public void NewNummerMetNullIsNietOK()
        {
            Assert.Throws<ArgumentNullException>(() => new Rekeningnummer(null!));
        }
    }
}
