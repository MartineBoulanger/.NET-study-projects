using System.Text;

namespace ObserverDesignPattern
{
    public class Brand(string adres)
    {
        public string Adres = adres;
        List<IBrandObserver> observers = [];

        string NotifyObservers()
        {
            StringBuilder sb = new();
            foreach (var obs in observers) sb.Append(obs.Verwittigen(this));
            return sb.ToString();
        }

        public void AddObserver(IBrandObserver brandObserver)
        {
            observers.Add(brandObserver);
        }
        public void RemoveObserver(IBrandObserver brandObserver)
        {
            observers.Remove(brandObserver);
        }
        public string BreektUit()
        {
            StringBuilder sb = new();
            sb.Append($"Brand uitgebroken op {Adres}\n");
            sb.Append(NotifyObservers());
            return sb.ToString();
        }
    }

    public abstract class Persoon
    {
        public string naam;
    }

    public class Brandweerman : Persoon, IBrandObserver
    {
        public Brandweerman(string naam)
        {
            this.naam = naam;
        }
        public string Verwittigen(Brand brand) => (naam + " is vewittigd van de brand op " + brand.Adres + " en komt helpen blussen\n");
    }

    public class Bewoner : Persoon, IBrandObserver
    {
        public Bewoner(string naam)
        {
            this.naam = naam;
        }
        public string Verwittigen(Brand brand) => (naam + " is verwittigd van de brand op " + brand.Adres + " en vlucht weg\n");
    }
}
