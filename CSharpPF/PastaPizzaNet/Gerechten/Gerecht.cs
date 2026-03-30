using PastaPizzaNet;

namespace Gerechten
{
    public abstract class Gerecht:IBedrag
    {
        public required string Naam { get; init; }
        public decimal Prijs { get; init; }
        protected Gerecht(string naam, decimal prijs)
        {
            Naam = naam;
            Prijs = prijs;
        }
        public virtual decimal BerekenBedrag() => Prijs;
        public override string ToString() => $"Gerecht: {Naam} ({Prijs:0.00} euro)";
    }
}
