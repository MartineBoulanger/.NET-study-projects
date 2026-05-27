using BierenApplication.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BierenApplication.Models;

public partial class Bier
{
    [DisplayFormat(DataFormatString = "{0:D3}")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Bier naam is verpicht")]
    [StringLength(100, ErrorMessage = "Max. {1} tekens voor {0}")]
    public string Naam { get; set; } = null!;

    public int BrouwerId { get; set; }

    public int SoortId { get; set; }

    [UIHint("percentage")]
    [AlcoholGrenzen(ErrorMessage = "{0} heeft een ongeldige waarde")]
    public float? Alcohol { get; set; }

    [DisplayFormat(DataFormatString = "€{0:#,##0.00}")]
    public decimal? Prijs { get; set; }

    public virtual Brouwer Brouwer { get; set; } = null!;

    public virtual Soort Soort { get; set; } = null!;
}
