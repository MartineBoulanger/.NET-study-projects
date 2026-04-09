using System.Text.RegularExpressions;

namespace TDDCursusLibrary
{
    public class ISBN
    {
        private static readonly Regex regex = new Regex("^\\d{13}$");
        private readonly long nummer;

        public ISBN(long nummer)
        {
            //throw new NotImplementedException();
            if (!regex.IsMatch(nummer.ToString())) throw new ArgumentException();
            var somEvenCijfers = 0L;
            var somOnevenCijfers = 0L;
            var teVerwerkenCijfers = nummer / 10;
            for (int teller = 0; teller != 6; teller++)
            {
                somEvenCijfers += teVerwerkenCijfers % 10;
                teVerwerkenCijfers /= 10;
                somOnevenCijfers += teVerwerkenCijfers % 10;
                teVerwerkenCijfers /= 10;
            }
            var controleGetal = somEvenCijfers * 3 + somOnevenCijfers;
            var naastGelegenHoger10Tal = controleGetal - controleGetal % 10 + 10;
            var verschil = naastGelegenHoger10Tal - controleGetal;
            var laatsteCijfer = nummer % 10;
            if (verschil == 10) if (laatsteCijfer != 0) throw new ArgumentException();
            else if (verschil != laatsteCijfer) throw new ArgumentException();
            this.nummer = nummer;
        }

        public override string ToString()
        {
            //throw new NotImplementedException();
            return nummer.ToString();
        }
    }
}
