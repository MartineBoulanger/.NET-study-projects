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
        //public decimal Saldo => saldo; // read-only property
        public decimal Saldo { get => saldo; set {
                if (value < 0m) throw new ArgumentException("Het bedrag moet positief zijn");
                saldo = value;
            }
        } // read-write property with validation

        // de Initialize method in de testclass zorgt ervoor dat je altijd een nieuwe rekening hebt voordat je een test uitvoert, dus je hoeft geen constructor te maken die het saldo op nul zet
        public Rekening() { }
        public Rekening(decimal saldo)
        {
            Saldo = saldo;
        }
    }
}
