namespace SingletonDesignPattern
{
    public sealed class Motor
    {
        private static readonly Lazy<Motor> _lazyInstantie = new(() => new Motor());
        private bool gestart;
        private Motor() { }
        public static Motor GetInstance() => _lazyInstantie.Value;
        public void Start()
        {
            if (!gestart)
            {
                gestart = true;
                Console.WriteLine("Motor werd gestart.");
            }
            else
                Console.WriteLine("Motor werd reeds gestart.");
        }
        public void Stop()
        {
            if (gestart)
            {
                gestart = false;
                Console.WriteLine("Motor werd gestopt.");
            }
            else
                Console.WriteLine("Motor werd reeds gestopt.");
        }
    }
}
