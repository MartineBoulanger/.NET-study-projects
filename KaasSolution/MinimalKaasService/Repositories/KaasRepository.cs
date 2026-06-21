using Microsoft.EntityFrameworkCore;
using MinimalKaasService.Models;

namespace MinimalKaasService.Repositories
{
    public class KaasRepository(KaaslandContext context):IKaasRepository
    {
        public async Task<List<Kaas>> FindAllAsync() => await context.Kazen.AsNoTracking().ToListAsync();

        public async Task<List<Kaas>> FindBySmaakAsync(string smaak) => await context.Kazen.AsNoTracking().Where(k => k.Smaak == smaak).ToListAsync();

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
