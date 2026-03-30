namespace PastaPizzaNet
{
    public class Klant
    {
        public int KlantID { get; init; }
        public string Naam { get; set => field = !string.IsNullOrWhiteSpace(value) ? value : "Onbekende klant"; }
        public Klant(int klantID, string naam = "")
        {
            KlantID = klantID;
            Naam = naam;
        }
        public override string ToString() => $"Klant: {Naam}";
    }
}
