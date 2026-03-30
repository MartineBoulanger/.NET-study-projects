using PastaPizzaNet;

namespace Dranken
{
    public class Frisdrank:Drank
    {
        const decimal prijsFrisdrank = 2m;
        public Frisdrank(DrankNaam naam) : base(naam, prijsFrisdrank) 
        {
            if (naam is DrankNaam.Thee or DrankNaam.Koffie) throw new Exception("Onbekende frisdrank!");
        }
        public override decimal BerekenBedrag() => Prijs = prijsFrisdrank;
        public override string ToString() => base.ToString();
    }
}
