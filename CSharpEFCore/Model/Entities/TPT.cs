namespace Model.Entities
{
    public abstract class TPTCursus
    {
        public int Id { get; set; }
        public string Naam { get; set; }
    }

    public class TPTKlassikaleCursus:TPTCursus
    {
        public DateTime Van { get; set; }
        public DateTime Tot { get; set; }
    }

    public class TPTZelfstudieCursus:TPTCursus
    {
        public int AantalDagen { get; set; }
    }
}