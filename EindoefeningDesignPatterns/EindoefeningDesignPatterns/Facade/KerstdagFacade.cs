using EindoefeningDesignPatterns.Builder;
using System.Text;

namespace EindoefeningDesignPatterns.Facade
{
    public class KerstdagFacade
    {
        public void ToonGezin(Gezin gezin)
        {
            decimal totaal = decimal.Zero;

            if (gezin.Kerstboom != null)
                totaal += gezin.Kerstboom.Kost();

            foreach (var verlichting in gezin.Verlichting)
                totaal += verlichting.Prijs;

            foreach (var pakje in gezin.Pakjes)
                totaal += pakje.Prijs;

            StringBuilder sb = new();
            sb.Append($"Gezin: {gezin.Naam}\n\n");
            sb.Append($"Gezinsleden: {string.Join(", ", gezin.Gezinsleden)}\n\n");
            sb.Append(gezin.Kerstboom != null ? gezin.Kerstboom?.Print() + " - Prijs: " + gezin.Kerstboom?.Kost() + " euro\n\n" : "Geen kerstboom gekozen.\n\n");
            sb.Append($"Verlichting: {string.Join(", ", gezin.Verlichting)} - Prijs: {gezin.Verlichting.Sum(v => v.Prijs)} euro\n\n");
            sb.Append($"Pakjes: {string.Join(", ", gezin.Pakjes)} - Prijs: {gezin.Pakjes.Sum(p => p.Prijs)} euro\n\n");
            sb.Append($"Totale kostprijs: {totaal} euro");

            Console.WriteLine(sb.ToString());
        }
    }
}
