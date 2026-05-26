namespace Model;

public partial class Bier
{
    public int BierNr { get; set; }

    public string Naam { get; set; } = null!;

    public int BrouwerNr { get; set; }

    public int SoortNr { get; set; }

    public float? Alcohol { get; set; }

    public virtual Brouwer BrouwerNrNavigation { get; set; } = null!;

    public virtual Soort SoortNrNavigation { get; set; } = null!;
}
