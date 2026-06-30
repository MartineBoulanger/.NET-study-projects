using System.Text;

namespace ObserverDesignPattern
{
    public class Aandeel(int id, string naam, decimal koers)
    {
        public int id = id;
        public string naam = naam;
        public decimal koers = koers;
        public List<IObserver> observers = [];

        //public Aandeel(int id, string naam, decimal koers)
        //{
        //    this.id = id;
        //    this.naam = naam;
        //    this.koers = koers;
        //}

        private string NotifyObservers()
        {
            StringBuilder sb = new();
            foreach (var obs in observers) sb.Append(obs.Update(this));
            return sb.ToString();
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public string SetKoers(decimal koers)
        {
            this.koers = koers;
            StringBuilder sb = new();
            sb.Append($"De koers van {naam} is gewijzigd naar {koers} \n");
            sb.Append(NotifyObservers());
            return sb.ToString();
        }
    }
}
