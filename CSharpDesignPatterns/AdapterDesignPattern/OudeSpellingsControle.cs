namespace AdapterDesignPattern
{
    public class OudeSpellingsControle
    {
        public string Taal { get; set; } = null!;
        public string Tekst { get; set; } = null!;
        public string[] Fouten { get; set; } = null!;
        public void ControleerSpelling()
        {
            Fouten = ["onmidelijk", "paralelogram"];
        }
        public int AantalFouten() => Fouten.Length;
        public string Fout(int index) => Fouten[index];
    }
}
