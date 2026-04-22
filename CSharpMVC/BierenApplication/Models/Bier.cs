using System.ComponentModel.DataAnnotations;

namespace BierenApplication.Models
{
    public class Bier
    {
        [DisplayFormat(DataFormatString = "{0:D3}")]
        public required int Id { get; init; }
        public required string Naam { get; set; }
        [UIHint("percentage")]
        public required float Alcohol { get; set; }
    }
}
