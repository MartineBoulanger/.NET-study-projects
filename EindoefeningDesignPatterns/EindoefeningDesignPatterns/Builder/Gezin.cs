using EindoefeningDesignPatterns.Decorator;
using EindoefeningDesignPatterns.Factory;
using EindoefeningDesignPatterns.Inheritance;

namespace EindoefeningDesignPatterns.Builder
{
    public class Gezin
    {
        public string Naam { get; set; } = string.Empty;
        public List<Gezinslid> Gezinsleden { get; set; } = new();
        public IKerstboom? Kerstboom { get; set; }
        public List<Verlichting> Verlichting { get; set; } = new();
        public List<Pakje> Pakjes { get; set; } = new();

        public Gezin(string naam, List<Gezinslid> gezinsleden, IKerstboom? kerstboom, List<Verlichting> verlichting, List<Pakje> pakjes)
        {
            Naam = naam;
            Gezinsleden = gezinsleden;
            Kerstboom = kerstboom;
            Verlichting = verlichting;
            Pakjes = pakjes;
        }
    }
}
