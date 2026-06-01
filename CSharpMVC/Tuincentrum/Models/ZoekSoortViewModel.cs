using System.ComponentModel.DataAnnotations;

namespace Tuincentrum.Models
{
    public class ZoekSoortViewModel
    {
        [Display(Name = "Begin soortnaam:")]
        [Required(ErrorMessage = "Verplicht")]
        [StringLength(8, ErrorMessage = "VerkeerdeLengte", MinimumLength = 2)]
        public string BeginNaam { get; set; }
        public List<Soort> Soorten { get; set; } = new List<Soort>();
    }
}
