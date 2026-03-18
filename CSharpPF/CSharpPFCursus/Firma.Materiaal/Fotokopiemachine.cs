namespace Firma.Materiaal
{
    public class Fotokopiemachine:IKost
    {
        // properties van de class
        public string SerieNr { get; set; }
        public int AantalGekopieerdeBlz { get; set { if (value >= 0) field = value; } }
        public decimal KostPerBlz { get; set { if (value > 0) field = value; } }
        // constructor met parameters
        public Fotokopiemachine(string serieNr, int aantalGekopieerdeBlz, decimal kostPerBlz)
        {
            SerieNr = serieNr;
            AantalGekopieerdeBlz = aantalGekopieerdeBlz;
            KostPerBlz = kostPerBlz;
        }
        // properties en methods van de interface
        public bool Menselijk => false;
        public decimal BerekenKostprijs() => AantalGekopieerdeBlz * KostPerBlz;
        // methods van de class

    }
}