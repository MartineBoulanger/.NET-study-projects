using Model.Entities;

namespace Model.Services
{
    public class DocentService
    {
        private EFOpleidingenContext _context;
        public DocentService(EFOpleidingenContext context) // DI
        {
            this._context = context;
        }

        public void ToevoegenDocent(Docent docent)
        {
            if (docent.LandCode == string.Empty || docent.LandCode == null) docent.LandCode = "BE";
            _context.Docenten.Add(docent);
        }

        public IEnumerable<Docent> GetDocentenVoorCampus(int campus)
        {
            return _context.Docenten.Where(x => x.CampusId == campus).ToList();
        }

        public Docent GetDocent (int id)
        {
            if (id == 0) throw new ArgumentException(nameof(id));
            return _context.Docenten.Single(x => x.DocentId == id);
        }
    }
}
