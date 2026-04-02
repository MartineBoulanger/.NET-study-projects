using PastaPizzaNet;

namespace Dranken
{
    public class Warmedrank:Drank
    {
        const decimal prijsWarmedrank = 2.5m; // om te laten zien dan een vaste waarde ook in een const gezet kan worden bovenaan (zodat het makkelijker is om deze te wijzigen indien nodig)

        public Warmedrank(DrankNaam naam):base(naam, prijsWarmedrank)
        {
            if (naam is not (DrankNaam.Thee or DrankNaam.Koffie)) throw new Exception("Onbekende warme drank!");
        }

        public override decimal BerekenBedrag() => Prijs;

        public override string ToString() => base.ToString();
    }
}
