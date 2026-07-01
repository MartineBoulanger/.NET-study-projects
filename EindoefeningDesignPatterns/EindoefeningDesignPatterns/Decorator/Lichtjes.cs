namespace EindoefeningDesignPatterns.Decorator
{
    public class Lichtjes(IKerstboom kerstboom):KerstboomDecorator(kerstboom)
    {
        public override decimal Kostprijs() => base.Kostprijs() + 25m;
        public override string Print() => base.GedecoreerdeKerstboom.Print() + ", met lichtjes";
    }
}
