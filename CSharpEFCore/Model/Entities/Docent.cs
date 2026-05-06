using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public partial class Docent
    {
        public int DocentId { get; set; }

        [Required]
        [StringLength(20)]
        public string Voornaam { get; set; }

        [Required]
        [StringLength(30)]
        public string Familienaam { get; set; }

        [Column("Maandwedde")]
        [Precision(18,2)]
        public decimal Wedde { get; set; }

        [Column(TypeName = "date")]
        public DateTime InDienst { get; set; }

        public bool? HeeftRijbewijs { get; set; }

        public Geslacht Geslacht { get; set; }

        // Associatie met Land class
        [ForeignKey("Land")]
        public string LandCode { get; set; }

        public Land Land { get; set; }

        // Associatie met Campus class
        public int CampusId { get; set; }
        public Campus Campus { get; set; }
    }
}
