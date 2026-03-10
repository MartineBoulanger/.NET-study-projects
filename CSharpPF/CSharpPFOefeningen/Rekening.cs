namespace CSharpPFOefeningen
{
    public class Rekening
    {
        private readonly DateOnly EersteCreatie = new(1900, 1, 1);
        
        public Rekening(string rekeningnummer, decimal saldo, DateOnly creatieDatum)
        {
            Rekeningnummer = rekeningnummer;
            Saldo = saldo;
            CreatieDatum = creatieDatum;
        }

        public string Rekeningnummer { get; set; }

        public decimal Saldo { get; set; }

        public DateOnly CreatieDatum { get; set { field = value > EersteCreatie ? value : EersteCreatie; } }

        public string GetInfo()
        {
            return $"Rekening: {Rekeningnummer} heeft een saldo van: {Saldo:0.00} op: {CreatieDatum}";
        }
    }
}