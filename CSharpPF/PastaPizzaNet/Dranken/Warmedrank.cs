using PastaPizzaNet;

namespace Dranken
{
    public class Warmedrank:Drank
    {
        const decimal prijsWarmedrank = 2.5m;
        public Warmedrank(DrankNaam naam) : base(naam, prijsWarmedrank)
        {
            if (naam is not (DrankNaam.Thee or DrankNaam.Koffie)) throw new Exception("Onbekende warme drank!");
        }
        public override decimal BerekenBedrag() => Prijs = prijsWarmedrank;
        public override string ToString() => base.ToString();
    }
}
