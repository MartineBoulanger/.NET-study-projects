namespace Model.Entities
{
    public class ArtikelGroep
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public virtual ICollection<Artikel> Artikels { get; set; } = new List<Artikel>();
    }
}
