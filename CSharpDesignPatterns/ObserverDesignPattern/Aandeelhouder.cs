namespace ObserverDesignPattern
{
    public class Aandeelhouder : IObserver
    {
        private string naam;
        public Aandeelhouder(string naam)
        {
            this.naam = naam;
        }
        public string Update(Aandeel aandeel)
        {
            return (naam + " koopt of verkoopt " + aandeel.naam + " met koers " + aandeel.koers + "\n");
        }
    }
}
