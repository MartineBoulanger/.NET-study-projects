namespace EindoefeningDesignPatterns.Factory
{
    public class JeugdPakje:Pakje
    {
        public override decimal Prijs => 15m;
        public override string ToString() => $"Jeugd({Prijs} euro)";
    }
}
