namespace BoekBoekenrek.Boek.BoekSoort
{
    public class Leesboek:Boek
    {
        // propery specifiek voor een leesboek - met validatie
        public string Onderwerp {  get; set => field = !string.IsNullOrWhiteSpace(value) ? value : "Onbekend onderwerp"; }

        // constructor met parameters
        public Leesboek(string titel, string auteur, decimal aankoopprijs, Genre genre, string onderwerp): base(titel, auteur, aankoopprijs, genre)
        {
            Onderwerp = onderwerp;
        }

        // method Winst van de interface om de winst van het leesboek te tonen
        public override decimal Winst() => Aankoopprijs * 1.5m;

        // method Gegevens van de interface om alle gegevens van het leesboek te tonen
        public new string Gegevens() => $"{base.Gegevens()}\nOnderwerp: {Onderwerp}";
    }
}
