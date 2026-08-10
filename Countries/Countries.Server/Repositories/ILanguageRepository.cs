using Countries.Server.Models;

namespace Countries.Server.Repositories
{
    internal interface ILanguageRepository
    {
        Task<List<Language>> LanguagesFromCountry(int id);
    }
}
