namespace CSharpPFOefeningen
{
    public class Kasbon:ISpaarmiddel
    {
        private readonly DateOnly VroegsteDatum = new(1900, 1, 1);

        public DateOnly AankoopDatum { get => field; set { field = value >= VroegsteDatum ? value : throw new CustomExceptions.FouteCreatieDatumException("De creatie datum ligt voor 1/1/1900! ", value); } }

        public decimal Bedrag { get => field; set { field = value > 0m ? value : throw new CustomExceptions.NegatieveWaardeException("Het bedrag moet positief zijn!", value); } }

        public int Looptijd { get => field; set { field = value > 0 ? value : throw new Exception("De looptijd moet positief zijn!"); } }

        public decimal Intrest { get => field; set { field = value > 0m ? value : throw new CustomExceptions.NegatieveWaardeException("De intrest moet positief zijn!", value); } }

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