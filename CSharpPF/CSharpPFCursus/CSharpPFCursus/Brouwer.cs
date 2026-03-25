namespace CSharpPFCursus
{
  public class Brouwer
  {
    public required int BrouwerNr { get; init; }
    public string Brouwernaam { get; set; } = null!;
    public bool Belgisch { get; set; }
    public List<Bier> Bieren { get; set; } = null!;
    public override string ToString() => $"Brouwerij {Brouwernaam} ({(Belgisch ? "Belgisch" : "Niet Belgisch")})";
  }
}
