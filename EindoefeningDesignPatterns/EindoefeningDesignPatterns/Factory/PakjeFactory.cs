namespace EindoefeningDesignPatterns.Factory
{
    public class PakjeFactory
    {
        public static Pakje MaakPakje(int leeftijd)
        {
            return leeftijd switch
            {
                > 18 => new VolwassenPakje(25m),
                >= 12 => new JeugdPakje(15m),
                _ => new KinderPakje(10m)
            };
        }
    }
}
