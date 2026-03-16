namespace CSharpPFOefeningen
{
    public class Spaarrekening : Rekening
    {
        public Spaarrekening(string rekeningnummer, decimal saldo, DateOnly creatieDatum, decimal intrest) : base(rekeningnummer, saldo, creatieDatum)
        {
            Intrest = intrest;
        }

        private decimal intrest;

        public decimal Intrest
        {
            get { return intrest; }
            set { if (value >= 0) intrest = value; }
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()}\nIntrest: {Intrest}";
        }
    }
}
