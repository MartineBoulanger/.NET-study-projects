using PastaPizzaNet;

namespace Gerechten
{
    public class Pizza:Gerecht
    {
        public required List<string> Onderdelen { get; set; }
        public Pizza(string naam, decimal prijs, List<string> onderdelen):base(naam, prijs)
        {
            Onderdelen = onderdelen;
        }
        public override decimal BerekenBedrag() => Prijs;
        public override string ToString()
        {
            string onderdelenString = string.Join(" - ", Onderdelen);
            return $"{base.ToString()} {onderdelenString}";
        }
    }
}
