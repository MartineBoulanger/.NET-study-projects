namespace CSharpPFOefeningen
{
    public class Voertuig2(string polishouder, decimal kostprijs, int pk, float gemiddeldVerbruik, string nummerplaat)
    {
        // constructor met optionele parameters
        public Voertuig2(): this("onbepaald", 0m, 0, 0f, "onbepaald") { }

        public string Polishouder { get; set; } = !string.IsNullOrWhiteSpace(polishouder) ? polishouder : "onbepaald";

        public decimal Kostprijs { get; set; } = kostprijs > 0m ? kostprijs : 0m;

        public int Pk { get; set; } = pk > 0 ? pk : 0;

        public float GemiddeldVerbruik { get; set; } = gemiddeldVerbruik > 0f ? gemiddeldVerbruik : 0f;

        public string Nummerplaat { get; set; } = !string.IsNullOrWhiteSpace(nummerplaat) ? nummerplaat : "onbepaald";

        public string GetInfo() { return $"polishouder: {Polishouder}\nnummerplaat: {Nummerplaat}\naantal pk: {Pk}pk\ngemiddeld verbruik: {GemiddeldVerbruik}/100km\nkostprijs van: {Kostprijs} euro\n";  }
    }
}
