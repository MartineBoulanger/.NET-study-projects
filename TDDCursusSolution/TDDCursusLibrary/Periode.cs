namespace TDDCursusLibrary
{
    public class Periode
    {
        public DateTime VanDatum { get; set; }
        public DateTime TotDatum { get; set; }
        public int AantalDagen { get; set; }
        public Periode(DateTime van, DateTime tot)
        {
            if (tot <= van) throw new ArgumentException();
            if ((tot - van).Days < 1) throw new ArgumentException();
            VanDatum = van;
            TotDatum = tot;
            AantalDagen = (tot - van).Days;
        }
    }
}
