using System.Text;

namespace BuilderDesignPattern
{
    public class Inwoner
    {
        public string Voornaam { get; set; } = null!;
        public string Familienaam { get; set; } = null!;
        public int AantalKinderen { get; set; }
        public int AantalKeerVerhuisd { get; set; }
        public bool Gehuwd { get; set; }
        public bool Gescheiden { get; set; }

        private Inwoner(string voornaam, string familienaam, int aantalKinderen, int aantalKeerVerhuisd, bool gehuwd, bool gescheiden)
        {
            Voornaam = voornaam;
            Familienaam = familienaam;
            AantalKinderen = aantalKinderen;
            AantalKeerVerhuisd = aantalKeerVerhuisd;
            Gehuwd = gehuwd;
            Gescheiden = gescheiden;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Voornaam: {Voornaam} ");
            sb.AppendLine($"Familienaam: {Familienaam} ");
            sb.AppendLine($"Aantal kinderen: {AantalKinderen} ");
            sb.AppendLine($"Aantal keer verhuisd: {AantalKeerVerhuisd} ");
            sb.AppendLine($"Gehuwd: {Gehuwd} ");
            sb.AppendLine($"Gescheiden: {Gescheiden} ");
            return sb.ToString();
        }

        // builder design pattern
        public class InwonerBuilder
        {
            private string voornaam = null!, familienaam = null!;
            private int aantalKinderen, aantalKeerVerhuisd;
            private bool gehuwd, gescheiden;

            public InwonerBuilder MetVoornaam(string voornaam)
            {
                this.voornaam = voornaam;
                return this;
            }
            public InwonerBuilder MetFamilienaam(string familienaam)
            {
                this.familienaam = familienaam;
                return this;
            }
            public InwonerBuilder MetAantalKinderen(int aantalKinderen)
            {
                this.aantalKinderen = aantalKinderen;
                return this;
            }

            public InwonerBuilder MetAantalKeerVerhuisd(int aantalKeerVerhuisd)
            {
                this.aantalKeerVerhuisd = aantalKeerVerhuisd;
                return this;
            }

            public InwonerBuilder MetGehuwd(bool gehuwd)
            {
                this.gehuwd = gehuwd;
                return this;
            }
            public InwonerBuilder MetGescheiden(bool gescheiden)
            {
                this.gescheiden = gescheiden;
                return this;
            }
            public Inwoner MaakInwoner()
            {
                return new Inwoner(voornaam, familienaam, aantalKinderen,
                aantalKeerVerhuisd, gehuwd, gescheiden);
            }
        }
    }
}
