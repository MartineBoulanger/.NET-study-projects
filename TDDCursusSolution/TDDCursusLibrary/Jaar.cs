namespace TDDCursusLibrary
{
  public class Jaar
  {
    private readonly int jaar;
    public Jaar(int jaar) => this.jaar = jaar; // constructor
    public bool IsSchrikkeljaar { get => jaar % 4 == 0 && jaar % 100 != 0 || jaar % 400 == 0; }
  }
}
