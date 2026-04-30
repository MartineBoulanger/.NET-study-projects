using System.ComponentModel.DataAnnotations;

namespace Eindoefening.Models
{
    public class KlantViewModel
    {
        [Display(Name = "Naam")]
        [Required(ErrorMessage = "Achternaam is verplicht")]
        public string Achternaam { get; set; }

        [Display(Name = "Voornaam")]
        [Required(ErrorMessage = "Voornaam is verplicht")]
        public string Voornaam { get; set; }

        [Display(Name = "Adres (straat + huisnummer)")]
        [Required(ErrorMessage = "Adres is verplicht")]
        public string Adres { get; set; }

        [Display(Name = "Postcode")]
        [Required(ErrorMessage = "Postcode is verplicht")]
        public string Postcode { get; set; }

        [Display(Name = "Gemeente")]
        [Required(ErrorMessage = "Gemeente is verplicht")]
        public string Gemeente { get; set; }

        [Display(Name = "Emailadres")]
        [Required(ErrorMessage = "Email is verplicht")]
        [EmailAddress]
        [RegularExpression(@"[\w-\.]+@([\w-]+\.)+[\w-]{2,4}", ErrorMessage = "Emailadres is verkeerd")]
        public string Email { get; set; }

        [Display(Name = "Telefoon")]
        [Required(ErrorMessage = "Telefoonnummer is verplicht")]
        [DataType(DataType.PhoneNumber)]
        public string Telefoon { get; set; }
    }
}
