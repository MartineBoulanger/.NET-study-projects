using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Stad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StadId { get; set; }

        [StringLength(50)]
        public string Naam { get; set; } = null!;

        [StringLength(2)]
        public string ISOLandCode { get; set; } = null!;

        [Timestamp]
        public byte[]? Aangepast { get; set; }

        // navigation properties
        public Land? Land { get; set; }
    }
}
