using BierenApplication.Models;

namespace BierenApplication.Services
{
    public class BierService
    {
        private Dictionary<int, Bier> bieren = new();
        public BierService()
        {
            bieren[1] = new Bier { Id = 1, Naam = "Romy Pils", Alcohol = 5f };
            bieren[2] = new Bier { Id = 2, Naam = "Kasteelbier", Alcohol = 12f };
            bieren[3] = new Bier { Id = 3, Naam = "Maes Radler", Alcohol = 0f };
        }

        public List<Bier> FindAll()
        {
            return bieren.Values.ToList();
        }

        public Bier? Read(int id)
        {
            //bieren.TryGetValue(id, out Bier? gelezenBier);
            //return gelezenBier;
            // of
            return bieren[id];
        }

        public void Delete(int id)
        {
            bieren.Remove(id);
        }
    }
}
