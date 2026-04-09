using System.Text.RegularExpressions;

namespace TDDCursusLibrary
{
    public class Rekeningnummer
    {
        private static readonly Regex regex = new Regex("^BE(\\d{2})(\\d{12})$");
        private readonly string nummer;
        //public Rekeningnummer(string nummer) => throw new NotImplementedException();
        public Rekeningnummer(string nummer)
        {
            if (!regex.IsMatch(nummer))
            {
                throw new ArgumentException("Verkeerd formaat");
            }

            var controleString = nummer.Substring(2,2);
            var rekeningString = nummer.Substring(4, nummer.Length - 4) + "1114" + controleString;
            var rekeningGetal = long.Parse(rekeningString);
            var controleGetal = int.Parse(controleString);

            if (controleGetal < 2 || controleGetal > 98) throw new ArgumentException("1e of 2de cijfer verkeer");
            if (rekeningGetal % 97 != 1) throw new ArgumentException("Nummer bevat verkeerde cijfers");

            this.nummer = nummer;
        }

        //public override string ToString() => throw new NotImplementedException();
        public override string ToString() => nummer;
    }
}
