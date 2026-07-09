using Countries.Server.Models;

namespace Countries.Server.DTOs
{
    public static class DTOExtensions
    {
        public static CountryDTO ToModel(this Country country) => new(country.Id, country.Name, country.Capital, country.Population);
        public static LanguageDTO ToModel(this Language language) => new(language.Id, language.Name);
    }
}
