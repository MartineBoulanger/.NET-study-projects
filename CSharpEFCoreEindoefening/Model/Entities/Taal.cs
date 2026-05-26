using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Taal
    {
        [Key]
        [StringLength(2)]
        public string ISOTaalCode { get; set; } = null!;

        [StringLength(50)]
        public string NaamNL { get; set; } = null!;

        [StringLength(50)]
        public string? NaamTaal { get; set; }

        public ICollection<LandTaal> LandTalen { get; set; } = new List<LandTaal>();
    }
}
