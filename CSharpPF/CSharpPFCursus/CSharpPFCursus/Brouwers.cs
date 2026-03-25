namespace CSharpPFCursus
{
  public class Brouwers
  {
    public static List<Brouwer> GetBrouwers()
    {
      Brouwer palm = new Brouwer { BrouwerNr = 1, Brouwernaam = "Palm", Belgisch = true };
      palm.Bieren = [
          new Bier { BierNr = 1, Biernaam = "Palm Dobbel", Alcohol = 6.2f, Brouwer = palm },
          new Bier { BierNr = 2, Biernaam = "Palm Green", Alcohol = 0.1f, Brouwer = palm },
          new Bier { BierNr = 3, Biernaam = "Palm Royale", Alcohol = 7.5f, Brouwer = palm },
        ];
      Brouwer hertogJan = new Brouwer { BrouwerNr = 2, Brouwernaam = "Hertog Jan", Belgisch = false };
      hertogJan.Bieren = [
          new Bier { BierNr = 4, Biernaam = "Hertog Jan Dubbel", Alcohol = 7.0f, Brouwer = hertogJan },
          new Bier { BierNr = 5, Biernaam = "Hertog Jan Grand Prestige", Alcohol = 10.0f, Brouwer = hertogJan },
        ];
      Brouwer inBev = new Brouwer { BrouwerNr = 3, Brouwernaam = "InBev", Belgisch = true };
      inBev.Bieren = [
          new Bier { BierNr = 6, Biernaam = "Belle-vue kriek L.A", Alcohol = 1.2f, Brouwer = inBev },
          new Bier { BierNr = 7, Biernaam = "Belle-vue kriek", Alcohol = 5.2f, Brouwer = inBev },
          new Bier { BierNr = 8, Biernaam = "Leffe Radieuse", Alcohol = 8.2f, Brouwer = inBev },
          new Bier { BierNr = 9, Biernaam = "Leffe Triple", Alcohol = 8.5f, Brouwer = inBev },
        ];
      // return new List<Brouwer> {palm,hertogJan,inBev};
      return [palm, hertogJan, inBev];
    }
  }
}
