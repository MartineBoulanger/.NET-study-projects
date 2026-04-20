namespace BierenApplication.Models
{
    public class Bier
    {
        public required int Id { get; init; }
        public required string Naam { get; set; }
        public required float Alcohol { get; set; }
    }
}
