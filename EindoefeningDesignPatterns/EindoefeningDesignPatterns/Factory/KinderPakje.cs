namespace EindoefeningDesignPatterns.Factory
{
    public class KinderPakje(decimal prijs):Pakje
    {
        public override decimal Prijs => prijs;
        public override string ToString() => $"Kind ({Prijs} euro)";
    }
}
