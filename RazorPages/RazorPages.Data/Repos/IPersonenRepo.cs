using RazorPages.Data.Models;

namespace RazorPages.Data.Repos
{
    public interface IPersonenRepo
    {
        IEnumerable<Persoon> GetAllePersonen();
        Persoon? GetPersoon(int id);
        void UpdatePersoon(Persoon updatedPersoon);
    }
}
