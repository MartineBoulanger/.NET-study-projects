namespace CSharpPFOefeningen
{
    public class Klant
    {
        public required string Voornaam { get; set; }
        public required string Familienaam { get; set; }

        public string GetKlantInfo() => $"{Voornaam} {Familienaam}";
    }
}