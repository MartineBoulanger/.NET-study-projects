namespace Firma
{
    public partial class Klant
    {
		private string naam;

		public required string Naam
		{
			get { return naam; }
			set { naam = value; NaamChanged(naam); } // bij set zetten voor als de method gebruikt gaat worden ergens anders
		}

		partial void NaamChanged(string naam); // partial method definieren
	}

    public partial class Klant
    {
	    partial void NaamChanged(string naam)
        {
            Console.WriteLine($"Naam gewijzigd naar {naam}.");
        }
    }
}
