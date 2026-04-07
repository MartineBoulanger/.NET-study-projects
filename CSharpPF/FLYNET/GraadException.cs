namespace FLYNET
{
    public class GraadException:Exception
    {
        public Enums.Graad VerkeerdeGraad { get; set; }
        public GraadException(string message, Enums.Graad verkeerdeGraad):base(message)
        {
            VerkeerdeGraad = verkeerdeGraad;
        }
    }
}
