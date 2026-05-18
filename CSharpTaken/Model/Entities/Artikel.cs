namespace Model.Entities
{
    public abstract class Artikel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public virtual ArtikelGroep ArtikelGroep { get; set; }
        public int ArtikelGroepId { get; set; }
    }

    public class FoodArtikel : Artikel
    {
        public int Houdbaarheid { get; set; }
    }

    public class NonFoodArtikel : Artikel
    {
        public int Garantie { get; set; }
    }
}
