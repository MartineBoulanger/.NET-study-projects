using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class PeriodeTest
    {
        private DateTime vanDatum, totDatum;

        [TestInitialize]
        public void Initialize()
        {
            vanDatum = new DateTime();
            totDatum = new DateTime();
        }

        [TestMethod]
        public void VanDatum_En_TotDatum_Is_Correct()
        {
            new Periode(new DateTime(2000, 1, 1), new DateTime(2000, 2, 2));
        }

        [TestMethod]
        public void VanNew_En_TotNew_Geeft_ArgumentExpression()
        {
            Assert.Throws<ArgumentException>(() => new Periode(vanDatum, totDatum));
        }

        [TestMethod]
        public void VanDatum_En_TotNew_Geeft_ArgumentExpression()
        {
            Assert.Throws<ArgumentException>(() => new Periode(new DateTime(2000, 1, 1), totDatum));
        }

        [TestMethod]
        public void VanNew_En_TotDatum_Is_Correct()
        {
            new Periode(vanDatum, new DateTime(2000, 1, 1));
        }

        [TestMethod]
        public void VanDatum_En_TotDatum_Dezelfde_Dag_Mag_Niet()
        {
            Assert.Throws<ArgumentException>(() => new Periode(new DateTime(2000, 1, 1), new DateTime(2000, 1, 1)));
        }

        [TestMethod]
        public void VanDatum_Later_Dan_TotDatum_Mag_Niet()
        {
            Assert.Throws<ArgumentException>(() => new Periode(new DateTime(2000, 1, 31), new DateTime(2000, 1, 1)));
        }

        [TestMethod]
        public void TotDatum_Moet_Minimaal_Een_Dag_Zijn()
        {
            Assert.Throws<ArgumentException>(() => new Periode(new DateTime(2000, 1, 1,12,0,0), new DateTime(2000, 1, 2,1,1,1)));
        }
    }
}
