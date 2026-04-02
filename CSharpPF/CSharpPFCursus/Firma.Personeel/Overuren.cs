namespace Firma.Personeel
{
    public class Overuren
    {
        private int[] overuren = new int[12];
        private static readonly string[] maanden = ["jan", "feb", "maa", "apr", "mei", "jun", "jul", "aug", "sep", "okt", "nov", "dec"];
        public int this[int maand] { get => overuren[maand]; set => overuren[maand] = value; }
        public int this[string maand] { get => overuren[WelkeMaand(maand)]; set => overuren[WelkeMaand(maand)] = value; }
        private int WelkeMaand(string maand)
        {
            int maandNr = Array.IndexOf(maanden, maand);
            if (maandNr == -1) throw new IndexOutOfRangeException("Ongeldige maand: "+maand);
            return maandNr;
        }
        public int Totaal => overuren.Sum();
    }
}
