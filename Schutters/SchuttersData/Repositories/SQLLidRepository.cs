using Microsoft.EntityFrameworkCore;
using SchuttersData.Models;

namespace SchuttersData.Repositories
{
    public class SQLLidRepository : ILidRepository
    {
        private readonly SchuttersDbContext context;
        public SQLLidRepository(SchuttersDbContext context)
        {
            this.context = context;
        }

        public void Add(Lid lid)
        {
            context.Leden.Add(lid);
            context.SaveChanges();
        }

        public void Update(Lid lid)
        {
            context.Leden.Update(lid);
            context.SaveChanges();
        }

        public void Delete(long lidnummer)
        {
            var lid = context.Leden.Find(lidnummer);
            if (lid != null)
            {
                context.Leden.Remove(lid);
                context.SaveChanges();
            }
        }

        public bool Exists(long lidnummer) => context.Leden.Any(l => l.Lidnummer == lidnummer);

        public Lid? Get(long lidnummer) => context.Leden.Include(l => l.Club).FirstOrDefault(l => l.Lidnummer == lidnummer);

        public IEnumerable<Lid> GetAll() => context.Leden.Include(l => l.Club).AsNoTracking();

        public IEnumerable<Lid> Search(string? voornaam, string? naam, Geslacht? geslacht, Niveau? niveau, string? clubnaam)
        {
            var query = context.Leden.Include(l => l.Club).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(voornaam)) query = query.Where(l => l.Voornaam.Contains(voornaam));
            if (!string.IsNullOrWhiteSpace(naam)) query = query.Where(l => l.Naam.Contains(naam));
            if (geslacht != null) query = query.Where(l => l.Geslacht == geslacht);
            if (niveau != null) query = query.Where(l => l.Niveau == niveau);
            if (!string.IsNullOrWhiteSpace(clubnaam)) query = query.Where(l => l.Club != null && l.Club.Naam.Contains(clubnaam));
            return query;
        }
    }
}
