namespace BIBData.Models
{
    public class Uitleenobject
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int Jaar { get; set; }
        public Status Status { get; set; }
        public decimal Kostprijs { get; set; }
        public string? ImageUrl { get; set; }
    }
}
