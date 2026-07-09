namespace Countries.Server.Models
{
    public class Language
    {
        public required int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public virtual ICollection<Country> Countries { get; set; }
        = new List<Country>();
    }
}
