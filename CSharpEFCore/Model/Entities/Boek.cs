using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Boek
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BoekNr { get; set; }
        public string IsbnNr { get; set; }
        public string Titel { get; set; }
        public ICollection<Cursus> Cursussen { get; set; } = new List<Cursus>();
    }
}
