using KaasService.Models;
using Microsoft.EntityFrameworkCore;

namespace KaasService.Repositories
{
    public class KaasRepository(KaaslandContext context):IKaasRepository
    {
        //public IQueryable<Kaas> FindAll() => context.Kazen.AsNoTracking();

        //public IQueryable<Kaas> FindByBeginNaam(string begin) => context.Kazen.AsNoTracking().Where(k => k.Naam.StartsWith(begin));

        //public Kaas? FindById(int id) => context.Kazen.Find(id);

        //public void Insert(Kaas kaas)
        //{
        //    context.Kazen.Add(kaas);
        //    context.SaveChanges();
        //}

        //public void Delete(Kaas kaas)
        //{
        //    context.Kazen.Remove(kaas);
        //    context.SaveChanges();
        //}

        //public void Update(Kaas kaas)
        //{
        //    context.Kazen.Update(kaas);
        //    context.SaveChanges();
        //}

        public async Task<List<Kaas>> FindAllAsync() => await context.Kazen.AsNoTracking().ToListAsync();

        public async Task<List<Kaas>> FindByBeginNaamAsync(string begin) => await context.Kazen.AsNoTracking().Where(k => k.Naam.StartsWith(begin)).ToListAsync();

        public async Task<Kaas?> FindByIdAsync(int id) => await context.Kazen.FindAsync(id);

        public async Task InsertAsync(Kaas kaas)
        {
            await context.Kazen.AddAsync(kaas);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Kaas kaas)
        {
            context.Kazen.Remove(kaas);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Kaas kaas)
        {
            context.Kazen.Update(kaas);
            await context.SaveChangesAsync();
        }
    }
}
