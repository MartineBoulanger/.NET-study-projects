namespace EindoefeningDesignPatterns.Decorator
{
    public abstract class KerstboomDecorator(IKerstboom kerstboom):IKerstboom
    {
        protected IKerstboom GedecoreerdeKerstboom { get; set; } = kerstboom ?? null!;
        public virtual decimal Kost() => kerstboom?.Kost() ?? 0m;
        public abstract string Print();
    }
}
