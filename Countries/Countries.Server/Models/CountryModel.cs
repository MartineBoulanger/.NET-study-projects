namespace Countries.Server.Models
{
    public class CountryModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string Capital { get; set; } = string.Empty;
        public required long Population { get; set; }
    }
}
