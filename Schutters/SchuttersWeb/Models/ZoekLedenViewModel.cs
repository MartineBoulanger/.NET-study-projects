using SchuttersData.Models;

namespace SchuttersWeb.Models
{
    public class ZoekLedenViewModel
    {
        public string? Voornaam { get; set; }
        public string? Naam { get; set; }
        public Geslacht? Geslacht { get; set; }
        public Niveau? Niveau { get; set; }
        public string? Clubnaam { get; set; }
        public IEnumerable<Lid>? Resultaten { get; set; }
    }
}
