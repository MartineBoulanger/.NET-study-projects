namespace Model.Entities
{
    public class Rekening
    {
        public string RekeningNr { get; set; } = null!;
        public int KlantNr { get; set; }
        public decimal Saldo { get; set; }
        public char Soort { get; set; }

        // associatie
        public Klant Klant { get; set; } = null!;

        public void Storten(decimal bedrag) => Saldo += bedrag;
    }
}
