namespace CSharpPFOefeningen
{
  public class Spaarrekening : Rekening
  {
    public Spaarrekening(string rekeningnummer, decimal saldo, DateOnly creatieDatum, Klant eigenaar) : base(rekeningnummer, saldo, creatieDatum, eigenaar)
    {
      //Intrest = intrest; // verwijderd omdat Intrest property nu static is
    }

    //private static decimal intrest;

    public static decimal Intrest
    {
      get;
      //set { if (value >= 0) intrest = value; }
      set => field = value < 0 ? throw new CustomExceptions.NegatieveWaardeException("De intrest moet positief zijn!", value) : value;
    }

    public override string GetInfo()
    {
      return $"{base.GetInfo()}\nIntrest: {Intrest}";
    }
  }
}
