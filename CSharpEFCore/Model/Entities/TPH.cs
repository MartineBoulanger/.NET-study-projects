namespace Model.Entities
{
    public abstract class TPHCursus
    {
        public int Id { get; set; }
        public string Naam { get; set; }
    }

    public class TPHKlassikaleCursus:TPHCursus
    {
        public DateTime Van { get; set; }
        public DateTime Tot { get; set; }
    }

    public class TPHZelfstudieCursus:TPHCursus
    {
        public int AantalDagen { get; set; }
    }
}

