using System.Text;

namespace StrategyDesignPattern
{
    public delegate string Aanspreking(Persoon persoon);
    public class Persoon(string voornaam, string familienaam, string titel)
    {
        public string Voornaam { get; set; } = voornaam;
        public string Familienaam { get; set; } = familienaam;
        public string Titel { get; set; } = titel;

        public string MaakBriefHoofding(Aanspreking aanspreking)
        {
            StringBuilder sb = new();
            sb.Append("Brussel,");
            DateTime vandaag = DateTime.Now;
            sb.Append(vandaag.ToString("d/M/yyyy"));
            sb.Append("\n");
            sb.Append(aanspreking(this));
            sb.Append("\n");
            return sb.ToString();
        }
    }
}
