namespace CSharpPFOefeningen
{
    public abstract class Voertuig
    {
        public abstract double GetKyotoScore();

        // constructor
        public Voertuig(string polishouder = "onbepaald", decimal kostprijs = 0m, int pk = 0, float gemiddeldVerbruik = 0f, string nummerplaat = "onbepaald")
        {
            this.Polishouder = polishouder;
            this.Kostprijs = kostprijs;
            this.Pk = pk;
            this.GemiddeldVerbruik = gemiddeldVerbruik;
            this.Nummerplaat = nummerplaat;
        }

        //public required string Polishouder { get; init; }
        public string Polishouder { get; init; }

        public decimal Kostprijs { get; set { field = value > 0m ? value : 0; } }

        public int Pk { get; set { field = value > 0 ? value : 0; } }

        public float GemiddeldVerbruik { get; set { field = value > 0f ? value : 0; } }

        public string Nummerplaat { get; set; }

        public virtual string GetInfo()
        {
            return $"polishouder: {Polishouder}\nnummerplaat: {Nummerplaat}\naantal pk: {Pk}pk\ngemiddeld verbruik: {GemiddeldVerbruik}/100km\nkostprijs van: {Kostprijs} euro";
        }
    }
}