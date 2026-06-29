namespace SingletonDesignPattern
{
    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> _lazyInstantie = new(() => new Singleton());
        private Singleton() { } // private contructor
        public static Singleton GetInstance() => _lazyInstantie.Value;
        public void ZegGoeiedag() => Console.WriteLine("Dag iedereen !");
    }
}
