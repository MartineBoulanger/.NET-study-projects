namespace CSharpPFOefeningen
{
    public class Rekening
    {
        private readonly DateOnly EersteCreatie = new(1900, 1, 1);
        
        // constructor
        public Rekening(string rekeningnummer, decimal saldo, DateOnly creatieDatum)
        {
            Rekeningnummer = rekeningnummer;
            Saldo = saldo;
            CreatieDatum = creatieDatum;
        }

        private string rekeningnummer;
        public string Rekeningnummer
        {
            get => rekeningnummer; 
            init
            {
                if (IsRekeningNummerGeldig(value))
                {
                    rekeningnummer = value;
                }
            }
        }
        public decimal Saldo { get; set; }

        public DateOnly CreatieDatum { get => field; set { field = value >= EersteCreatie ? value : EersteCreatie; } }

        private bool IsRekeningNummerGeldig(string nummer)
        {
            if (string.IsNullOrWhiteSpace(nummer)) return false;
            if (nummer.Length != 16) return false;
            if (nummer[..2] != "BE") return false;
            if (!int.TryParse(nummer.Substring(2, 2), out int derdeEnVierdeTeken)) return false;
            if (!ulong.TryParse(nummer.Substring(4), out ulong belgischNummer)) return false;
            ulong eerste10 = belgischNummer / 100ul;
            int laatste2 = (int)(belgischNummer % 100ul);
            return (int)(eerste10 % 97ul) == laatste2;
        }

        public virtual string GetInfo()
        {
            return $"Rekeningnummer: {Rekeningnummer}\nSaldo: {Saldo:0.00}\nCreatie datum: {CreatieDatum}";
        }
        
        public decimal Storten(decimal bedrag)
        {
            return Saldo += bedrag;
        }
    }
}