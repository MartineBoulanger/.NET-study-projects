using EindoefeningDesignPatterns.Decorator;
using EindoefeningDesignPatterns.Factory;
using EindoefeningDesignPatterns.Inheritance;

namespace EindoefeningDesignPatterns.Builder
{
    public class GezinBuilder
    {
        private Gezin gezin = new Gezin();

        public GezinBuilder SetNaam(string naam)
        {
            gezin.Naam = naam;
            return this;
        }

        public GezinBuilder VoegGezinslidToe(string naam, int leeftijd)
        {
            gezin.Gezinsleden.Add(new Gezinslid(naam, leeftijd));
            gezin.Pakjes.Add(PakjeFactory.MaakPakje(leeftijd));
            return this;
        }

        public GezinBuilder SetKerstboom(IKerstboom boom)
        {
            gezin.Kerstboom = boom;
            return this;
        }

        public GezinBuilder VoegVerlichtingToe(Verlichting verlichting)
        {
            gezin.Verlichting.Add(verlichting);
            return this;
        }

        public Gezin Build() => gezin;
    }
}
