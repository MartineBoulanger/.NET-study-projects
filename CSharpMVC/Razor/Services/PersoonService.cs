using Razor.Models;

namespace Razor.Services
{
    public class PersoonService
    {
        private readonly Dictionary<int, Persoon> personen = new()
        {
            { 1, new Persoon { ID = 1, Voornaam = " Jesse", Familienaam = "James", Score = 5, Wedde = 1000m, RekeningNummer = "BE03-2345-2345-2345", Paswoord = "Test1234!", HerhaalPaswoord = "Test1234!", Geboren = new DateTime(1966,1,1), Gehuwd = true, Opmerkingen = "Schurk van het wilde westen", Geslacht = Geslacht.Man} },
            { 2, new Persoon { ID = 2, Voornaam = " Jane", Familienaam = "Calamity", Score = 4, Wedde = 2000m, RekeningNummer = "BE72-1234-1234-1234", Paswoord = "Test1234!", HerhaalPaswoord = "Test1234!", Geboren = new DateTime(1966,2,2), Gehuwd = true, Opmerkingen = "Martha Jane Cannary", Geslacht = Geslacht.Vrouw} },
            { 3, new Persoon { ID = 3, Voornaam = " Billy", Familienaam = "The Kid", Score = 5, Wedde = 3000m, RekeningNummer = "NL45-6789-6798-7689", Paswoord = "Test1234!", HerhaalPaswoord = "Test1234!", Geboren = new DateTime(1966,3,3), Gehuwd = false, Opmerkingen = "Revolverheld", Geslacht = Geslacht.Man} },
            { 4, new Persoon { ID = 4, Voornaam = " Sarah", Familienaam = "Bernhardt", Score = 3, Wedde = 4000m, RekeningNummer = "BE07-5678-5678-5678", Paswoord = "Test1234!", HerhaalPaswoord = "Test1234!", Geboren = new DateTime(1966,4,4), Gehuwd = false, Opmerkingen = "Rosine Bernhardt", Geslacht = Geslacht.Vrouw} },
        };

        public List<Persoon> FindAll() { return [.. personen.Values]; }

        public Persoon? FindByID(int id)
        {
            personen.TryGetValue(id, out Persoon? gelezenPersoon);
            return gelezenPersoon;
        }

        public void Delete(int id) { personen.Remove(id); }

        public void Opslag(decimal? vanWedde, decimal? totWedde, decimal percentage)
        {
            foreach (var p in (from persoon in personen.Values where persoon.Wedde >= vanWedde && persoon.Wedde <= totWedde select persoon))
            {
                p.Wedde += p.Wedde * percentage / 100;
            }
        }

        public List<Persoon> VanTotWedde(decimal? van, decimal? tot)
        {
            return (from persoon in personen.Values where persoon.Wedde >= van && persoon.Wedde <= tot orderby persoon.Wedde select persoon).ToList();
        }

        public void Add(Persoon p)
        {
            p.ID = personen.Keys.Max() + 1;
            personen.Add(p.ID, p);
        }

        public void Update(Persoon p)
        {
            personen[p.ID] = p;
        }
    }
}
