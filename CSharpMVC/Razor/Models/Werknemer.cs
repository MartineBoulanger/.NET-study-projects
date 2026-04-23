using System.ComponentModel.DataAnnotations;

namespace Razor.Models
{
    public class Werknemer
    {
        public string Voornaam { get; set; }
        [DisplayFormat(DataFormatString = "{0:€ #,##0.00}")]
        public decimal Wedde{ get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Indienst { get; set; }
    }
}
