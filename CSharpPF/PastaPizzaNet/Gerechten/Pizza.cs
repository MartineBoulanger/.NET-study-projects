namespace Gerechten
{
    public class Pizza:Gerecht
    {
        public List<string> Onderdelen { get; set; } = new List<string>(); // lege lijst as default, zodat we altijd een lijst hebben, ook als er geen onderdelen zijn

        public Pizza(string naam, decimal prijs, List<string> onderdelen):base(naam, prijs)
        {
            Onderdelen = onderdelen;
        }

        public override decimal BerekenBedrag() => Prijs;

        public override string ToString() => $"{base.ToString()} {string.Join(" - ", Onderdelen)}";
  }
}
