namespace AdapterDesignPattern
{
    public class NieuweSpellingsControle(string taal, string tekst)
    {
        public string Taal { get; set; }
        public string Tekst { get; set; }
        public string[] Controleer() => ["onmidelijk", "paralelogram"];
    }
}
