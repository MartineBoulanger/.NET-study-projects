using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchuttersData.Models;

public class Lid
{
    [Key]
    [Required(ErrorMessage = "Lidnummer is verplicht")]
    [Display(Name = "Lidnr")]
    public long Lidnummer { get; set; }

    [Required(ErrorMessage = "Naam is verplicht")]
    [StringLength(50, ErrorMessage = "Naam mag maximaal 50 karakters lang zijn")]
    public string Naam { get; set; } = null!;

    [Required(ErrorMessage = "Voornaam is verplicht")]
    [StringLength(50, ErrorMessage = "Voornaam mag maximaal 50 karakters lang zijn")]
    public string Voornaam { get; set; } = null!;

    [StringLength(1, ErrorMessage = "Geslacht mag maximaal 1 karakter zijn")]
    public Geslacht? Geslacht { get; set; }

    [StringLength(1, ErrorMessage = "Niveau mag maximaal 1 karakter zijn")]
    public Niveau? Niveau { get; set; }

    [Required(ErrorMessage = "Club is verplicht")]
    [Column("Club")]
    [Display(Name = "Club")]
    public int ClubId { get; set; }

    [ForeignKey("ClubId")]
    public Club? Club { get; set; }
}
