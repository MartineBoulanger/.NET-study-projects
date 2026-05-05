using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Land
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] // geen auto nummering
        public string LandCode { get; set; }

        public string Naam { get; set; }

        // associatie met Docent class
        public ICollection<Docent> Docenten { get; set; }
    }
}
