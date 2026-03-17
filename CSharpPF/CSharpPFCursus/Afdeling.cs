namespace CSharpPFCursus
{
    public class Afdeling
    {
        private const int Verdiepingen = 10;

        // Je kunt een contructor met parameters proberen - maar je kunt ook proberen met required properties ipv contructor
        // public Afdeling(string naam, int verdieping)
        // {
        //     Naam = naam;
        //     Verdieping = verdieping;
        // }
        
        public required string Naam { get; set; }

        private int verdieping;
        public required int Verdieping
        {
            get => verdieping;
            set
            {
                if (value >= 0 && value <= Verdiepingen) verdieping = value;
            }
        }

        public override string ToString()
        {
            return $"Afdeling: {Naam} op verdieping {Verdieping}";
        }
    }
}