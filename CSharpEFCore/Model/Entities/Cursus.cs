using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Cursus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CursusNr { get; set; }
        public string Naam { get; set; }
        public ICollection<Boek> Boeken { get; set; } = new List<Boek>();
    }
}
