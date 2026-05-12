namespace Model.Entities
{
    public class Adres // deze class is een owned type van Docent en Campus, dus geen eigen tabel in de database
    {
        public Adres() { } // nodig voor EF Core om te functioneren
        public Adres(string straat, string huisnummer, string postcode, string gemeente)
        {
            Straat = straat;
            Huisnummer = huisnummer;
            Postcode = postcode;
            Gemeente = gemeente;
        }
        public string? Straat { get; set; }
        public string? Huisnummer { get; set; }
        public string? Postcode { get; set; }
        public string? Gemeente { get; set; }
        public string? AdresLijn => $"{Straat} {Huisnummer}\n{Postcode} {Gemeente}";
    }
}
