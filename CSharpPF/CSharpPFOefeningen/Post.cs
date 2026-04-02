using System.Text;

namespace CSharpPFOefeningen
{
    public class Post
    {
        public required string Naam { get; set; } = string.Empty;
        private string bericht = string.Empty;
        public required string Bericht
        {
            get => bericht;
            set => bericht = value.Length <= 280 ? value : value[..280];
        }
        public DateTime Tijdstip { get; init; } = DateTime.Now;
        public override string ToString()
        {
            //naam + bericht + tijdstip
            StringBuilder xBericht = new StringBuilder($" {Naam} : {Bericht} : ");
            TimeSpan verschil = DateTime.Now - Tijdstip;
            if (verschil.Days > 0)
                xBericht.Append(Tijdstip.ToShortDateString());
            else if (verschil.Hours > 0)
                xBericht.Append($" {verschil.Hours} uur geleden");
            else if (verschil.Minutes > 0)
                xBericht.Append($" {verschil.Minutes} " +
                $" {(verschil.Minutes == 1 ? " minuut" : " minuten")} geleden");
            else
                xBericht.Append(Tijdstip.ToShortTimeString());

            return xBericht.ToString();
        }
    }
}
