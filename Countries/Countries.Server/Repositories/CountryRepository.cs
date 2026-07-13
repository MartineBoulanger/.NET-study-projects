using Countries.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Countries.Server.Repositories
{
    internal sealed class CountryRepository(CountriesDbContext context):ICountryRepository
    {
        public async Task Delete(Country country)
        {
            var flag = await context.Flags.FindAsync(country.Id);
            if (flag is not null)
                context.Flags.Remove(flag);
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

        public async Task Insert(Country country)
        {
            await context.Countries.AddAsync(country);
            await context.SaveChangesAsync();
        }

        public async Task<int> FindCountryIdByName(string name)
        {
            var country = await context.Countries.Where(c => c.Name == name).FirstOrDefaultAsync();

            return country == null ? 0 : country.Id;
        }

        public async Task Update(Country updateCountry)
        {
            var country = await context.Countries.FindAsync(updateCountry.Id);
            if (country == null)
                return;
            if (country.Name != updateCountry.Name)
                country.Name = updateCountry.Name;
            if (country.Capital != updateCountry.Capital)
                country.Capital = updateCountry.Capital;
            if (country.Population != updateCountry.Population)
                country.Population = updateCountry.Population;
            await context.SaveChangesAsync();
        }

        public async Task UploadFlag(int id, byte[] image)
        {
            if (context.Flags.Any(f => f.Id == id))
            {
                var flag = context.Flags.Find(id);
                flag.Image = image;
                await context.SaveChangesAsync();
            }
            else
            {
                var country =
                    context.Countries.Find(id)
                    ?? throw new ArgumentException($"Geen land gevonden met id {id}");
                Flag flag = new()
                {
                    Id = id,
                    Image = image,
                    Country = country,
                };
                await context.Flags.AddAsync(flag);
                await context.SaveChangesAsync();
            }
        }

        public Task<byte[]?> GetFlag(int id) =>
            context.Flags.Where(f => f.Id == id).Select(f => f.Image).FirstOrDefaultAsync();
    }
}
