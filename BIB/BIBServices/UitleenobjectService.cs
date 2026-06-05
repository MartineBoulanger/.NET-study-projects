using BIBData.Models;
using BIBData.Repositories;

namespace BIBServices
{
    public class UitleenobjectService
    {
        private readonly IUitleenobjectRepository repository;
        public UitleenobjectService(IUitleenobjectRepository uitleenRepository)
        {
            repository = uitleenRepository;
        }

        public IEnumerable<Uitleenobject> GetAllUitleenobjecten() => repository.GetAll();

        public string GetUitleenobjectType(int id) => repository.Get(id)!.GetType().ToString().Contains("Boek") ? "Boek" : "Device";

        public string GetDetails(int id)
        {
            if (GetUitleenobjectType(id) == "Boek")
            {
                var boek = repository.GetBoek(id);
                return boek != null ? $"{boek.ISBN} ({boek.Auteur}, {boek.Aantalpaginas}p.)" : $"Geen info gevonden over een boek met id {id}";
            }
            else
            {
                var device = repository.GetDevice(id);
                return device != null ? $"{device.Operatingsysteem.Naam} - {device.Schermgrootte}\"" : $"Geen info gevonden over een device met id {id}";
            }
        }

        public Uitleenobject? GetUitleenobject(int id) => repository.Get(id);
    }
}
