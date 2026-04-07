namespace FLYNET.Personeel
{
    public class NietVliegendPersoneelslid:Personeelslid
    {
        public int UrenPerWeek { get; set => field = value < 0 ? throw new Exception("Uren per week moeten boven 0 zijn.") : value; }
        public Enums.Afdeling? Afdeling { get; set; } = Enums.Afdeling.Incheckbalie; // Incheckbalie is de default
    }
}
