using TDDCursusLibrary;
using Moq;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class WinstServiceTest
    {
        private IOpbrengstDAO? opbrengstDAO;
        private IKostDAO? kostDAO;
        private WinstService? winstService;
        private Mock<IOpbrengstDAO>? mockOpbrengstDAO;
        private Mock<IKostDAO>? mockIKostDAO;

        [TestInitialize]
        public void Initialize()
        {
            //opbrengstDAO = new OpbrengstDAOStub();
            //kostDAO = new KostDAOStub();
            mockOpbrengstDAO = new Mock<IOpbrengstDAO>();
            mockIKostDAO = new Mock<IKostDAO>();
            opbrengstDAO = mockOpbrengstDAO!.Object;
            kostDAO = mockIKostDAO!.Object;
            // de mock objecten trainen om niet de default waarden terug te krijgen
            mockOpbrengstDAO.Setup(m => m.TotaleOpbrengst()).Returns(1000m);
            mockIKostDAO.Setup(m => m.TotaleKost()).Returns(500m);
            // class met constructor hier initializen en niet in de test method zelf
            winstService = new WinstService(opbrengstDAO, kostDAO); 
        }

        [TestMethod]
        public void WinstIsOpbrengstMinKost()
        {
            Assert.AreEqual(500m, winstService!.Winst);
            // verifieer hier met de mock objecten dat de juiste methoden zijn aangeroepen, en dat de test werkt zoals verwacht
            mockOpbrengstDAO!.Verify(m => m.TotaleOpbrengst());
            mockIKostDAO!.Verify(m => m.TotaleKost());
        }
    }
}
