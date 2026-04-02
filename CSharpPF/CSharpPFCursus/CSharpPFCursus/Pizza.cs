namespace CSharpPFCursus
{
    public class Pizza
    {
        public required string Naam { get; set; }
        public List<string>? Onderdelen { get; set; }
        public required decimal Prijs { get; set; }

        public override string ToString() => $"{Naam}: {Prijs} EUR";
    }
}
