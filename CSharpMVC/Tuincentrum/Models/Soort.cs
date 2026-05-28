using System.ComponentModel.DataAnnotations;

namespace Tuincentrum.Models;

public partial class Soort
{
    public int SoortNr { get; set; }

    [StringLength(7)]
    public string Naam { get; set; } = null!;

    public byte MagazijnNr { get; set; }

    public virtual ICollection<Plant> Planten { get; set; } = new List<Plant>();
}
