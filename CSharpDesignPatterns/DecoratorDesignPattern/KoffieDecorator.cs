namespace DecoratorDesignPattern
{
    public abstract class KoffieDecorator(IKoffie koffie) : IKoffie
    {
        protected IKoffie GedecoreerdeKoffie { get; set; } = koffie;
        public abstract string Bereidingswijze();
        public abstract decimal Kost();
    }
}
