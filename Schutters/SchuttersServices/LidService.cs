using SchuttersData.Models;
using SchuttersData.Repositories;

namespace SchuttersServices
{
    public class LidService
    {
        private readonly ILidRepository lidRepository;
        private readonly IClubRepository clubRepository;
        public LidService(ILidRepository lidRepository, IClubRepository clubRepository)
        {
            this.lidRepository = lidRepository;
            this.clubRepository = clubRepository;
        }

        public IEnumerable<Lid> GetAllLeden() => lidRepository.GetAll();
        public Lid? GetLid(long lidnummer) => lidRepository.Get(lidnummer);
        public bool LidnummerBestaat(long lidnummer) => lidRepository.Exists(lidnummer);
        public void AddLid(Lid lid) => lidRepository.Add(lid);
        public void UpdateLid(Lid lid) => lidRepository.Update(lid);
        public void DeleteLid(long lidnummer) => lidRepository.Delete(lidnummer);
        public IEnumerable<Club> GetAllClubs() => clubRepository.GetAll();
        public IEnumerable<Lid> Search(string? voornaam, string? naam, Geslacht? geslacht, Niveau? niveau, string? clubnaam) 
            => lidRepository.Search(voornaam, naam, geslacht, niveau, clubnaam);
    }
}
