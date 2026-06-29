namespace SingletonDesignPattern
{
    public sealed class Versnellingsbak
    {
        private static readonly Lazy<Versnellingsbak> _lazyInstantie = new(() => new Versnellingsbak());
        private int versnelling;
        private Versnellingsbak() { }
        public static Versnellingsbak GetInstance() => _lazyInstantie.Value;
        public void GaNaarVersnelling(int nversnelling)
        {
            if ((nversnelling < -1) || (nversnelling > 5))
                Console.WriteLine("Verkeerde versnelling : {0}", nversnelling);
            else
            {
                if (nversnelling == -1)
                    Console.WriteLine("Van {0}e versnelling in achteruit",
                    this.versnelling);
                else
                    Console.WriteLine("Van {0}e versnelling in {1}e versnelling",
                    this.versnelling, nversnelling);
                this.versnelling = nversnelling;
            }
        }
    }
}
