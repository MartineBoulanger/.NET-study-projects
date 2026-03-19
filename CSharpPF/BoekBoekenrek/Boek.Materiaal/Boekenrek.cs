namespace BoekBoekenrek.Boek.Materiaal
{
    public class Boekenrek(float hoogte, float breedte, decimal aankoopprijs):IVoorwerp
    {
        // constructor met optionele parameters
        public Boekenrek(): this(3f, 2.5f, 200m) { }

        // properties met validatie
        public float Hoogte { get; set; } = hoogte > 0f ? hoogte : 0f;
        public float Breedte { get; set; } = breedte > 0f ? breedte : 0f;
        public decimal Aankoopprijs { get; set; } = aankoopprijs > 0m ? aankoopprijs : 0m;

        // method Winst van de interface om de winst van het boekenrek te tonen
        public decimal Winst => Aankoopprijs * 2;

        // method Gegevens van interface om alle gegevens van het boekenrek te tonen
        public string Gegevens() => $"Breedte: {Breedte}\nHoogte: {Hoogte}\nAankoopprijs: {Aankoopprijs} euro\nWinst: {Winst:0.00} euro";
    }
}
