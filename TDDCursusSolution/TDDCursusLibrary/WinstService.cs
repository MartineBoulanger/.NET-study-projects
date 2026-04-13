namespace TDDCursusLibrary
{
    public class WinstService
    {
        private readonly IOpbrengstDAO opbrengstDAO;
        private readonly IKostDAO kostDAO;
        public WinstService(IOpbrengstDAO opbrengstDAO, IKostDAO kostDAO)
        {
            this.opbrengstDAO = opbrengstDAO;
            this.kostDAO = kostDAO;
        }
        //public decimal Winst => throw new NotImplementedException(); // eerst de not implemented exception gooien, daarna pas vervangen door echte code
        public decimal Winst => opbrengstDAO.TotaleOpbrengst() - kostDAO.TotaleKost(); // de uiteindelijke code die de test doet slagen
    }
}
