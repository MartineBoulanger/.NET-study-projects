namespace EindoefeningDesignPatterns.Decorator
{
    public class Ballen(IKerstboom kerstboom):KerstboomDecorator(kerstboom)
    {
        public override decimal Kostprijs() => base.Kostprijs() + 15m;
        public override string Print() => base.GedecoreerdeKerstboom.Print() + ", met ballen";
    }
}
