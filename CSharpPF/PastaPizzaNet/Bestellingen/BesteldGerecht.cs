using Gerechten;

namespace PastaPizzaNet.Bestellingen
{
    public class BesteldGerecht:IBedrag
    {
        public required Gerecht Gerecht { get; set; } // Het gerecht moet er altijd zijn

        public Grootte Grootte { get; set; } = Grootte.Klein; // Standaard grootte is klein

        public List<Extra> Extras { get; set; } = []; // Standaard geen extra's -- kan ook new() of new List<Extra>() zijn -- maar een lege array is korter

        public decimal BerekenBedrag()
        {
            decimal totaal = Gerecht.Prijs;
            if (Grootte == Grootte.Groot) totaal += 3m; // Grote gerechten kosten 3 euro meer
            if (Extras.Count > 0) totaal += Extras.Count * 1m; // Elke extra kost 1 euro -- mits er extras zijn
            return totaal;
        }

        public override string ToString()
        {
            string extrasString = Extras.Count > 0 ? $" extra: {string.Join(" ", Extras)}" : "";
            return $"{Gerecht?.ToString()} ({Grootte}) {extrasString} (bedrag: {BerekenBedrag():0.00} euro)";
        }
    }
}
