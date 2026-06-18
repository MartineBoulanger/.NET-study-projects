using KaasService.Models;

namespace KaasService.Repositories
{
    public interface IFiliaalRepository
    {
        Task<List<Filiaal>> FindAllAsync();
    }
}
