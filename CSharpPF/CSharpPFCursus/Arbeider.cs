namespace CSharpPFCursus
{
    public class Arbeider : Werknemer
    {
        // constructor met gebruik van de base class contructor
        public Arbeider(string naam, DateTime inDienst, Geslacht geslacht, decimal uurloon, byte ploegenstelsel) : base(naam, inDienst, geslacht)
        {
            Uurloon = uurloon;
            Ploegenstelsel = ploegenstelsel;
        }

        private decimal uurloon;
        public decimal Uurloon { get { return uurloon; } set { if (value >= 0m) uurloon = value; } }

        private byte ploegenstelsel;
        public byte Ploegenstelsel  { get { return ploegenstelsel; } set { if (value >= 1 && value <= 3) ploegenstelsel = value; } }

        // overriding van de GetInfo method die in de base class zit
        public override string GetInfo()
        {
            return $"{base.GetInfo()}\nUurloon: {Uurloon}\nPloegenstelsel: {Ploegenstelsel}";
        }

        public override string ToString()
        {
            return $"{base.ToString()} {Uurloon} euro/uur";
        }
    }
}
