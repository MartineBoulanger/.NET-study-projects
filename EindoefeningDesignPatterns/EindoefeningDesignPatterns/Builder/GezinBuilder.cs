using EindoefeningDesignPatterns.Decorator;
using EindoefeningDesignPatterns.Factory;
using EindoefeningDesignPatterns.Inheritance;

namespace EindoefeningDesignPatterns.Builder
{
    public class GezinBuilder
    {
        public string Naam { get; set; } = null!;
        public List<Gezinslid> Gezinsleden { get; set; } = new List<Gezinslid>();
        public IKerstboom? Kerstboom { get; set; }
        public List<Verlichting> Verlichting { get; set; } = new List<Verlichting>();
        public List<Pakje> Pakjes { get; set; } = new List<Pakje>();

        public GezinBuilder SetNaam(string naam)
        {
            Naam = naam;
            return this;
        }

        public GezinBuilder VoegGezinslidToe(string naam, int leeftijd)
        {
            Gezinsleden.Add(new Gezinslid(naam, leeftijd));
            Pakjes.Add(PakjeFactory.MaakPakje(leeftijd));
            return this;
        }

        public GezinBuilder SetKerstboom(IKerstboom kerstboom)
        {
            Kerstboom = kerstboom;
            return this;
        }

        public GezinBuilder VoegVerlichtingToe(Verlichting verlichting)
        {
            Verlichting.Add(verlichting);
            return this;
        }

        public Gezin Build() => new Gezin(Naam, Gezinsleden, Kerstboom, Verlichting, Pakjes);

    }
}
