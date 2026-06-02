namespace BierenApplication.Models
{
    public interface IBierenService
    {
        Bier Read(int id);
        List<Bier> FindAll();
        void Add(Bier bier);
        void Delete(int id);
        void VerhoogPrijzen(decimal percentage);
        List<Bier> BierenTussen2AlcoholPercentages(float min, float max);
        List<Bier> BierenVanEenSoort(string soortnaam);
        List<Bier> BierenMetPostcode(short postcode);
    }
}
