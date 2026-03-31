using PastaPizzaNet;

namespace Dranken
{
    public abstract class Drank:IBedrag
    {
        public DrankNaam Naam { get; set; }

        public decimal Prijs { get; init => field = value < 0m ? throw new Exception("Prijs moet hoger zijn dan 0") : value; }

        public Drank(DrankNaam naam, decimal prijs)
        {
            Naam = naam;
            Prijs = prijs;
        }

        public virtual decimal BerekenBedrag() => Prijs;

        public override string ToString() => $"Drank: {Naam} ({Prijs:0.00} euro)";
    }
}
