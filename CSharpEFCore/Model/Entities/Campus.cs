using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Campus
    {
        public int CampusId { get; set; }

        [Required]
        [Column("CampusNaam")]
        public string Naam { get; set; }

        public string Straat { get; set; }

        public string Huisnummer { get; set; }

        public string Postcode { get; set; }

        [StringLength(50)]
        public string Gemeente { get; set; }

        [NotMapped]
        public string Commentaar { get; set; }

        // Associatie met Docent class
        public ICollection<Docent> Docenten { get; set; }
    }
}
