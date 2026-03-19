namespace Firma.Personeel
{
    public class Arbeider : Werknemer
    {
        // constructor met gebruik van de base class contructor
        // hier zijn alle parameters optioneel
        // public Arbeider(string naam = "onbekend", DateTime? inDienst = null, Geslacht geslacht = Geslacht.X, Afdeling? afdeling = null, decimal uurloon = 10m, byte ploegenstelsel = 3) : base(naam, inDienst, geslacht, afdeling)
        // {
        //     Uurloon = uurloon;
        //     Ploegenstelsel = ploegenstelsel;
        // }
        public Arbeider(string naam, DateTime inDienst, Geslacht geslacht, decimal uurloon, byte ploegenstelsel) : base(naam, inDienst, geslacht)
        {
            Uurloon = uurloon;
            Ploegenstelsel = ploegenstelsel;
        }

        private decimal uurloon;
        public decimal Uurloon { get { return uurloon; } set { if (value >= 0m) uurloon = value; } }

        private byte ploegenstelsel;
        public byte Ploegenstelsel  { get { return ploegenstelsel; } set { if (value >= 1 && value <= 3) ploegenstelsel = value; } }

        // overschrijven van de abstract property Premie
        public override decimal Premie
        {
            get { return Uurloon * 150m; }
        }

        // overschrijf de method van de interface IKost
        // public override decimal BerekenKostprijs()
        // {
        //     return Uurloon * 2000m;
        // }
        public override decimal BerekenKostprijs() => Uurloon * 2000m;

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
