namespace BoekBoekenrek.Boek
{
    // abstract class betekent dat er van de class geen objecten gemaakt kunnen worden.
    public abstract class Boek:IVoorwerp
    {
        // readonly property omdat alle boeken dezelfde eigenaar hebben
        // maak deze variabele static of een constante -- geen fout, maar een advies
        //private readonly string Eigenaar = "VDAB";
        //private static readonly string Eigenaar = "VDAB";
        const string Eigenaar = "VDAB";

        // properties die ingevuld moeten worden door de user - met validatie
        public string Titel { get; set => field = !string.IsNullOrWhiteSpace(value) ? value : "Onbekende titel"; }
        public string Auteur { get; set => field = !string.IsNullOrWhiteSpace(value) ? value : "Onbekende auteur"; }
        public decimal Aankoopprijs { get; set => field = value > 0m ? value : 0m; }

        // property om de class Genre te gebruiken
        public Genre Genre { get; set; }

        // initialiseren van de property Winst dat in de interface staat
        //public abstract decimal Winst(); // zie interface file voor uitleg
        public abstract decimal Winst { get; }

        // constructor met parameters
        public Boek(string titel, string auteur, decimal aankoopprijs, Genre genre)
        {
            Titel = titel;
            Auteur = auteur;
            Aankoopprijs = aankoopprijs;
            Genre = genre;
        }

        // method Gegevens van de interface gebruiken om gegevens te tonen
        // moet een virtual string zijn! -- grote fout hier
        //public string Gegevens() 
        public virtual string Gegevens()
        {
            return $"Titel: {Titel}\nAuteur: {Auteur}\nEigenaar: {Eigenaar}\nPrijs: {Aankoopprijs} euro\n" + 
                $"Winst: {Winst:0.00} euro\nGenregegevens:\n  {Genre?.Gegevens() ?? "Onbekend genre"}";
        }
    }
}
