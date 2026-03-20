namespace Firma.Materiaal
{
  public class Fotokopiemachine:IKost
  {
    // Error classes voor de specifieke properties
    // dit is nog beter dan een error gooien met throw
    public class KostPerBlzException:Exception
    {
      public decimal VerkeerdeKost {  get; set; }
      public KostPerBlzException(string message, decimal verkeerdeKost) : base(message)
      {
        VerkeerdeKost = verkeerdeKost;
      }
    }

    public class AantalGekopieerdeBlzException : Exception
    {
      public int VerkeerdAantalBlz { get; set; }
      public AantalGekopieerdeBlzException(string message, int verkeerdAantalBlz) : base(message)
      {
        VerkeerdAantalBlz = verkeerdAantalBlz;
      }
    }

    // properties van de class
    public string SerieNr { get; set; }
    public int AantalGekopieerdeBlz { get; set {
      //if (value >= 0) field = value;
      // gooi een error als de value negatief is
      //if (value < 0) throw new Exception("Aantal gekopieerde blz. is onder 0!");
      if (value < 0) throw new AantalGekopieerdeBlzException("Aantal gekopieerde blz. is onder 0!", value);
        field = value;
    } }
    public decimal KostPerBlz { get; set {
      // if (value > 0) field = value;
      // gooi een error als de value negatief is
      //if (value < 0) throw new Exception("Kost per blz. is onder 0!");
      if (value < 0) throw new KostPerBlzException("Kost per blz. is onder 0!", value);
        field = value;
    } }
    // constructor met parameters
    public Fotokopiemachine(string serieNr, int aantalGekopieerdeBlz, decimal kostPerBlz)
    {
      SerieNr = serieNr;
      AantalGekopieerdeBlz = aantalGekopieerdeBlz;
      KostPerBlz = kostPerBlz;
    }
    // properties en methods van de interface
    public bool Menselijk => false;
    public decimal BerekenKostprijs() => AantalGekopieerdeBlz * KostPerBlz;
    // methods van de class
  }
}