using KaasService.Models;

namespace KaasService.Repositories
{
    public interface IKaasRepository
    {
        IQueryable<Kaas> FindAll();
        Kaas? FindById(int id);
        IQueryable<Kaas> FindByBeginNaam(string begin);
        void Insert(Kaas kaas);
        void Delete(Kaas kaas);
        void Update(Kaas kaas);
    }
}
