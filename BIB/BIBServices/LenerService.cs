using BIBData.Models;
using BIBData.Repositories;

namespace BIBServices
{
    public class LenerService
    {
        private readonly ILenerRepository repository;
        public LenerService(ILenerRepository lenerRepository)
        {
            repository = lenerRepository;
        }

        public IEnumerable<Lener> GetAllLeners() => repository.GetAll();
        public Lener? GetLener(int id) => repository.Get(id);
    }
}
