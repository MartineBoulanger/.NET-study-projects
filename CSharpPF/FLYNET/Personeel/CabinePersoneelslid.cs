namespace FLYNET.Personeel
{
    public class CabinePersoneelslid:VliegendPersoneelslid
    {
        private static readonly List<Enums.Graad> graden = [Enums.Graad.Purser, Enums.Graad.Steward];
        public string? Werkpositie { get; set; } = string.Empty;
        // overschrijven van de Graad property van de VliegendPersoneelslid class
        public override required Enums.Graad Graad { get; set => field = graden.Contains(value) ? value : throw new GraadException($"Verkeerde graad {value}, deze behoort niet tot de mogelijke graden van de cabinecrew ({string.Join("-", graden)}).", value); }
        public override decimal BerekenTotaleKostprijsPerDag()
        {
            decimal totaalPerDag = BasisKostprijsPerDag;
            if (Graad == Enums.Graad.Purser) totaalPerDag *= 1.2m;
            foreach (var cert in Certificaten) if (cert.CertificaatAfkorting == "EHBO") totaalPerDag += 5m;
            return totaalPerDag;
        }
        public override string ToString()
        {
            return base.ToString() + $"Werkpositie: {Werkpositie ?? "deur1"}\n" + $"Totale kostprijs per dag: {BerekenTotaleKostprijsPerDag():F2} euro";
        }
    }
}
