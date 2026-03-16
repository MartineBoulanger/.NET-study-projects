namespace CSharpPFCursus
{
    internal class Bediende : Werknemer
    {
        public Bediende(string naam, DateTime inDienst, Geslacht geslacht, decimal wedde) : base(naam, inDienst,geslacht)
        {
            Wedde = wedde;
        }

        private decimal wedde;

        public decimal Wedde
        {
            get { return wedde; }
            set { if (value >= 0m) wedde = value; }
        }

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
