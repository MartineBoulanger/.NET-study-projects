namespace CSharpPFOefeningen
{
    public class Bank
    {
        public required int BankId { get; init; }
        public required string Naam { get; set; }

        public void RekeningUittrekselTonen(Rekening rekening)
        {
            Console.WriteLine($"Datum: {DateTime.Today.ToShortDateString()}");
            Console.WriteLine($"Rekeninguittreksel van rekening {rekening.Rekeningnummer}");
            Console.WriteLine($"Nieuw saldo: {rekening.Saldo} euro");
        }

        public void RekeningInRoodMelding(Rekening rekening)
        {
            Console.WriteLine("Afhalen niet mogelijk, saldo ontoereikend!");
            Console.WriteLine($"Maximum af te halen bedrag: {rekening.Saldo} euro");
        }
    }
}
