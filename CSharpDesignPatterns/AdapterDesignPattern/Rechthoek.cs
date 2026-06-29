namespace AdapterDesignPattern
{
    public class Rechthoek(int lengte, int breedte)
    {
        public int Lengte { get; set; } = lengte;
        public int Breedte { get; set; } = breedte;
    }

    public class Calculator
    {
        public int BerekenOppervlakte(Rechthoek rechthoek) => rechthoek.Breedte * rechthoek.Lengte;
    }

    public class Vierkant(int zijde)
    {
        public int Zijde { get; set; } = zijde;
    }

    public class CalculatorAdapter
    {
        public int BerekenOppervlakte(object vorm)
        {
            Calculator calculator = new Calculator();
            if (vorm is Rechthoek rechthoek) return calculator.BerekenOppervlakte(rechthoek);
            if (vorm is Vierkant vierkant) return calculator.BerekenOppervlakte(new Rechthoek(vierkant.Zijde, vierkant.Zijde));
            throw new ArgumentException("Onbekend vormtype");
        }
    }
}
