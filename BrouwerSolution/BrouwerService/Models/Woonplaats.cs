namespace KaasService.Models
{
    public class Woonplaats
    {
        public int Id { get; init; }
        public int Postcode { get; init; }
        public required string Naam { get; init; }
    }
}
