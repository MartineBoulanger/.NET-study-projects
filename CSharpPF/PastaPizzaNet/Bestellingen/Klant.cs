namespace PastaPizzaNet.Bestellingen
{
    public class Klant
    {
        public required int KlantID { get; init; }

        public string Naam { get; set; } = "Onbekende klant";

        public override string ToString() => $"Klant: {Naam}";
    }
}