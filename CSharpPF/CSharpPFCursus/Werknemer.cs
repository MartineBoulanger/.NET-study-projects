namespace CSharpPFCursus
{
    public class Werknemer
    {
        // een constructor zonder parameters die zelf standaard default waardes meegeeft aan de properties.
        //public Werknemer(): this("Onbekend", DateTime.Today, Geslacht.Man) { }
        // een constructor met parameters waarbij de developer via het programma waardes kan meegeven aan de parameters.
        public Werknemer(string naam, DateTime inDienst, Geslacht geslacht = Geslacht.X)
        {
           this.Naam = naam;
           this.InDienst = inDienst;
           this.Geslacht = geslacht;
        }

        private string naam;
        public string Naam
        {
            get => naam;
            // set { if (value != string.Empty) naam = value; }
            // init { if (value != string.Empty) naam = value; }
            init => naam = !string.IsNullOrWhiteSpace(value) ? value : "onbekende naam";
        }

        public DateTime InDienst { get; set; }
        
        //private Geslacht geslacht;
        public Geslacht Geslacht
        {
            get;
            set;
        }

        private decimal salaris;
        public decimal Salaris
        {
            get
            {
                return salaris;
            }
            private set
            {
                if (value >= 0m) salaris = value;
            }
        }

        public bool VerjaarAncien
        {
            get
            {
                return InDienst.Month == DateTime.Today.Month && InDienst.Day == DateTime.Today.Day;
            }
        }

        public string GetInfo()
        {
            return $"Naam: {Naam}\nGeslacht: {Geslacht}\nIn dienst: {InDienst}";
        }
    }
}
