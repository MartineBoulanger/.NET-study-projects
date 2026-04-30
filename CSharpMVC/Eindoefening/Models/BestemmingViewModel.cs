using Eindoefening.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Eindoefening.Models
{
    public class BestemmingViewModel
    {
        [Required(ErrorMessage = "Bestemming is verplicht")]
        [NoWhiteSpace(ErrorMessage = "Bestemming mag geen lege string of spatie zijn")]
        public string Bestemming { get; set; }

        public List<string> Bestemmingen { get; set; } = new List<string>();
    }
}
