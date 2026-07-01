namespace EindoefeningDesignPatterns.Factory
{
    public class PakjeFactory
    {
        public static Pakje MaakPakje(int leeftijd)
        {
            return leeftijd switch
            {
                > 18 => new VolwassenPakje(),
                >= 12 => new JeugdPakje(),
                _ => new KinderPakje()
            };
        }
    }
}
