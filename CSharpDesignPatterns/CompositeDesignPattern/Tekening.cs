namespace CompositeDesignPattern
{
    public class Tekening : IFiguur
    {
        public List<IFiguur> Figuren { get; set; } = [];
        public void Add(IFiguur figuur)
        {
            Figuren.Add(figuur);
        }
        public double Oppervlakte()
        {
            double oppervlakte = 0;
            foreach (IFiguur figuur in Figuren) oppervlakte += figuur.Oppervlakte();
            return oppervlakte;
        }
    }

    public class Rechthoek(double lengte, double breedte) : IFiguur
    {
        public double Lengte { get; set; } = lengte;
        public double Breedte { get; set; } = breedte;
        public double Oppervlakte() => Lengte * Breedte;
    }

    public class Cirkel(double straal) : IFiguur
    {
        public double Straal { get; set; } = straal;
        public double Oppervlakte() => Straal * Straal * Math.PI;
    }
}
