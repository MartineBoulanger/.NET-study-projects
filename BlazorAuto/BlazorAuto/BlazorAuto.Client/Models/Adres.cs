using System.ComponentModel.DataAnnotations;

namespace BlazorAuto.Client.Models
{
    public class Adres
    {
        [Required(ErrorMessage = "Straat en num mer is een verplicht veld")]
        public string StraatEnNr { get; set; }

        [Required(ErrorMessage = "{0} is een verplicht veld")]
        public string Postcode { get; set; }

        [Required(ErrorMessage = "{0} is een verplicht veld")]
        public string Gemeente { get; set; }
    }
}
