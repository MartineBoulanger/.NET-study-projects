namespace CSharpPFOefeningen
{
    public class Kasbon:ISpaarmiddel
    {
        private readonly DateOnly VroegsteDatum = new(1900, 1, 1);

        public DateOnly AankoopDatum { get => field; set { field = value >= VroegsteDatum ? value : VroegsteDatum; } }

        public decimal Bedrag { get => field; set { field = value > 0m ? value : 0m; } }

        public int Looptijd { get => field; set { field = value > 0 ? value : 0; } }

        public decimal Intrest { get => field; set { field = value > 0m ? value : 0m; } }

        public Klant Eigenaar { get; set; }

        public Kasbon(DateOnly aankoopDatum, decimal bedrag, int looptijd, decimal intrest, Klant eigenaar)
        {
            AankoopDatum = aankoopDatum;
            Bedrag = bedrag;
            Looptijd = looptijd;
            Intrest = intrest;
            Eigenaar = eigenaar;
        }

        public string GetInfo()
        {
            return $"Eigenaar: {Eigenaar?.GetKlantInfo() ?? "Onbekend"}\nAankoop Datum: {AankoopDatum}\nBedrag: {Bedrag} euro\nIntrest: {Intrest}\nLooptijd: {Looptijd} jaar";
        }
    }
}