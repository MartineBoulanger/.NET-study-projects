using System.ComponentModel.DataAnnotations;

namespace SterrenbeeldService
{
    public class Sterrenbeeld
    {
        public int Id { get; set; }
        [Length(1, 12)]
        public required string Naam { get; set; }
        [Range(1, 31)]
        public int StartDag { get; set; }
        [Range(1, 12)]
        public int StartMaand { get; set; }
        [Range(1, 31)]
        public int EindDag { get; set; }
        [Range(1, 12)]
        public int EindMaand { get; set; }
    }
}
