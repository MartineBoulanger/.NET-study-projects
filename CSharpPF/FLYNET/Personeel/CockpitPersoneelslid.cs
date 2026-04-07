namespace FLYNET.Personeel
{
    public class CockpitPersoneelslid:VliegendPersoneelslid
    {
        private static readonly List<Enums.Graad> graden = [Enums.Graad.Captain, Enums.Graad.SeniorFlightOfficer, Enums.Graad.SecondOfficer, Enums.Graad.JuniorFlightOfficer];

        public int Vlieguren { get; set => field = value < 0 ? throw new Exception("Vlieguren kunnen niet negatief zijn.") : value; }

        // overschrijven van de Graad property van de VliegendPersoneelslid class
        public override required Enums.Graad Graad { get; set => field = graden.Contains(value) ? value : throw new GraadException($"Verkeerde graad {value}, deze behoort niet tot de mogelijke graden van de cockpitcrew ({string.Join("-", graden)}).", value); }

        public override decimal BerekenTotaleKostprijsPerDag()
        {
            decimal totaalPerDag = BasisKostprijsPerDag;
            switch (Graad)
            {
                case Enums.Graad.Captain:
                    totaalPerDag *= 1.3m;
                    break;
                case Enums.Graad.SeniorFlightOfficer:
                    totaalPerDag *= 1.2m;
                    break;
                case Enums.Graad.SecondOfficer:
                    totaalPerDag *= 1.1m;
                    break;
                default:
                    totaalPerDag = BasisKostprijsPerDag;
                    break;
            }
            foreach (var cert in Certificaten) if (cert.CertificaatAfkorting == "CPL") totaalPerDag += 50m;
            return totaalPerDag;
        }

        public override string ToString()
        {
            return base.ToString() + $"Vlieguren: {Vlieguren}\n" + $"Totale kostprijs per dag: {BerekenTotaleKostprijsPerDag():F2} euro";
        }
    }
}
