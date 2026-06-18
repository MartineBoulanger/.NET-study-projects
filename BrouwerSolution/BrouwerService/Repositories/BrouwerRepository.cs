using BrouwerService.Models;
using Microsoft.EntityFrameworkCore;

namespace BrouwerService.Repositories
{
    public class BrouwerRepository(BierlandContext context):IBrouwerRepository
    {
        //public IQueryable<Brouwer> FindAll() => context.Brouwers.AsNoTracking();

        //public IQueryable<Brouwer> FindByBeginNaam(string begin) => context.Brouwers.AsNoTracking().Where(b => b.Naam.StartsWith(begin));

        //public Brouwer? FindById(int id) => context.Brouwers.Find(id);

        //public void Insert(Brouwer brouwer)
        //{
        //    context.Brouwers.Add(brouwer);
        //    context.SaveChanges();
        //}

        //public void Delete(Brouwer brouwer)
        //{
        //    context.Brouwers.Remove(brouwer);
        //    context.SaveChanges();
        //}

        //public void Update(Brouwer brouwer)
        //{
        //    context.Brouwers.Update(brouwer);
        //    context.SaveChanges();
        //}

        public async Task<List<Brouwer>> FindAllAsync() => await context.Brouwers.AsNoTracking().ToListAsync();

        public async Task<List<Brouwer>> FindByBeginNaamAsync(string begin) => await context.Brouwers.AsNoTracking().Where(b => b.Naam.StartsWith(begin)).ToListAsync();

        public async Task<Brouwer?> FindByIdAsync(int id) => await context.Brouwers.FindAsync(id);

        public async Task InsertAsync(Brouwer brouwer)
        {
            await context.Brouwers.AddAsync(brouwer);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Brouwer brouwer)
        {
            context.Brouwers.Remove(brouwer);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Brouwer brouwer)
        {
            context.Brouwers.Update(brouwer);
            await context.SaveChangesAsync();
        }
    }
}
