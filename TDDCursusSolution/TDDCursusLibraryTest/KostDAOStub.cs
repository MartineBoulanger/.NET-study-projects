using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    public class KostDAOStub : IKostDAO
    {
        public decimal TotaleKost() => 500m;
    }
}
