namespace TDDCursusLibrary
{
    public class Veiling
    {
        private decimal hoogsteBod = 0m;
        //public decimal HoogsteBod { get => throw new NotImplementedException(); }
        public decimal HoogsteBod => hoogsteBod;

        public void DoeBod(decimal bedrag)
        {
            //throw new NotImplementedException();
            if (bedrag > hoogsteBod) hoogsteBod = bedrag;
        }
    }
}
