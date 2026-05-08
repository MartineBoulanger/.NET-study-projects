using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Land
    {
        //private readonly ILazyLoader lazyloader;
        //public Land(ILazyLoader lazyloader)
        //{

        //}
        //public Land()
        //{
        //    Docenten = new List<Docent>();
        //}

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] // geen auto nummering
        public string LandCode { get; set; }

        public string Naam { get; set; }

        // associatie met Docent class
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
