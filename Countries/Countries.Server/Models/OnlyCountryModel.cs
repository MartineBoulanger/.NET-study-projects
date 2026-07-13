namespace Countries.Server.Models
{
    public class OnlyCountryModel
    {
        public required string Name { get; set; } = string.Empty;
        public required string Capital { get; set; } = string.Empty;
        public required long Population { get; set; }
    }
}
