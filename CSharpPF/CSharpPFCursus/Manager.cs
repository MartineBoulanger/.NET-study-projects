// deze class is een derived class van de derived class Bediende
namespace CSharpPFCursus
{
    internal class Manager : Bediende
    {
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

        public override string GetInfo()
        {
            return $"{base.GetInfo()}\nBonus: {Bonus}";
        }

        public override string ToString()
        {
            return $"{base.ToString()} - Bonus: {Bonus} euro";
        }
    }
}
