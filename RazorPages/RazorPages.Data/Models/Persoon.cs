using System.ComponentModel.DataAnnotations;

namespace RazorPages.Data.Models
{
    public class Persoon
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Verplicht veld")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Verplicht veld")]
        public string Familienaam { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Geboren { get; set; }

        public Geslacht Geslacht { get; set; }
        public bool Gehuwd { get; set; }
        public string? Opmerkingen { get; set; }
    }
}
