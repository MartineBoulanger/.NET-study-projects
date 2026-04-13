using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class WinstServiceTest
    {
        private IOpbrengstDAO? opbrengstDAO;
        private IKostDAO? kostDAO;
        private WinstService? winstService;

        [TestInitialize]
        public void Initialize()
        {
            opbrengstDAO = new OpbrengstDAOStub();
            kostDAO = new KostDAOStub();
            winstService = new WinstService(opbrengstDAO, kostDAO); // class met constructor hier initializen en niet in de test method zelf
        }

        [TestMethod]
        public void WinstIsOpbrengstMinKost()
        {
            Assert.AreEqual(500m, winstService!.Winst);
        }
    }
}
