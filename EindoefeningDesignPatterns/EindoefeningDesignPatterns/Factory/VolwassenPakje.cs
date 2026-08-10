namespace EindoefeningDesignPatterns.Factory
{
    public class VolwassenPakje(decimal prijs):Pakje
    {
        public override decimal Prijs => prijs;
        public override string ToString() => $"Volwassene ({Prijs} euro)";
    }
}
