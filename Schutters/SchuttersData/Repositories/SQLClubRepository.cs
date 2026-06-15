using Microsoft.EntityFrameworkCore;
using SchuttersData.Models;

namespace SchuttersData.Repositories
{
    public class SQLClubRepository : IClubRepository
    {
        private readonly SchuttersDbContext context;
        public SQLClubRepository(SchuttersDbContext context)
        {
            this.context = context;
        }

        public void Add(Club club)
        {
            context.Clubs.Add(club);
            context.SaveChanges();
        }

        public void Delete(int stamnummer)
        {
            var club = context.Clubs.Find(stamnummer);
            if (club != null)
            {
                context.Clubs.Remove(club);
                context.SaveChanges();
            }
        }

        public bool Exists(int stamnummer) => context.Clubs.Any(c => c.Stamnummer == stamnummer);

        public Club? Get(int stamnummer) => context.Clubs.Find(stamnummer);

        public IEnumerable<Club> GetAll() => context.Clubs.AsNoTracking();

        public void Update(Club club)
        {
            context.Clubs.Update(club);
            context.SaveChanges();
        }
    }
}
