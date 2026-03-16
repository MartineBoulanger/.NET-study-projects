namespace CSharpPFOefeningen
{
    internal class Personenwagen : Voertuig
    {
        // default waarde voor aantalDeuren en aantalPassagiers
        public Personenwagen(int aantalDeuren = 4, int aantalPassagiers = 5) : base()
        {
            AantalDeuren = aantalDeuren;
            AantalPassagiers = aantalPassagiers;
        }

        public Personenwagen(string polishouder, decimal kostprijs, int pk, float gemiddeldVerbruik, string nummerplaat, int aantalDeuren, int aantalPassagiers) : base(polishouder, kostprijs, pk, gemiddeldVerbruik, nummerplaat)
        {
            AantalDeuren = aantalDeuren;
            AantalPassagiers = aantalPassagiers;
        }

        private int aantalDeuren;

        public int AantalDeuren
        {
            get => aantalDeuren;
            set { if (value > 0) aantalDeuren = value; }
        }

        private int aantalPassagiers;

        public int AantalPassagiers
        {
            get => aantalPassagiers;
            set { if (value > 0) aantalPassagiers = value; }
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()}\naantal deuren: {AantalDeuren}\naantal passagiers: {AantalPassagiers}";
        }
    }
}
