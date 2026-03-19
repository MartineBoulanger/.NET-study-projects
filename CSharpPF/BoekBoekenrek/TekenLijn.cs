namespace BoekBoekenrek
{
    internal class TekenLijn
    {
        public void Lijn(int lengte, char teken = '-')
        {
            for (int teller = 0; teller < lengte; teller++)
            {
                Console.Write(teken);
            }
            Console.WriteLine();
        }
    }
}
