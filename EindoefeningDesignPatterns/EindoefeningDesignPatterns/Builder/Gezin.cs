using EindoefeningDesignPatterns.Decorator;
using EindoefeningDesignPatterns.Factory;
using EindoefeningDesignPatterns.Inheritance;

namespace EindoefeningDesignPatterns.Builder
{
    public class Gezin
    {
        public string Naam { get; set; } = string.Empty;
        public List<Gezinslid> Gezinsleden { get; set; } = new List<Gezinslid>();
        public IKerstboom? Kerstboom { get; set; }
        public List<Verlichting> Verlichting { get; set; } = new List<Verlichting>();
        public List<Pakje> Pakjes { get; set; } = new List<Pakje>();
    }
}
