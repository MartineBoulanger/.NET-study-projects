using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class RechthoekTest
    {
        [TestMethod]
        public void OmtrekVanRechthoekMetLengte3EnBreedte4Is14()
        {
            Assert.AreEqual(14, new Rechthoek(3,4).Omtrek());
        }

        [TestMethod]
        public void OppervlakteVanRechthoekMetLengte3EnBreedte4Is12()
        {
            Assert.AreEqual(12, new Rechthoek(3,4).Oppervlakte());
        }

        [TestMethod]
        public void OppervlakteRechthoek3Op5Is15()
        {
            Assert.IsTrue(new Rechthoek(5,3).Oppervlakte().Equals(15));
        }

        [TestMethod]
        public void OmtrekRechthoek5Op3Is16()
        {
            Assert.IsTrue(new Rechthoek(5,3).Omtrek().Equals(16));
        }
    }
}
