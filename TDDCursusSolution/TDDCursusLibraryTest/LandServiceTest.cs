using TDDCursusLibrary;
using Moq; // de Moq library importeren om mock objects te kunnen maken

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class LandServiceTest
    {
        private ILandDAO? landDAO;
        private LandService? landService;
        private Mock<ILandDAO>? mockFactory; // Mock object voor ILandDAO

        [TestInitialize]
        public void Initialize()
        {
            //landDAO = new LandDAOStub();
            mockFactory = new Mock<ILandDAO>();
            landDAO = mockFactory!.Object; // het mock object gebruiken als ILandDAO
            // een mock trainen om niet de default waarden terug te krijgen
            mockFactory.Setup(eenLandDAO => eenLandDAO.OppervlakteAlleLanden()).Returns(20);
            // je kunt meerdere setups doen, bijvoorbeeld voor verschillende landcodes
            mockFactory.Setup(eenLandDAO => eenLandDAO.Read("B")).Returns(new Land { Landcode = "B", Oppervlakte = 5 });
            mockFactory.Setup(eenLandDAO => eenLandDAO.Read("NL")).Returns(new Land { Landcode = "NL", Oppervlakte = 6 });
            // je kunt de mock ook trainen om een exception te gooien voor een bepaalde landcode
            mockFactory.Setup(eenLandDAO => eenLandDAO.Read(string.Empty)).Throws(new ArgumentException());
            landService = new LandService(landDAO);
        }

        [TestMethod]
        public void FindVerhoudingOppervlakteLandTovOppervlakteAlleLanden()
        {
            Assert.AreEqual(0.25m, landService!.FindVerhoudingOppervlakteLandTovOppervlakteAlleLanden("B"));
            // verifieer hier met de mock object dat de juiste methoden zijn aangeroepen met de juiste parameters, en dat de test werkt zoals verwacht
            mockFactory!.Verify(eenLandDao => eenLandDao.OppervlakteAlleLanden());
            mockFactory.Verify(eenLandDao => eenLandDao.Read("B"));
        }
    }
}
