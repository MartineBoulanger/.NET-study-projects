using System.ComponentModel.DataAnnotations;

namespace MinimalKaasService.Models
{
    public class Kaas
    {
        public int Id { get; set; }
        [Length(1, 50)]
        public required string Naam { get; set; }
        [Length(1, 50)]
        public required string Soort { get; set; }
        [Length(1, 50)]
        public required string Smaak { get; set; }
    }
}
