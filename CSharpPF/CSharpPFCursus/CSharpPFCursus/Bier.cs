namespace CSharpPFCursus
{
  public class Bier
  {
    public required int BierNr { get; set; }
    public string Biernaam { get; set; } = null!;
    public float Alcohol { get; set; }
    public Brouwer Brouwer { get; set; } = null!;
    public override string ToString() => $"{Biernaam}: {Alcohol}% alcohol";
  }
}
