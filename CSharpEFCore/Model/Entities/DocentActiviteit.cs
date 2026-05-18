using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    [Table("DocentenActiviteiten")]
    public class DocentActiviteit
    {
        public int DocentId { get; set; } // key
        public int ActiviteitId { get; set; } // key

        public int AantalUren { get; set; }
        public Docent Docent { get; set; }
        public Activiteit Activiteit { get; set; }
    }
}
