using BIBData.Models;
using BIBData.Repositories;

namespace BIBServices
{
    public class ReserveringService
    {
        private readonly IReserveringRepository repository;
        private readonly IUitleenobjectRepository uitleenobjectRepository;
        private readonly ILenerRepository lenerRepository;
        public ReserveringService(IReserveringRepository reserveringRepository, IUitleenobjectRepository uitleenobjectRepository, ILenerRepository lenerRepository)
        {
            repository = reserveringRepository;
            this.uitleenobjectRepository = uitleenobjectRepository;
            this.lenerRepository = lenerRepository;
        }

        public IEnumerable<Reservering> GetReserveringenVoorUitleenobject(int id) => repository.GetReserveringenVoorUitleenobject(id);

        public void ItemReserveren(int itemId, int lenerId)
        {
            var item = uitleenobjectRepository.Get(itemId);
            var lener = lenerRepository.Get(lenerId);
            if (item != null && lener != null)
            {
                repository.Add(new Reservering
                {
                    Uitleenobject = item,
                    Lener = lener,
                    GereserveerdOp = DateTime.Now
                });
            }
        }

        public Lener? GetEersteLenerOpReserveringslijst(int uitleenobjectId) => repository.GetReserveringenVoorUitleenobject(uitleenobjectId).FirstOrDefault()?.Lener;

        public void ReserveringVerwijderen(int itemId, int lenerId)
        {
            repository.VerwijderReservering(itemId, lenerId);
        }

        public IEnumerable<Reservering> GetReserveringenVanLener(int lenerId) => repository.GetReserveringenVanLener(lenerId);

        public IEnumerable<Lener> GetReserveringslijst(int uitleenobjectId) => repository.GetReserveringenVoorUitleenobject(uitleenobjectId).Select(r => r.Lener);
    }
}
