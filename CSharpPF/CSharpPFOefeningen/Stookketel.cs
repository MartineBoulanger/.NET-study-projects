namespace CSharpPFOefeningen
{
    public class Stookketel:IVervuiler
    {
        public float CONorm { get => field; set => field = value > 0f ? value : 0f; }

        public Stookketel(float coNorm)
        {
            CONorm = coNorm;
        }

        public double GeefVervuiling()
        {
            return CONorm * 100;
        }
    }
}