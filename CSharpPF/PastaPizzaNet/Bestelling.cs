
using Gerechten;
using Dranken;
using Desserts;

namespace PastaPizzaNet
{
    public class Bestelling:IBedrag
    {
        public Klant Klant { get; set; } = null!;
        public BesteldGerecht BesteldGerecht { get; set; } = null!;
        public Drank Drank { get; set; } = null!;
        public Dessert Dessert { get; set; } = null!;
        public int Aantal { get; set; } = 1;
        public bool IsVolledigMenu { get => BesteldGerecht != null && Drank != null && Dessert != null; }
        public decimal BerekenBedrag()
        {
            decimal totaal = 0;
            if (BesteldGerecht != null) totaal += BesteldGerecht.BerekenBedrag();
            if (Drank != null) totaal += Drank.BerekenBedrag();
            if (Dessert != null) totaal += Dessert.BerekenBedrag();
            // Check volledig menu
            if (IsVolledigMenu) totaal *= 0.9m; // 10% korting
            return totaal * Aantal;
        }
        public override string ToString()
        {
            return $"{Klant}\n" +
                   $"{(BesteldGerecht != null ? BesteldGerecht + "\n" : "")}" +
                   $"{(Drank != null ? Drank + "\n" : "")}" +
                   $"{(Dessert != null ? Dessert + "\n" : "")}" +
                   $"Aantal: {Aantal}\n" +
                   $"Bedrag van deze bestelling: {BerekenBedrag():0.00} euro";
        }
    }
}