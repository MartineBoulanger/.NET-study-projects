using PastaPizzaNet;

namespace Dranken
{
    public abstract class Drank:IBedrag
    {
        public DrankNaam Naam { get; init; }
        public decimal Prijs { get; protected set; }
        public Drank(DrankNaam naam, decimal prijs)
        {
            Naam = naam;
            Prijs = prijs;
        }
        public virtual decimal BerekenBedrag() => Prijs;
        public override string ToString() => $"Drank: {Naam} ({Prijs:0.00} euro)";
    }
}
