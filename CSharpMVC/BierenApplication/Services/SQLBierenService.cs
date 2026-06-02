using BierenApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BierenApplication.Services
{
    public class SQLBierenService:IBierenService
    {
        private readonly MvcbierenContext _context;
        public SQLBierenService(MvcbierenContext context)
        {
            _context = context;
        }

        public void Add(Bier bier)
        {
            _context.Bieren.Add(bier);
            _context.SaveChanges();
            //throw new NotImplementedException();
        }

        public List<Bier> BierenTussen2AlcoholPercentages(float min, float max)
        {
            return (from bier in _context.Bieren where bier.Alcohol >= min && bier.Alcohol <= max orderby bier.Alcohol select bier).ToList();
            //throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            Bier bier = Read(id);
            _context.Bieren.Remove(bier);
            _context.SaveChanges();
            //throw new NotImplementedException();
        }

        public List<Bier> FindAll()
        {
            return _context.Bieren.ToList();
            //throw new NotImplementedException();
        }

        public Bier Read(int id)
        {
            return _context.Bieren.Find(id);
            //throw new NotImplementedException();
        }

        public void VerhoogPrijzen(decimal percentage)
        {
            foreach (var b in _context.Bieren)
            {
                b.Prijs *= (1m + percentage / 100m);
            }
            _context.SaveChanges();
            //throw new NotImplementedException();
        }

        public List<Bier> BierenVanEenSoort(string soortnaam)
        {
            return (from bier in _context.Bieren.Include(b => b.Soort) where bier.Soort.Naam == soortnaam select bier).ToList();
            //throw new NotImplementedException();
        }

        public List<Bier> BierenMetPostcode(short postcode)
        {
            return (from bier in _context.Bieren.Include(b => b.Brouwer) where bier.Brouwer.PostCode == postcode select bier).ToList();
            //throw new NotImplementedException();
        }
    }
}
