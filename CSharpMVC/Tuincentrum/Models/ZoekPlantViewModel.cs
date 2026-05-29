using System.ComponentModel.DataAnnotations;

namespace Tuincentrum.Models
{
    public class ZoekPlantViewModel
    {
        [Display(Name = "Minimumbedrag:")]
        [Required(ErrorMessage = "Verplicht")]
        public decimal Vanaf { get; set; }
        public List<Plant> Planten { get; set; } = new List<Plant>();
    }
}
