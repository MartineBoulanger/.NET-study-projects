namespace BierenApplication.Models;

public partial class Soort
{
    public int Id { get; set; }

    public string Naam { get; set; } = null!;

    public virtual ICollection<Bier> Bieren { get; set; } = new List<Bier>();
}
