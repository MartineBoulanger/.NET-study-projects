namespace TDDCursusLibrary
{
    public class WoordTeller
    {
        //public int TelWoorden(string zin) => throw new NotImplementedException();
        public int TelWoorden(string zin) => zin.Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries).Length;
    }
}
