namespace CSharpPFOefeningen
{
  public class Plant
  {
    public required int PlantId { get; set; }
    public string Plantennaam { get; set; } = null!;
    public string Kleur { get; set; } = null!;
    public decimal Prijs { get; set; }
    public string Soort { get; set; } = null!;
  }
}
