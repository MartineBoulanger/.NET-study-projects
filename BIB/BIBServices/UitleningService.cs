using BIBData.Models;
using BIBData.Repositories;
using System.Transactions;

namespace BIBServices
{
    public class UitleningService
    {
        private readonly IUitleningRepository repository;
        private readonly IUitleenobjectRepository uitleenobjectRepository;
        private readonly ILenerRepository lenerRepository;
        private readonly IReserveringRepository reserveringRepository;

        public UitleningService(IUitleenobjectRepository uitleenobjectRepository, IUitleningRepository uitleningRepository, ILenerRepository lenerRepository, IReserveringRepository reserveringRepository)
        {
            repository = uitleningRepository;
            this.uitleenobjectRepository = uitleenobjectRepository;
            this.lenerRepository = lenerRepository;
            this.reserveringRepository = reserveringRepository;
        }

        public void UitleningRegistreren(int uitleenobjectId, int lenerId)
        {
            var item = uitleenobjectRepository.Get(uitleenobjectId);
            var lener = lenerRepository.Get(lenerId);
            if (item != null && lener != null)
            {
                item.Status = Status.Uitgeleend;
                repository.Add(new Uitlening
                {
                    Uitleenobject = item,
                    Lener = lener,
                    Van = DateTime.Now,
                    Tot = null
                });
            }
        }

        public void ItemTerugbrengen(int uitleenobjectId)
        {
            using var scope = new TransactionScope();
            repository.SetReturnDate(uitleenobjectId, DateTime.Now);
            if (reserveringRepository.IsGereserveerd(uitleenobjectId))
                uitleenobjectRepository.SetStatus(uitleenobjectId, Status.Gereserveerd);
            else
                uitleenobjectRepository.SetStatus(uitleenobjectId, Status.Beschikbaar);
            scope.Complete();
        }

        public string? GetHuidigeUitlener(int uitleenobjectId)
        {
            var uitlening = repository.GetOpenstaandeUitleningVoorUitleenobject(uitleenobjectId);
            return uitlening != null ? $"{uitlening.Lener.Voornaam} {uitlening.Lener.Familienaam}" : null;
        }

        public IEnumerable<Uitlening> GetOpenstaandeUitleningenVanLener(int lenerId) => repository.GetOpenstaandeUitleningenVanLener(lenerId);
    }
}
