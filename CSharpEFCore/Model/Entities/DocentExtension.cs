using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public partial class Docent
    {
        public string Naam { get => Voornaam + " " + Familienaam; }

        [Column(TypeName = "date")]
        public DateTime Geboortedatum { get; set; }
    }
}
