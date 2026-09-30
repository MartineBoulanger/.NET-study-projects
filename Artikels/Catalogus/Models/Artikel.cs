namespace Catalogus.Models
{
    public class Artikel
    {
        public int Id { init; get; }
        public required string Naam { init; get; }
        public DateTime Gemaakt { init; get; } = DateTime.Now;
    }
}
