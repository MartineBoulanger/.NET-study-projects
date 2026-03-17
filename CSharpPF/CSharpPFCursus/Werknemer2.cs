namespace CSharpPFCursus
{
    internal class Werknemer2(string naam, DateTime inDienst, Geslacht geslacht)
    {
        public Werknemer2(): this("Onbekend", DateTime.Today, Geslacht.X) { }

        public string Naam { get; set; } = !string.IsNullOrWhiteSpace(naam) ? naam : "Onbekend";
        public DateTime InDienst { get; set; } = inDienst;
        public Geslacht Geslacht { get; set; } = geslacht;
        private bool verjaarAncien;

        public bool VerjaarAncien
        {
            get { return InDienst.Month == DateTime.Today.Month && InDienst.Day == DateTime.Today.Day; }
        }

        public string GetInfo()
        {
            return $"Naam: {Naam}\nGeslacht: {Geslacht}\nIn dienst: {InDienst}";
        }
    }
}
