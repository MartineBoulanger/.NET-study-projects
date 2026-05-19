using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
    public class Voorraad
    {
        public int MagazijnNr { get; set; }

        public int CursusNr { get; set; }

        [Required]
        public int AantalStuks { get; set; }

        [Required]
        public int RekNr { get; set; }

        [Timestamp]
        public byte[]? Aangepast { get; set; }
    }
}
