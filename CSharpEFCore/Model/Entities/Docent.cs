using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public partial class Docent
    {
        //private readonly ILazyLoader lazyloader;
        //public Docent() { }
        //public Docent(ILazyLoader lazyloader)
        //{
        //    this.lazyloader = lazyloader;
        //}

        // tussen klasse
        public Docent()
        {
            DocentenActiviteiten = new List<DocentActiviteit>();
        }

        public int DocentId { get; set; }

        [Required]
        [StringLength(20)]
        public string Voornaam { get; set; }

        [Required]
        [StringLength(30)]
        public string Familienaam { get; set; }

        [Column("Maandwedde")]
        [Precision(18, 2)]
        public decimal Wedde { get; set; }

        [Column(TypeName = "date")]
        public DateTime InDienst { get; set; }

        public bool? HeeftRijbewijs { get; set; }

        public Geslacht Geslacht { get; set; }

        public Adres ThuisAdres { get; set; }
        public Adres VerblijfAdres { get; set; }

        // Associatie met Land class
        // gebruik virtual om lazy loading te kunnen gebruiken
        [ForeignKey("Land")]
        public string? LandCode { get; set; }
        //public virtual Land Land { get; set; } = null!;
        public Land? Land { get; set; }
        //private Land land;
        //public Land Land
        //{
        //    get => lazyloader.Load(this, ref land);
        //    set => land = value;
        //}


        // Associatie met Campus class
        // gebruik virtual om lazy loading te kunnen gebruiken
        public int CampusId { get; set; }
        //public virtual Campus Campus { get; set; } = null!;
        public Campus Campus { get; set; } = null!;
        //private Campus campus;
        //public Campus Campus
        //{
        //    get => lazyloader.Load(this, ref campus);
        //    set => campus = value;
        //}

        public void Opslag(decimal bedrag) => Wedde += bedrag;

        // Associatie met Activiteit class via de tussenklasse DocentActiviteit
        public ICollection<DocentActiviteit> DocentenActiviteiten { get; set; }
    }
}
