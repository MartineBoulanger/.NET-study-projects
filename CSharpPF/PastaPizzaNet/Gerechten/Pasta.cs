using PastaPizzaNet;

namespace Gerechten
{
    public class Pasta:Gerecht
    {
        public string Omschrijving { get; set; }
        public Pasta(string naam, decimal prijs, string omschrijving):base(naam, prijs)
        {
            Omschrijving = omschrijving;
        }
        public override decimal BerekenBedrag() => Prijs;
        public override string ToString() => $"{base.ToString()} {Omschrijving}";
    }
}
