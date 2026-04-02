using Dranken;
using Desserts;

namespace PastaPizzaNet.Bestellingen
{
    public class Bestelling:IBedrag
    {
        public Klant Klant { get; init; } = new Klant { KlantID = 1 }; // standaard klant -- wanneer er een onbekende klant is
        public BesteldGerecht? BesteldGerecht { get; set; }
        public Drank? Drank { get; set; }
        public Dessert? Dessert { get; set; }
        public int Aantal { get; set; } = 1; // standaard aantal is 1

        private bool IsVolledigMenu => BesteldGerecht != null && Drank != null && Dessert != null; // property die checkt of er een volledig menu is

        public decimal BerekenBedrag()
        {
            decimal totaal = 0;
            if (BesteldGerecht != null) totaal += BesteldGerecht.BerekenBedrag();
            if (Drank != null) totaal += Drank.BerekenBedrag();
            if (Dessert != null) totaal += Dessert.BerekenBedrag();
            // Check op volledig menu
            if (IsVolledigMenu) totaal *= 0.9m; // 10% korting
            return totaal * Aantal;
        }

        public override string ToString()
        {
            // wilde het op deze manier laten zien -- het kan korter dat weet ik
            var lijnen = new List<string>();
            
            lijnen.Add(Klant.ToString());
            if (BesteldGerecht != null) lijnen.Add(BesteldGerecht.ToString());
            if (Drank != null) lijnen.Add(Drank.ToString());
            if (Dessert != null) lijnen.Add(Dessert.ToString());

            lijnen.Add($"Aantal: {Aantal}");
            lijnen.Add($"Bedrag van deze bestelling: {BerekenBedrag():0.00} euro");

            return string.Join("\n", lijnen);
        }
    }
}