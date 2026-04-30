using BierenApplication.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BierenApplication.Models
{
    public class Bier
    {
        [DisplayFormat(DataFormatString = "{0:D3}")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bier naam is verpicht")]
        [StringLength(20, ErrorMessage = "Max. {1} tekens voor {0}")]
        public string Naam { get; set; }

        [UIHint("percentage")]
        [AlcoholGrenzen(ErrorMessage = "{0} heeft een ongeldige waarde")]
        public float Alcohol { get; set; }

        [DisplayFormat(DataFormatString = "€{0:#,##0.00}")]
        public decimal Prijs { get; set; }
    }
}
