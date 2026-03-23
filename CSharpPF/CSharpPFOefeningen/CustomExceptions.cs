namespace CSharpPFOefeningen
{
  public class CustomExceptions
  {
    public class RekeningnummerException : Exception
    {
      public string VerkeerdRekeningnummer { get; set; }
      public RekeningnummerException(string message, string verkeerdRekeningnummer) : base(message)
      {
        VerkeerdRekeningnummer = verkeerdRekeningnummer;
      }
    }

    public class FouteCreatieDatumException : Exception
    {
      public DateOnly FoutiefCreatieDatum { get; set; }
      public FouteCreatieDatumException(string message, DateOnly foutiefCreatieDatum) : base(message)
      {
        FoutiefCreatieDatum = foutiefCreatieDatum;
      }
    }

    public class NegatieveWaardeException : Exception
    {
      public decimal GeenNegatieveWaarde { get; set; }
      public NegatieveWaardeException(string message, decimal geenNegatieveWaarde) : base(message)
      {
        GeenNegatieveWaarde = geenNegatieveWaarde;
      }
    }

    public class PositieveWaardeException : Exception
    {
      public decimal GeenPositieveWaarde { get; set; }
      public PositieveWaardeException(string message, decimal geenPositieveWaarde) : base(message)
      {
        GeenPositieveWaarde = geenPositieveWaarde;
      }
    }
  }
}
