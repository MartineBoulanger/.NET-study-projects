using System.ComponentModel.DataAnnotations;

namespace SchuttersData.Models;

public class Club
{
    [Key]
    [Required(ErrorMessage = "Stamnummer is verplicht")]
    public int Stamnummer { get; set; }

    [Required(ErrorMessage = "Clubnaam is verplicht")]
    [StringLength(50, ErrorMessage = "Clubnaam mag maximaal 50 karakters lang zijn")]
    [Display(Name = "Clubnaam")]
    public string Naam { get; set; } = null!;

    [Required(ErrorMessage = "Postcode is verplicht")]
    [StringLength(4, ErrorMessage = "Postcode moet 4 karakters bevatten")]
    public string Postcode { get; set; } = null!;

    [Required(ErrorMessage = "Gemeente is verplicht")]
    [StringLength(50, ErrorMessage = "Gemeente mag maximaal 50 karakters lang sijn")]
    public string Gemeente { get; set; } = null!;

    [StringLength(50, ErrorMessage = "Adres mag maximaal 50 karakters lang zijn")]
    public string? Adres { get; set; }

    public IEnumerable<Lid>? Leden { get; set; }
}
