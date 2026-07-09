using Countries.Server.Models;

namespace Countries.Server.Repositories
{
    internal interface ICountryRepository
    {
        Task<List<Country>> GetTopPopulationCountries(int top);
        Task<List<Country>> GetAll();
        Task Delete(Country country);
        Task<Country?> Find(int id);
    }
}
