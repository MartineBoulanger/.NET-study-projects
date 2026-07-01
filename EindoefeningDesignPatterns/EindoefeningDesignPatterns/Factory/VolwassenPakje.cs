namespace EindoefeningDesignPatterns.Factory
{
    public class VolwassenPakje:Pakje
    {
        public override decimal Prijs => 25m;
        public override string ToString() => $"Volwassene({Prijs} euro)";
    }
}
