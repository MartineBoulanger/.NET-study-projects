using System.ComponentModel.DataAnnotations;

namespace Tuincentrum.Models;

public partial class Plant
{
    public int PlantNr { get; set; }

    [StringLength(30)]
    public string Naam { get; set; } = null!;

    [Display(Name = "Soort")]
    public int SoortNr { get; set; }

    [Display(Name = "Leverancier")]
    public int Levnr { get; set; }

    [StringLength(10)]
    public string Kleur { get; set; } = null!;

    [Display(Name = "Prijs")]
    [DisplayFormat(DataFormatString = "{0:€ #,##0.00}")]
    [Range(0, 1000)]
    public decimal VerkoopPrijs { get; set; }

    [Display(Name = "Leverancier")]
    public virtual Leverancier? LevnrNavigation { get; set; } = null!;

    [Display(Name = "Soort")]
    public virtual Soort? SoortNrNavigation { get; set; } = null!;
}
