namespace CSharpPFCursus
{
    public class LijnenTrekker
    {
        // method met meerdere parameters
        public void TekenLijn(int lengte, char teken = '-')
        {
            for (int teller = 0; teller < lengte; teller++)
            {
                Console.Write(teken);
            }
            Console.WriteLine();
        }
        // method met 1 parameter
        public void TekenLijn(int lengte)
        {
            TekenLijn(lengte, '+');
        }
        // method zonder parameters
        public void TekenLijn()
        {
            TekenLijn(79);
        }

        public const double CmPerInch = 2.54;
        public double CmNaarInch(double cm)
        {
            return cm / CmPerInch;
        }
        // met de lambda pijl
        public double InchNaarCm(double inch) => inch * CmPerInch;
    }
}