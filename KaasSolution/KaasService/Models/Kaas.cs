namespace KaasService.Models
{
    public class Kaas
    {
        public int Id { get; set; }
        public required string Naam { get; set; }
        public required string Soort { get; set; }
        public required string Smaak { get; set; }
    }
}
