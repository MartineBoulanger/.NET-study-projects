namespace TDDCursusLibrary
{
    public class Persoon
    {
        private readonly List<string> voornamen;

        //public Persoon(List<string> voornamen) => throw new NotImplementedException();
        public Persoon(List<string> voornamen)
        {
            if (voornamen == null)
                throw new ArgumentNullException("Een persoon moet minstens één voornaam hebben.");
            if (voornamen.Count == 0) throw new ArgumentException("Een persoon moet minstens één voornaam hebben.");
            if (voornamen.Count != voornamen.Distinct(StringComparer.OrdinalIgnoreCase).Count())
                throw new ArgumentException("Een persoon kan geen twee dezelfde voornamen hebben.");
            foreach (var naam in voornamen)
            {
                if (naam == string.Empty) throw new ArgumentException("Naam mag geen lege string zijn.");
                if (naam == " ") throw new ArgumentException("Naam mag geen spatie(s) zijn.");
                if (naam == "\t") throw new ArgumentException("Naam mag geen tab zijn.");
                if (naam == "\n") throw new ArgumentException("Naam mag geen newline zijn.");
            }
            this.voornamen = voornamen;
        }


        //public override string ToString() => throw new NotImplementedException();
        public override string ToString() => string.Join(" ", voornamen);
    }
}