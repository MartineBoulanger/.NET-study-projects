namespace FacadeDesignPattern
{
    public class Persoon
    {
        public Beroepsinkomsten Beroepsinkomsten { get; }
        public Rekening Rekening { get; }
        public List<Lening> Leningen { get; }
        public Persoon(Beroepsinkomsten beroepsinkomsten, Rekening rekening)
        {
            Beroepsinkomsten = beroepsinkomsten;
            Rekening = rekening;
            Leningen = new List<Lening>();
        }
        public void AddLening(Lening lening)
        {
            Leningen.Add(lening);
        }
    }
}
