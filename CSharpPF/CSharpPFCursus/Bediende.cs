namespace CSharpPFCursus
{
    public class Bediende : Werknemer
    {
        // met de Afdeling als parameter
        // public Bediende(string naam, DateTime inDienst, Geslacht geslacht, Afdeling afdeling, decimal wedde) : base(naam, inDienst, geslacht, afdeling)
        // {
        //     Wedde = wedde;
        // }
        public Bediende(string naam, DateTime inDienst, Geslacht geslacht, decimal wedde) : base(naam, inDienst, geslacht)
        {
            Wedde = wedde;
        }

        private decimal wedde;

        public decimal Wedde
        {
            get { return wedde; }
            set { if (value >= 0m) wedde = value; }
        }

        // overschrijven van de abstract property Premie
        public override decimal Premie
        {
            get { return Wedde * 2m; }
        }

        // overschrijf de method van de interface IKost
        // public override decimal BerekenKostprijs()
        // {
        //     return Wedde * 12m;
        // }
        public override decimal BerekenKostprijs() => Wedde * 12m;

        public override string GetInfo()
        {
            return $"{base.GetInfo()}\nWedde: {Wedde}";
        }

        public override string ToString()
        {
            return $"{base.ToString()} {Wedde} euro/maand";
        }
    }
}
