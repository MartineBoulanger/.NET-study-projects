using PastaPizzaNet;

namespace Desserts
{
    public class Dessert:IBedrag
    {
        public DessertNaam Naam { get; init; }
        public decimal Prijs { get; }
        public Dessert(DessertNaam naam) {
            Naam = naam;
            Prijs = naam switch
            {
                DessertNaam.Cake => 2m, // omdat alleen Cake een ander bedrag heeft
                _ => 3m
            };
        }
        public virtual decimal BerekenBedrag() => Prijs;
        public override string ToString() => $"Dessert: {Naam} ({Prijs:0.00} euro)";
    }
}
