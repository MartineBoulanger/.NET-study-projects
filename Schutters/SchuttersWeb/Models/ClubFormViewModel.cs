using System.ComponentModel.DataAnnotations;

namespace SchuttersWeb.Models
{
    public class ClubFormViewModel
    {
        [Required(ErrorMessage = "Stamnummer is verplicht")]
        [Display(Name = "Stamnr")]
        public int Stamnummer { get; set; }

        [Required(ErrorMessage = "Clubnaam is verplicht")]
        [StringLength(50, ErrorMessage = "Clubnaam mag maar maximaal 50 karakters lang zijn")]
        [Display(Name = "Clubnaam")]
        public string Naam { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postcode is verplicht")]
        [StringLength(4, ErrorMessage = "Postcode mag maar maximaal 4 karakters lang zijn")]
        public string Postcode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Gemeente is verplicht")]
        [StringLength(50, ErrorMessage = "Gemeente mag maar maximaal 50 karakters lang zijn")]
        public string Gemeente { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Adres mag maar maximaal 50 karakters lang zijn")]
        public string? Adres { get; set; }
    }
}
