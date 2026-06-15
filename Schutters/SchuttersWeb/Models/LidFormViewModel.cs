using Microsoft.AspNetCore.Mvc.Rendering;
using SchuttersData.Models;
using System.ComponentModel.DataAnnotations;

namespace SchuttersWeb.Models
{
    public class LidFormViewModel
    {
        [Display(Name = "Lidnr")]
        [Required(ErrorMessage = "Lidnummer is verplicht")]
        public long Lidnummer { get; set; }

        [Required(ErrorMessage = "Naam is verplicht")]
        [StringLength(50, ErrorMessage = "Naam mag maximaal 50 karakters lang zijn")]
        public string Naam { get; set; } = string.Empty;

        [Required(ErrorMessage = "Voornaam is verplicht")]
        [StringLength(50, ErrorMessage = "Voornaam mag maximaal 50 karakters lang zijn")]
        public string Voornaam { get; set; } = string.Empty;

        [StringLength(1)]
        public Geslacht? Geslacht { get; set; }

        [StringLength(1)]
        public Niveau? Niveau { get; set; }

        [Required(ErrorMessage = "Club is verplicht")]
        [Display(Name = "Club")]
        public int ClubId { get; set; }

        public IEnumerable<SelectListItem>? Clubs { get; set; }
        public IEnumerable<SelectListItem>? GeslachtOpties { get; set; }
        public IEnumerable<SelectListItem>? NiveauOpties { get; set; }
    }
}
