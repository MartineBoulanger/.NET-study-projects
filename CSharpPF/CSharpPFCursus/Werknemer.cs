namespace CSharpPFCursus
{
    internal class Werknemer
    {
        private string naam;
        public string Naam
        {
            get { return naam; }
            set { if (value != string.Empty) naam = value; }
        }

        public DateTime InDienst { get; set; }
        public Geslacht Geslacht { get; set; }
    }
}
