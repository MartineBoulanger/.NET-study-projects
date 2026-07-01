namespace EindoefeningDesignPatterns.Decorator
{
    public class Slingers(IKerstboom kerstboom):KerstboomDecorator(kerstboom)
    {
        public override decimal Kostprijs() => base.Kostprijs() + 10m;
        public override string Print() => base.GedecoreerdeKerstboom.Print() + ", met slingers";
    }
}
