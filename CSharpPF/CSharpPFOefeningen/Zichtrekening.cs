namespace CSharpPFOefeningen
{
    public class Zichtrekening : Rekening
    {
		public Zichtrekening(string rekeningnummer, decimal saldo, DateOnly creatieDatum, decimal maxKrediet) : base(rekeningnummer, saldo, creatieDatum)
		{
			MaxKrediet = maxKrediet;
		}

		private decimal maxKrediet;

		public decimal MaxKrediet
		{
			get { return maxKrediet; }
			set { if (value <= 0m) maxKrediet = value; }
		}

		public override string GetInfo()
		{
			return $"{base.GetInfo()}\nMaximum krediet: {MaxKrediet}";
		}
	}
}
