using Countries.Server.Models;

namespace Countries.Server.Repositories
{
    internal interface ICountryRepository
    {
        Task<List<Country>> GetTopPopulationCountries(int top);
        Task<List<Country>> GetAll();
        Task<byte[]?> GetFlag(int id);
        Task Delete(Country country);
        Task<Country?> Find(int id);
        Task<List<Country>> FindByName(string searchstring);
        Task Insert(Country country);
        Task<int> FindCountryIdByName(string name);
        Task Update(Country country);
        Task UploadFlag(int id, byte[] image);
    }
}
