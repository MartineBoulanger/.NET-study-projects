namespace EindoefeningDesignPatterns.Inheritance
{
    public class BinnenVerlichting:Verlichting
    {
        public override decimal Prijs => 50m;
        public override string ToString() => "Binnenverlichting";
    }
}
