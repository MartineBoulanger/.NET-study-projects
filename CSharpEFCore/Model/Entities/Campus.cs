using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Campus
    {
        //private readonly ILazyLoader lazyloader;
        //public Campus(ILazyLoader lazyloader)
        //{
        //    this.lazyloader = lazyloader;
        //}
        //public Campus()
        //{
        //    Docenten = new List<Docent>();
        //}

        public int CampusId { get; set; }

        [Required]
        [Column("CampusNaam")]
        public string Naam { get; set; }

        public string Straat { get; set; }

        public string Huisnummer { get; set; }

        public string Postcode { get; set; }

        [StringLength(50)]
        public string Gemeente { get; set; }

        [NotMapped]
        public string Commentaar { get; set; }

        // Associatie met Docent class
        // gebruik virtual om lazy loading te kunnen gebruiken
        //public virtual ICollection<Docent> Docenten { get; set; } = new List<Docent>();
        public ICollection<Docent> Docenten { get; set; } = new List<Docent>();
        // lazy loading met DI
        //private ICollection<Docent> docenten;

        //public ICollection<Docent> Docenten
        //{
        //    get => lazyloader.Load(this, ref docenten);
        //    set => docenten = value;
        //}

    }
}
