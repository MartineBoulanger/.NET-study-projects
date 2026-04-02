using PastaPizzaNet;

namespace Dranken
{
    public class Frisdrank:Drank
    {
        public Frisdrank(DrankNaam naam):base(naam, 2m) // geef hier de vast prijs van de frisdrank mee aan de base class
        {
            if (naam is DrankNaam.Thee or DrankNaam.Koffie) throw new Exception("Onbekende frisdrank!");
        }

        public override decimal BerekenBedrag() => Prijs;

        public override string ToString() => base.ToString();
  }
}
