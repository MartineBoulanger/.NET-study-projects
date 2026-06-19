using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchuttersData.Models;

public class Lid
{
    [Key]
    public long Lidnummer { get; set; }

    public string Naam { get; set; } = null!;

    public string Voornaam { get; set; } = null!;

    public string? Geslacht { get; set; }

    public string? Niveau { get; set; }

    [Column("Club")]
    public int ClubId { get; set; }

    [ForeignKey("ClubId")]
    public Club? Club { get; set; }
}
