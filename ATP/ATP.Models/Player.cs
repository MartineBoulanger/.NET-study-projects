using System.ComponentModel.DataAnnotations;

namespace ATP.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Points cannot be less than 0.")]
        public int Points { get; set; }
        public int WeeksNumberOne { get; set; }
        public DateOnly? FirstOnOne { get; set; }
    }
}
