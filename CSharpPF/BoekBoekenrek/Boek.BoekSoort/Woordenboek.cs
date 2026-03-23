namespace BoekBoekenrek.Boek.BoekSoort
{
    public class Woordenboek:Boek
    {
        // property specifiek voor een woordenboek - met validatie
        public string Taal {  get; set => field = !string.IsNullOrWhiteSpace(value) ? value : "Onbekende taal"; }

        // constructor met parameters
        public Woordenboek (string titel, string auteur, decimal aankoopprijs, Genre genre, string taal): base(titel, auteur, aankoopprijs, genre)
        {
            Taal = taal;
        }

        // method Winst van de interface om de winst van het woordenboek te tonen
        // zie interface file voor uitleg
        //public override decimal Winst() => Aankoopprijs * 1.75m;
        public override decimal Winst => Aankoopprijs * 1.75m;

        // method Gegevens van de interface om alle gegevens van het woordenboek te tonen
        // geen new gebruiken maar override! - zie Boek file
        // new maakt een kopie van de base string - override overschrijft -> minder geheugen - is dus beter
        //public new string Gegevens() => $"{base.Gegevens()}\nTaal: {Taal}"; 
        public override string Gegevens() => $"{base.Gegevens()}\nTaal: {Taal}";
    }
}
