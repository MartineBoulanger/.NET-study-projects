namespace CompositeDesignPattern
{
    public class Project : IKost
    {
        public List<IKost> Kosten { get; set; } = [];
        public decimal Bedrag
        {
            get
            {
                decimal tussenTotaal = decimal.Zero;
                foreach (IKost kost in Kosten) tussenTotaal += kost.Bedrag;
                return tussenTotaal;
            }
        }
        public void AddKost(IKost kost)
        {
            Kosten.Add(kost);
        }
    }

    public class GrondstofKost(decimal eenheidsprijs, decimal hoeveelheid) : IKost
    {
        public decimal Eenheidsprijs { get; set; } = eenheidsprijs;
        public decimal Hoeveelheid { get; set; } = hoeveelheid;
        public decimal Bedrag
        {
            get => Eenheidsprijs * Hoeveelheid;
        }
    }

    public class Arbeidskost(decimal uurloon, decimal aantalUren) : IKost
    {
        public decimal Uurloon { get; set; } = uurloon;
        public decimal AantalUren { get; set; } = aantalUren;
        public decimal Bedrag
        {
            get => Uurloon * AantalUren;
        }
    }
}
