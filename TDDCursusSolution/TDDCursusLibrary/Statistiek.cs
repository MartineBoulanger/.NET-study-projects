namespace TDDCursusLibrary
{
    public static class Statistiek
    {
        public static decimal Gemiddelde(decimal[] getallen)
        {
            //throw new NotImplementedException();
            if (getallen == null) throw new ArgumentNullException();
            if (getallen.Length == 0) throw new ArgumentException();

            //var totaal = decimal.Zero;
            //foreach (var getal in getallen) totaal += getal;
            //return totaal / getallen.Length;

            // refactored naar LINQ
            return getallen.Average();
        }
    }
}
