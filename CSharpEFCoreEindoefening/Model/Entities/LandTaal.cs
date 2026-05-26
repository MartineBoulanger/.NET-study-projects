using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class LandTaal
    {
        [StringLength(2)]
        public string LandCode { get; set; } = null!;

        [StringLength(2)]
        public string TaalCode { get; set; } = null!;

        public Land? Land { get; set; }

        public Taal? Taal { get; set; }
    }
}
