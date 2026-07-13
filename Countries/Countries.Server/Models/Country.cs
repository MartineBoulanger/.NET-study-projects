namespace Countries.Server.Models
{
    public class Country
    {
        public required int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string Capital { get; set; } = string.Empty;
        public required long Population { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
        = new List<Language>();
        public Flag? Flag { get; set; } = null!;
    }
}
