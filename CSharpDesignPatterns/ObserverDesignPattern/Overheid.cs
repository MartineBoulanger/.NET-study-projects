namespace ObserverDesignPattern
{
    public class Overheid : IObserver
    {
        private const string naam = "Overheid";

        public string Update(Aandeel aandeel) => naam + " koopt of verkoopt " + aandeel.naam + " met koers " + aandeel.koers + "\n";
    }
}
