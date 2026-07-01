namespace EindoefeningDesignPatterns.Factory
{
    public class KinderPakje:Pakje
    {
        public override decimal Prijs => 10m;
        public override string ToString() => $"Kind({Prijs} euro)";
    }
}
