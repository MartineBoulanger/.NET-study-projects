using Firma.Materiaal;

namespace Firma.Personeel
{
    /* deze class is een derived class van de derived class Bediende */
    public sealed class Manager : Bediende
    {
        // met de parameter Afdeling
        // public Manager(string naam, DateTime inDienst, Geslacht geslacht, Afdeling afdeling, decimal wedde, decimal bonus) : base(naam,inDienst,geslacht,afdeling,wedde)
        // {
        //     Bonus = bonus;
        // }
        public Manager(string naam, DateTime inDienst, Geslacht geslacht, decimal wedde, decimal bonus) : base(naam,inDienst,geslacht,wedde)
        {
            Bonus = bonus;
        }

        private decimal bonus;

        public decimal Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        }

        // overschrijven van de abstract property Premie
        public override decimal Premie
        {
            get { return Bonus * 3m; }
        }
        // overschrijf de method van de interface IKost
        // public override decimal BerekenKostprijs()
        // {
        //     return base.BerekenKostprijs() + Bonus;
        // }
        public override decimal BerekenKostprijs() => base.BerekenKostprijs() + Bonus;

        public override string GetInfo()
        {
            return $"{base.GetInfo()}\nBonus: {Bonus}";
        }

        public override string ToString()
        {
            return $"{base.ToString()} - Bonus: {Bonus} euro";
        }

        // methods om de event te triggeren
        public void OnderhoudNoteren(Fotokopiemachine machine)
        {
            Console.WriteLine($"{Naam} registreert het onderhoud van machine {machine.SerieNr} in het logboek.");
        }
    }

    //public class Directeur:Manager { } // dit gaat dus niet
}
