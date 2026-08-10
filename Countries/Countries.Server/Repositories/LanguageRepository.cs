using Countries.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Countries.Server.Repositories
{
    internal sealed class LanguageRepository(CountriesDbContext context):ILanguageRepository
    {
        public async Task<List<Language>> LanguagesFromCountry(int id) =>
            await context
                .Languages.AsNoTracking()
                .Where(l => l.Countries.Any(c => c.Id == id))
                .ToListAsync();
    }
}
