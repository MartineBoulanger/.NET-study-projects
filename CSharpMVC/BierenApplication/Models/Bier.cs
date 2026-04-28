using System.ComponentModel.DataAnnotations;

namespace BierenApplication.Models
{
    public class Bier
    {
        [DisplayFormat(DataFormatString = "{0:D3}")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Naam is een verpicht veld")]
        [StringLength(20, ErrorMessage = "Max. {1} tekens voor {0}")]
        public string Naam { get; set; }

        [UIHint("percentage")]
        [Range(0, 15, ErrorMessage = "{0} minimum {1}, maximum {2}")]
        public float Alcohol { get; set; }

        [DisplayFormat(DataFormatString = "€{0:#,##0.00}")]
        public decimal Prijs { get; set; }
    }
}
