using KaasService.Models;

namespace KaasService.Repositories
{
    public interface IKaasRepository
    {
        //IQueryable<Kaas> FindAll();
        //Kaas? FindById(int id);
        //IQueryable<Kaas> FindBySmaak(string smaak);
        //void Insert(Kaas kaas);
        //void Delete(Kaas kaas);
        //void Update(Kaas kaas);
        Task<List<Kaas>> FindAllAsync();
        Task<Kaas?> FindByIdAsync(int id);
        Task<List<Kaas>> FindBySmaakAsync(string smaak);
        Task InsertAsync(Kaas kaas);
        Task DeleteAsync(Kaas kaas);
        Task UpdateAsync(Kaas kaas);
    }
}
