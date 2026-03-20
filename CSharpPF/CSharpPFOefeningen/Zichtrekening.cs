namespace CSharpPFOefeningen
{
    public class Zichtrekening : Rekening
    {
		public Zichtrekening(string rekeningnummer, decimal saldo, DateOnly creatieDatum, Klant eigenaar, decimal maxKrediet) : base(rekeningnummer, saldo, creatieDatum, eigenaar)
		{
			MaxKrediet = maxKrediet;
		}

		//private decimal maxKrediet;

		public decimal MaxKrediet
		{
			get;
			//set { if (value <= 0m) maxKrediet = value; }
			set => field = value > 0m ? throw new CustomExceptions.PositieveWaardeException("De max crediet moet negatief zijn!", value) : value;
    }

		public override string GetInfo()
		{
			return $"{base.GetInfo()}\nMaximum krediet: {MaxKrediet}";
		}
	}
}
