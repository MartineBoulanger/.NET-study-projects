namespace FacadeDesignPattern
{
    public class CDSpeler:IGeluidsbron
    {
        public void Start()
        {
            Console.WriteLine("CD-speler gestart");
        }

        public void Stop()
        {
            Console.WriteLine("CD-speler gestopt");
        }
    }
}
