using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Land
    {
        [Key]
        [StringLength(2)]
        public string ISOLandCode { get; set; } = null!;

        [StringLength(3)]
        public string? NISLandCode { get; set; }

        [StringLength(50)]
        public string Naam { get; set; } = null!;

        public int AantalInwoners { get; set; }

        public float Oppervlakte { get; set; }

        [Timestamp]
        public byte[]? Aangepast { get; set; }

        // navigation properties
        public ICollection<Stad> Steden { get; set; } = new List<Stad>();
        public ICollection<LandTaal> LandTalen { get; set; } = new List<LandTaal>();
    }
}
