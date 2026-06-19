using System.ComponentModel.DataAnnotations;

namespace SchuttersData.Models;

public class Club
{
    [Key]
    public int Stamnummer { get; set; }

    public string Naam { get; set; } = null!;

    public string Postcode { get; set; } = null!;

    public string Gemeente { get; set; } = null!;

    public string? Adres { get; set; }

    public IEnumerable<Lid>? Leden { get; set; }
}
