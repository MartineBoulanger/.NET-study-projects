using SchuttersData.Models;

namespace SchuttersData.Repositories
{
    public interface ILidRepository
    {
        Lid? Get(long lidnummer);
        IEnumerable<Lid> GetAll();
        void Add(Lid lid);
        void Update(Lid lid);
        void Delete(long lidnummer);
        bool Exists(long lidnummer);
        IEnumerable<Lid> Search(string? voornaam, string? naam, string? geslacht, string? niveau, string? clubnaam);
    }
}
