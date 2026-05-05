namespace Model.Entities
{
    public class Klant
    {
        public int KlantNr { get; set; }
        public string Voornaam { get; set; } = null!;

        // associatie
        public ICollection<Klant> Rekeningen { get; set; } = [];
    }
}
