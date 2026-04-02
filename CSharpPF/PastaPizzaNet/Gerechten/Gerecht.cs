using PastaPizzaNet;

namespace Gerechten
{
    public abstract class Gerecht:IBedrag
    {
        public string Naam { get; set; } = null!;

        public decimal Prijs { get; init => field = value < 0m ? throw new Exception("Prijs moet hoger zijn dan 0") : value; } // niet zeker met de init hier -- moet de prijs van een klein gerecht nadien gewijzigd kunnen worden? Is niet duidelijk in de opdracht.

        public Gerecht(string naam, decimal prijs)
        {
            Naam = naam;
            Prijs = prijs;
        }

        public virtual decimal BerekenBedrag() => Prijs;
        
        public override string ToString() => $"Gerecht: {Naam} ({Prijs:0.00} euro)";
    }
}
