namespace BoekBoekenrek.Boek
{
    public class Doelgroep
    {
        // property Leeftijd om de categorie te bepalen - met validatie
        // best required maken ivm Genre class constructor -- medium fout
        //private int leeftijd;
        //public int Leeftijd {  get => leeftijd; set => leeftijd = value > 0 ? value : 0; }
        public required int Leeftijd {  get; set => field = value > 0 ? value : 0; }

        // property Categorie - met switch statement
        // Kan hier ook een enum definieren -- geen fout, maar wel iets wat ik had kunnen laten zien.
        public enum Category { Jeugd, Volwassenen } // kan enum ook in een aparte file zetten, maar is hier niet echt nodig
        private string Categorie { get {
                return Leeftijd switch
                {
                    //< 18 => "Jeugd",
                    //>= 18 => "Volwassenen"
                    < 18 => Category.Jeugd.ToString(),
                    >= 18 => Category.Volwassenen.ToString()
                };
            } }

        // method Gegevens van de interface om de doelgroep gegevens te tonen
        public string Gegevens() => $"\n    Leeftijd: {Leeftijd}\n    Categorie: {Categorie}";
    }
}
