namespace CSharpPFOefeningen
{
    internal class Vrachtwagen : Voertuig
    {
        // default waarde voor maxLading parameter
        public Vrachtwagen(float maxLading = 10000f) : base()
        {
            MaxLading = maxLading;
        }

        public Vrachtwagen(string polishouder, decimal kostprijs, int pk, float gemiddeldVerbruik, string nummerplaat, float maxLading) : base(polishouder, kostprijs, pk, gemiddeldVerbruik, nummerplaat)
        {
            MaxLading = maxLading;
        }

        private float maxLading;
        public float MaxLading
        {
            get => maxLading;
            set { if (value >= 0f) maxLading = value; }
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()}\nmaximum lading: {MaxLading} kg";
        }
    }
}
