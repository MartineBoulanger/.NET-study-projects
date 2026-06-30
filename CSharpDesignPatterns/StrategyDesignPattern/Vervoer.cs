using System.Text;

namespace StrategyDesignPattern
{
    public delegate string VervoerDelegate();
    public class Vervoer
    {
        public string DoeEenOversteek(VervoerDelegate manier)
        {
            StringBuilder sb = new();
            sb.Append("Inpakken\n");
            sb.Append(manier() + "\n");
            sb.Append("Uitpakken");
            return sb.ToString();
        }
    }
}
