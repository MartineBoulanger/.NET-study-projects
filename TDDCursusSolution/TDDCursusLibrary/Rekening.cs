namespace TDDCursusLibrary
{
    public class Rekening
    {
        private decimal saldo;
        public void Storten(decimal bedrag)
        {
            if (bedrag <= decimal.Zero) throw new ArgumentException("Het bedrag moet positief zijn!");
            saldo += bedrag;
        }
        public decimal Saldo => saldo;
    }
}
