namespace CSharpPFOefeningen
{
    public class Voertuig
    {
        public Voertuig(string polishouder, decimal kostprijs, int pk, float gemiddeldVerbruik, string nummerplaat)
        {
            Polishouder = polishouder;
            Kostprijs = kostprijs;
            Pk = pk;
            GemiddeldVerbruik = gemiddeldVerbruik;
            Nummerplaat = nummerplaat;
        }

        public string Polishouder { get; set; }

        public decimal? Kostprijs { get; set { field = value > 0m ? value : 0; } }

        public int? Pk { get; set { field = value > 0 ? value : 0; } }

        public float? GemiddeldVerbruik { get; set { field = value > 0f ? value : 0; } }

        public string Nummerplaat { get; set; }

        public string GetInfo()
        {
            return $"polishouder: {Polishouder}\nnummerplaat: {Nummerplaat}\naantal pk: {Pk}pk\ngemiddeld verbruik: {GemiddeldVerbruik}/100km\nkostprijs van: {Kostprijs} euro";
        }
    }
}