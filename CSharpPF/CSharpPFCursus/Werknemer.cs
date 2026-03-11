namespace CSharpPFCursus
{
    public class Werknemer
    {
        private string naam;
        public string Naam
        {
            get => naam;
            set { if (value != string.Empty) naam = value; }
        }

        public DateTime InDienst { get; set; }
        
        private Geslacht geslacht;
        public Geslacht Geslacht
        {
            get => geslacht;
            set => geslacht = value;
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
