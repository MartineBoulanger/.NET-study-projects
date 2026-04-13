using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    public class LandDAOStub : ILandDAO
    { 
        public Land Read(string landcode) => new Land { Landcode = landcode, Oppervlakte = 5 };
        public int OppervlakteAlleLanden() => 20;
    }
}
