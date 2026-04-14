namespace TDDCursusLibrary
{
    public class Persoon
    {
        private readonly List<string> voornamen;

        //public Persoon(List<string> voornamen) => throw new NotImplementedException();
        public Persoon(List<string> voornamen)
        {
            if (voornamen == null || voornamen.Count == 0)
                throw new ArgumentNullException("Een persoon moet minstens één voornaam hebben.");
            if (voornamen.Count != voornamen.Distinct().Count())
                throw new ArgumentException("Een persoon kan geen twee keer dezelfde voornaam hebben.");
            foreach (var naam in voornamen)
            {
                if (string.IsNullOrWhiteSpace(naam)) throw new ArgumentException("Iedere voornaam moet minstens één teken bevatten.");
            }
            this.voornamen = new List<string>(voornamen); // een kopie maken om immutability te waarborgen
        }


        //public override string ToString() => throw new NotImplementedException();
        public override string ToString() => string.Join(" ", voornamen);
    }
}
