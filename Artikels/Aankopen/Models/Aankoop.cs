namespace Aankopen.Models
{
    public class Aankoop
    {
        public int Id { init; get; }
        public int ArtikelId { init; get; }
        public DateTime Datum { init; get; }
        public int Aantal { init; get; }
        public decimal Prijs { init; get; }
    }
}
