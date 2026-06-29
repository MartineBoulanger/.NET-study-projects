namespace FacadeDesignPattern
{
    public class Rekening
    {
        private decimal saldo;

        public decimal Saldo
        {
            get { return saldo; }
            private set { saldo = value; }
        }
        public Rekening()
        {
            Saldo = decimal.Zero;
        }
        public void Storten(decimal bedrag)
        {
            Saldo += bedrag;
        }
    }
}
