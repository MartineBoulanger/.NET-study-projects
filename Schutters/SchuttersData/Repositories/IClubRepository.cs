using SchuttersData.Models;

namespace SchuttersData.Repositories
{
    public interface IClubRepository
    {
        Club? Get(int stamnummer);
        IEnumerable<Club> GetAll();
        void Add(Club club);
        void Update(Club club);
        void Delete(int stamnummer);
        bool Exists(int stamnummer);
    }
}
