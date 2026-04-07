namespace FLYNET.Personeel
{
    public class Certificaat
    {
        public required string CertificaatAfkorting { get; set; }
        public required string CertificaatOmschrijving { get; set; }
        public override string ToString() => $"{CertificaatOmschrijving} ({CertificaatAfkorting})";
    }
}
