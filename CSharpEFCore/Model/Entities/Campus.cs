namespace Model.Entities
{
    public class Campus
    {
        public int CampusId { get; set; }
        public string Naam { get; set; }
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public string Postcode { get; set; }
        public string Gemeente { get; set; }

        // Associatie met Docent class
        public ICollection<Docent> Docenten { get; set; }
    }
}
