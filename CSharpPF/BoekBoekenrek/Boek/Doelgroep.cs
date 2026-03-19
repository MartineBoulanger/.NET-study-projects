namespace BoekBoekenrek.Boek
{
    public class Doelgroep
    {
        // property Leeftijd om de categorie te bepalen - met validatie
        private int leeftijd;
        public int Leeftijd {  get => leeftijd; set => leeftijd = value > 0 ? value : 0; }

        // property Categorie - met switch statement
        private string Categorie { get {
                return Leeftijd switch
                {
                    < 18 => "Jeugd",
                    >= 18 => "Volwassenen"
                };
            } }

        // method Gegevens van de interface om de doelgroep gegevens te tonen
        public string Gegevens() => $"\n    Leeftijd: {Leeftijd}\n    Categorie: {Categorie}";
    }
}
