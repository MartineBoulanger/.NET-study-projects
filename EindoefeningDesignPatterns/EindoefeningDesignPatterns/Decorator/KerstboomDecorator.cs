namespace EindoefeningDesignPatterns.Decorator
{
    public abstract class KerstboomDecorator(IKerstboom kerstboom):IKerstboom
    {
        protected IKerstboom? GedecoreerdeKerstboom { get; set; } = kerstboom;
        public virtual decimal Kostprijs() => kerstboom?.Kostprijs() ?? 0m;
        public abstract string Print();
    }
}
