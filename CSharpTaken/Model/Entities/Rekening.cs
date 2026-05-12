using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Rekening
    {
        [Key]
        public string RekeningNr { get; set; } = null!;

        public int KlantNr { get; set; }

        [Precision(18, 2)]
        public decimal Saldo { get; set; }

        public char Soort { get; set; }

        // associatie -- foreign key altijd hier zetten bij de associatie -- maar wel een property aanmaken voor de FK
        [ForeignKey("KlantNr")]
        public Klant Klant { get; set; } = null!;

        public void Storten(decimal bedrag) => Saldo += bedrag;
    }
}
