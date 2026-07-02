namespace EindoefeningDesignPatterns.Factory
{
    public class JeugdPakje(decimal prijs):Pakje
    {
        public override decimal Prijs => prijs;
        public override string ToString() => $"Jeugd ({Prijs} euro)";
    }
}
