using System.ComponentModel.DataAnnotations;

namespace BierenApplication.Models
{
    public class VanTotAlcoholViewModel:IValidatableObject
    {
        [Display(Name = "Van alcohol")]
        [Required(ErrorMessage = "Van alcohol is verplicht")]
        public float VanAlcohol { get; set; }

        [Display(Name = "Tot alcohol")]
        [Required(ErrorMessage = "Tot alcohol is verplicht")]
        public float TotAlcohol { get; set; }

        public List<Bier>? Bieren { get; set; } = [];

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //throw new NotImplementedException();
            var validationResults = new List<ValidationResult>();
            if (VanAlcohol > TotAlcohol)
                validationResults.Add(new ValidationResult("VanAlcohol is groter dan TotAlcohol"));
            return validationResults;
        }
    }
}
