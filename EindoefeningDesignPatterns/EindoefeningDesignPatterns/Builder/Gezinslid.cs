namespace EindoefeningDesignPatterns.Builder
{
    public class Gezinslid(string naam, int leeftijd)
    {
        public string Naam { get; set; } = naam;
        public int Leeftijd { get; set; } = leeftijd;

        public override string ToString() => $"{Naam} - {Leeftijd} jaar";
    }
}
