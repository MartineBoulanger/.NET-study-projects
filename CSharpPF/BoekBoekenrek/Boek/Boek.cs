namespace BoekBoekenrek.Boek
{
    public abstract class Boek:IVoorwerp
    {
        // readonly property omdat alle boeken dezelfde eigenaar hebben
        private readonly string Eigenaar = "VDAB";

        // properties die ingevuld moeten worden door de user - met validatie
        public string Titel { get; set => field = !string.IsNullOrWhiteSpace(value) ? value : "Onbekende titel"; }
        public string Auteur { get; set => field = !string.IsNullOrWhiteSpace(value) ? value : "Onbekende auteur"; }
        public decimal Aankoopprijs { get; set => field = value > 0m ? value : 0m; }

        // property om de class Genre te gebruiken
        public Genre Genre { get; set; }

        // initialiseren van de method Winst dat in de interface staat
        public abstract decimal Winst();

        // constructor met parameters
        public Boek(string titel, string auteur, decimal aankoopprijs, Genre genre)
        {
            Titel = titel;
            Auteur = auteur;
            Aankoopprijs = aankoopprijs;
            Genre = genre;
        }

        // method Gegevens van de interface gebruiken om gegevens te tonen
        public string Gegevens()
        {
            return $"Titel: {Titel}\nAuteur: {Auteur}\nEigenaar: {Eigenaar}\nPrijs: {Aankoopprijs} euro\n" + 
                $"Winst: {Winst():0.00} euro\nGenregegevens:\n  {Genre?.Gegevens() ?? "Onbekend genre"}";
        }
    }
}
