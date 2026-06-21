using MinimalKaasService.Models;

namespace MinimalKaasService.Repositories
{
    public interface IKaasRepository
    {
        Task<List<Kaas>> FindAllAsync();
        Task<Kaas?> FindByIdAsync(int id);
        Task<List<Kaas>> FindBySmaakAsync(string smaak);
        Task InsertAsync(Kaas kaas);
        Task DeleteAsync(Kaas kaas);
        Task UpdateAsync(Kaas kaas);
    }
}
