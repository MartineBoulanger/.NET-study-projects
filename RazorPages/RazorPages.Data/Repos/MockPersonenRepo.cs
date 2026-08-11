using RazorPages.Data.Models;

namespace RazorPages.Data.Repos
{
    public class MockPersonenRepo:IPersonenRepo
    {
        public List<Persoon> personenLijst;

        public MockPersonenRepo()
        {
            personenLijst = new List<Persoon>()
            {
                new Persoon
                {
                    Id = 1,
                    Voornaam = "Jesse",
                    Familienaam = "James",
                    Geboren = new DateTime(1966,1,1),
                    Gehuwd = true,
                    Opmerkingen = "Schurk van het Wilde Westen",
                    Geslacht = Geslacht.M
                },
                 new Persoon
                {
                    Id = 2,
                    Voornaam = "Jane",
                    Familienaam = "Calamity",
                    Geboren = new DateTime(1966,2,2),
                    Gehuwd = true,
                    Opmerkingen = "Marthe Jane Cannary",
                    Geslacht = Geslacht.V
                },
                  new Persoon
                {
                    Id = 3,
                    Voornaam = "Billy",
                    Familienaam = "The Kid",
                    Geboren = new DateTime(1966,3,3),
                    Gehuwd = false,
                    Opmerkingen = "Revolverheld",
                    Geslacht = Geslacht.M
                },
                   new Persoon
                {
                    Id = 4,
                    Voornaam = "Jesse",
                    Familienaam = "Bernhardt",
                    Geboren = new DateTime(1966,4,4),
                    Gehuwd = false,
                    Opmerkingen = "Rosine Bernardt",
                    Geslacht = Geslacht.V
                }
            };
        }

        public IEnumerable<Persoon> GetAllePersonen() => personenLijst;
        public Persoon? GetPersoon(int id) => personenLijst.FirstOrDefault(p => p.Id == id);
        public void UpdatePersoon(Persoon updatedPersoon)
        {
            Persoon? persoon = personenLijst.FirstOrDefault(p => p.Id == updatedPersoon.Id);

            if (persoon != null)
            {
                persoon.Voornaam = updatedPersoon.Voornaam;
                persoon.Familienaam = updatedPersoon.Familienaam;
                persoon.Geboren = updatedPersoon.Geboren;
                persoon.Gehuwd = updatedPersoon.Gehuwd;
                persoon.Geslacht = updatedPersoon.Geslacht;
                persoon.Opmerkingen = updatedPersoon.Opmerkingen;
            }
        }
        public void AddPersoon(Persoon newPersoon)
        {
            newPersoon.Id = personenLijst.Max(p => p.Id) + 1;
            personenLijst.Add(newPersoon);
        }

        public void DeletePersoon(int id)
        {
            Persoon? persoon = personenLijst.FirstOrDefault(p => p.Id == id);
            if (persoon != null)
                personenLijst.Remove(persoon);
        }
    }
}
