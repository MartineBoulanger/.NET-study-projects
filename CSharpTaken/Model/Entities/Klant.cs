using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
    public class Klant
    {
        [Key]
        public int KlantNr { get; set; }

        public string Voornaam { get; set; } = null!;

        // associatie
        public ICollection<Rekening> Rekeningen { get; set; } = [];
    }
}
