using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Personeelslid
    {
        [Key]
        public int PersoneelsNr { get; set; }

        [Required]
        [StringLength(50)]
        public string Voornaam { get; set; }

        public int? ManagerNr { get; set; }

        public virtual ICollection<Personeelslid> Ondergeschikten { get; set; } = new List<Personeelslid>();

        [InverseProperty("Ondergeschikten")]
        [ForeignKey("ManagerNr")]
        public virtual Personeelslid? Manager { get; set; }

       
    }
}
