namespace TDDCursusLibrary
{
    public class LandService
    {
        // voeg de interface toe als een private readonly variabele, zodat je deze in de constructor kunt injecteren
        private readonly ILandDAO landDAO;
        // dependency injection - constructor injection
        public LandService(ILandDAO landDAO)
        {
            this.landDAO = landDAO;
        }
        public decimal FindVerhoudingOppervlakteLandTovOppervlakteAlleLanden(string landcode)
        {
            //throw new NotImplementedException();
            var land = landDAO.Read(landcode);
            var oppervlakteAlleLanden = landDAO.OppervlakteAlleLanden();
            return (decimal)land.Oppervlakte / oppervlakteAlleLanden;
        }
    }
}
