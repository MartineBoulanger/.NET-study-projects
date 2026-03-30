using PastaPizzaNet;

namespace Gerechten
{
    public class BesteldGerecht:IBedrag
    {
        public required Gerecht Gerecht { get; init; }
        public Grootte Grootte { get; set; } = Grootte.Klein;
        public List<Extra> Extras { get; set; } = new();
        public BesteldGerecht(Gerecht gerecht, Grootte grootte, List<Extra> extras)
        {
            Gerecht = gerecht;
            Grootte = grootte;
            Extras = extras ?? [];
        }
        public decimal BerekenBedrag()
        {
            decimal totaal = Gerecht.Prijs;
            if (Grootte == Grootte.Groot) totaal += 3m; // Grote gerechten kosten 3 euro meer
            totaal += Extras.Count * 1m; // Elke extra kost 1 euro
            return totaal;
        }
        public override string ToString()
        {
            string extrasString = Extras.Count > 0 ? $" extra: {string.Join(" ", Extras)}" : "";
            return $"{Gerecht?.ToString()} ({Grootte}) {extrasString} (bedrag: {BerekenBedrag():0.00} euro)";
        }
    }
}
