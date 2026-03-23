namespace CSharpPFCursus
{
    partial class Program
    {
        const double CentimetersPerInch = 2.54;
        static double CmToInch(double cm)
        {
            return cm / CentimetersPerInch;
        }
        static double InchToCm(double inch)
        {
            return inch * CentimetersPerInch;
        }
        static void TekenLijn(int lengte, char teken = '-')
        {
            for (int i = 0; i < lengte; i++)
            {
                Console.Write(teken);
            }
            Console.WriteLine();
        }
    }
}