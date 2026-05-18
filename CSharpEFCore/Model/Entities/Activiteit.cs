using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    [Table("Activiteiten")]
    public class Activiteit
    {
        public Activiteit()
        {
            DocentenActiviteiten = new List<DocentActiviteit>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActiviteitId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Naam { get; set; }

        public ICollection<DocentActiviteit> DocentenActiviteiten { get; set; }
    }
}
