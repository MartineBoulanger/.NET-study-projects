namespace EindoefeningDesignPatterns.Singleton
{
    public sealed class Kerstdag
    {
        private static readonly Lazy<Kerstdag> _instance = new(() => new Kerstdag());
        private Kerstdag() { }
        public static Kerstdag GetInstance() => _instance.Value;
        public override string ToString() => "Kerstmis wordt gevierd !";
    }
}
