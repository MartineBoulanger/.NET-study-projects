namespace BrouwerService.Models
{
    public class Filiaal
    {
        public int Id { get; init; }
        public required string Naam { get; init; }
        public int Huurprijs { get; init; }
        public int WoonplaatsId { get; init; }
        public required Woonplaats Woonplaats { get; init; }
    }
}
