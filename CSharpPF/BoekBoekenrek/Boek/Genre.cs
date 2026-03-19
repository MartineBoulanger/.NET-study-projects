namespace BoekBoekenrek.Boek
{
    public class Genre
    {
        // property voor het genre zelf - met validatie
        public string Naam { get; set => field = !string.IsNullOrWhiteSpace(value) ? value : "Onbekend genre"; }

        // property om de class Doelgroep te gebruiken
        public Doelgroep Doelgroep { get; set; }

        // method Gegevens van de interface om de genre gegevens te tonen
        public string Gegevens()
        {
            return $"Genrenaam: {Naam}\n  Doelgroepgegevens: {Doelgroep?.Gegevens() ?? "Onbekende doelgroep"}";
        }
    }
}
