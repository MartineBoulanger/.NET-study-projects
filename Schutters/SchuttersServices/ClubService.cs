using SchuttersData.Models;
using SchuttersData.Repositories;

namespace SchuttersServices
{
    public class ClubService
    {
        private readonly IClubRepository clubRepository;
        public ClubService(IClubRepository clubRepository)
        {
            this.clubRepository = clubRepository;
        }

        public IEnumerable<Club> GetAllClubs() => clubRepository.GetAll();
        public Club? GetClub(int stamnummer) => clubRepository.Get(stamnummer);
        public bool StamnummerBestaat(int stamnummer) => clubRepository.Exists(stamnummer);
        public void AddClub(Club club) => clubRepository.Add(club);
        public void UpdateClub(Club club) => clubRepository.Update(club);
        public void DeleteClub(int stamnummer) => clubRepository.Delete(stamnummer);
    }
}
