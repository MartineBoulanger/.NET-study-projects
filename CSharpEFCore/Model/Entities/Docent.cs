namespace Model.Entities
{
    public class Docent
    {
        public int DocentId { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public decimal Wedde { get; set; }

        // Associatie met Campus class
        public int CampusId { get; set; }
        public Campus Campus { get; set; }
    }
}
