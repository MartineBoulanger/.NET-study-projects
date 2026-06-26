namespace FacadeDesignPattern
{
    public class Radio:IGeluidsbron
    {
        public void Start()
        {
            Console.WriteLine("radio gestart");
        }

        public void Stop()
        {
            Console.WriteLine("radio gestopt");
        }
    }
}
