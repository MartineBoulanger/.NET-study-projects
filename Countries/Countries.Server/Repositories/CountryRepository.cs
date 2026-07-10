using Countries.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Countries.Server.Repositories
{
    internal sealed class CountryRepository(CountriesDbContext context):ICountryRepository
    {
        public async Task Delete(Country country)
        {
            context.Countries.Remove(country);
            await context.SaveChangesAsync();
        }

        public async Task<Country?> Find(int id) => await context.Countries.FindAsync(id);

        public async Task<List<Country>> FindByName(string searchstring) =>
            await context.Countries.Where(c => c.Name.Contains(searchstring)).ToListAsync();

        public async Task<List<Country>> GetAll() =>
            await context.Countries.AsNoTracking().ToListAsync();

        public async Task<List<Country>> GetTopPopulationCountries(int top) =>
            await context
                .Countries.AsNoTracking()
                .OrderByDescending(c => c.Population)
                .Take(top)
                .ToListAsync();
    }
}
