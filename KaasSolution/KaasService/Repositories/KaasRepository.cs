using KaasService.Models;
using Microsoft.EntityFrameworkCore;

namespace KaasService.Repositories
{
    public class KaasRepository(KaaslandContext context):IKaasRepository
    {
        public IQueryable<Kaas> FindAll() => context.Kazen.AsNoTracking();

        public IQueryable<Kaas> FindByBeginNaam(string begin) => context.Kazen.AsNoTracking().Where(k => k.Naam.StartsWith(begin));

        public Kaas? FindById(int id) => context.Kazen.Find(id);

        public void Insert(Kaas kaas)
        {
            context.Kazen.Add(kaas);
            context.SaveChanges();
        }

        public void Delete(Kaas kaas)
        {
            context.Kazen.Remove(kaas);
            context.SaveChanges();
        }

        public void Update(Kaas kaas)
        {
            context.Kazen.Update(kaas);
            context.SaveChanges();
        }
    }
}
