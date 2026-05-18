using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
    public class Werknemer
    {
        [Key]
        public int WerknemerId { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public ICollection<Werknemer> Ondergeschikten { get; set; } = new List<Werknemer>();
        public Werknemer? Overste { get; set; }
        public int? OversteId { get; set; }
    }
}
