using System.Text;

namespace FLYNET.Personeel
{
    public class VliegendPersoneelslid:Personeelslid
    {
        public virtual required Enums.Graad Graad { get; set; } // deze wordt in de subclasses gebruikt
        public required List<Certificaat> Certificaten { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Graad: {Graad}");
            sb.AppendLine("Certificaten:");
            foreach (Certificaat cert in Certificaten)
            {
                sb.AppendLine($"  {cert.ToString()}");
            }
            return base.ToString() + "\n" + sb.ToString(); 
        }
    }
}
