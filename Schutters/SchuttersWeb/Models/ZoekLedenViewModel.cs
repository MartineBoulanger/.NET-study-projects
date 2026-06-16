using SchuttersData.Models;

namespace SchuttersWeb.Models
{
    public class ZoekLedenViewModel
    {
        public string? Voornaam { get; set; }
        public string? Naam { get; set; }
        public string? Geslacht { get; set; }
        public string? Niveau { get; set; }
        public string? Clubnaam { get; set; }
        public IEnumerable<Lid>? Resultaten { get; set; }
    }
}
