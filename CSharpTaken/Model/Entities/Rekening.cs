namespace Model.Entities
{
    public class Rekening
    {
        public string RekeningNr { get; set; }
        public int KlantNr { get; set; }
        public decimal Saldo { get; set; }
        public char Soort { get; set; }

        // associatie
        public Klant Klant { get; set; }

        public void Storten(decimal bedrag)
        {
            Saldo += bedrag;
        }
    }
}
