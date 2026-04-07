using FLYNET.Personeel;
using FLYNET.Vloot;
using System.Text;

namespace FLYNET
{
    public class Vlucht
    {
        public required int VluchtID { get; init; }
        public required string Bestemming { get; set => field = value != string.Empty ? value : throw new Exception("De bestemming moet ingevuld worden."); }
        public required int DuurtijdInDagen { get; set => field = value < 0 ? throw new Exception("Duurtijd in dagen kan niet onder 0 zijn.") : value; }
        public required Vliegmaatschappij Vliegmaatschappij { get; set; }
        public required Vliegtuig Toestel { get; set; }
        public required List<Personeelslid> Personeel { get; set; }

        private decimal totaleVluchtPrijs, totaleToestelPrijs,totaleCockpitPersoneelsPrijs, totaleCabinePersoneelsPrijs, totalePersoneelsKost = 0m;
        public decimal BerekenVluchtKost ()
        {
            decimal totaleVluchtPrijs = 0m;
            totaleVluchtPrijs += Toestel.BerekenTotaleKostprijsPerDag() * DuurtijdInDagen;
            foreach (var personeelslid in Personeel)
            {
                if (personeelslid is CockpitPersoneelslid)
                {
                    totaleVluchtPrijs += personeelslid.BerekenTotaleKostprijsPerDag() * DuurtijdInDagen;
                }
                else if (personeelslid is CabinePersoneelslid)
                {
                    totaleVluchtPrijs += personeelslid.BerekenTotaleKostprijsPerDag() * DuurtijdInDagen;
                }
            }
            return totaleVluchtPrijs;
        }
    }
}
