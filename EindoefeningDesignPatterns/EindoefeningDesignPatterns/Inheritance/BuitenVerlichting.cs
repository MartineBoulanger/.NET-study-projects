namespace EindoefeningDesignPatterns.Inheritance
{
    public class BuitenVerlichting:Verlichting
    {
        public override decimal Prijs => 75m;
        public override string ToString() => "Buitenverlichting";
    }
}
