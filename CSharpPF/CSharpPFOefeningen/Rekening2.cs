namespace CSharpPFOefeningen
{
    public class Rekening2(string rekeningnummer, decimal saldo, DateOnly creatieDatum)
    {
        private static readonly DateOnly EersteCreatie = new(1900, 1, 1);

        public string Rekeningnummer { get; set; } = IsRekeningNummerGeldig(rekeningnummer) ? rekeningnummer : "ongeldig rekeningnummer";

        public decimal Saldo { get; set; } = saldo > 0m ? saldo : 0;

        public DateOnly CreatieDatum { get; set; } = creatieDatum >= EersteCreatie ? creatieDatum : EersteCreatie;

        private static bool IsRekeningNummerGeldig(string nummer)
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

        public string GetInfo() { return $"Rekening: {Rekeningnummer}\nheeft een saldo van: {Saldo:0.00}\nop datum: {CreatieDatum.ToShortDateString()}"; }
        public decimal Storten(decimal bedrag) { return Saldo += bedrag; }
    }
}
