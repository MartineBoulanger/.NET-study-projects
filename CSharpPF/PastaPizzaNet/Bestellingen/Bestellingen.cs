using Gerechten;
using Dranken;
using Desserts;

namespace PastaPizzaNet.Bestellingen
{
  public class Bestellingen
  {
    // Voor geprogrammeerde bestellingen, zodat we deze kunnen gebruiken in onze tests en in de console applicatie
    public static List<Bestelling> GetBestellingen()
    {
      Klant klantJan = new() { KlantID = 2, Naam = "Jan Janssen"}; // kun je zo schrijven
      var klantPiet = new Klant { KlantID = 3, Naam = "Piet Pieters" }; // of zo

      Pizza pizzaMargherita = new("Pizza Margherita", 8m, ["Tomatensaus", "Mozzarella"]); // kun je zo schrijven
      var pizzaNapoli = new Pizza("Pizza Napoli", 10m, new List<string> { "Tomatensaus", "Mozzarella", "Ansjovis", "Kappers", "Olijven" }); // of zo schrijven
      //var pizzaMargherita2 = new Pizza("Pizza Margherita", 8m, []); // wanneer er geen onderdelen zouden zijn
      //var pizzaNapoli2 = new Pizza("Pizza Napoli", 10m, new List<string>()); // of zo

      Pasta spaghettiBolognese = new("Spaghetti Bolognese", 12m, "met gehaktsaus"); // zo schrijven
      var spaghettiCarbonara = new Pasta("Spaghetti Carbonara", 13m, "spek, roomsaus en parmezaanse kaas"); // of zo
      var lasagne = new Pasta("Lasagne", 15m); // zonder omschrijving

      var bestelling1 = new Bestelling
      {
        Klant = klantJan,
        BesteldGerecht = new BesteldGerecht { Gerecht = pizzaMargherita, Grootte = Grootte.Groot, Extras = [Extra.Kaas, Extra.Look] },
        Drank = new Frisdrank(DrankNaam.Water),
        Dessert = new Dessert(DessertNaam.Ijs),
        Aantal = 2
      };

      var bestelling2 = new Bestelling
      {
        Klant = klantPiet,
        BesteldGerecht = new BesteldGerecht { Gerecht = pizzaMargherita },
        Drank = new Frisdrank(DrankNaam.Water),
        Dessert = new Dessert(DessertNaam.Tiramisu)
      };

      var bestelling3 = new Bestelling
      {
        Klant = klantPiet,
        BesteldGerecht = new BesteldGerecht { Gerecht = pizzaNapoli, Grootte = Grootte.Groot },
        Drank = new Warmedrank(DrankNaam.Thee),
        Dessert = new Dessert(DessertNaam.Ijs)
      };

      Bestelling bestelling4 = new() { BesteldGerecht = new BesteldGerecht { Gerecht = lasagne, Extras = [Extra.Look] } }; // zonder klant in te vullen

      var bestelling5 = new Bestelling
      {
        Klant = klantJan,
        BesteldGerecht = new BesteldGerecht { Gerecht = spaghettiCarbonara },
        Drank = new Frisdrank(DrankNaam.CocaCola),
      };

      var bestelling6 = new Bestelling
      {
        Klant = klantPiet,
        BesteldGerecht = new BesteldGerecht { Gerecht = spaghettiBolognese, Grootte = Grootte.Groot, Extras = [Extra.Kaas] },
        Drank = new Frisdrank(DrankNaam.CocaCola),
        Dessert = new Dessert(DessertNaam.Cake)
      };

      var bestelling7 = new Bestelling
      {
        Klant = klantPiet,
        Drank = new Warmedrank(DrankNaam.Koffie),
        Aantal = 3
      };

      var bestelling8 = new Bestelling
      {
        Klant = klantJan,
        Dessert = new Dessert(DessertNaam.Tiramisu)
      };

      return [
         bestelling1,
         bestelling2,
         bestelling3,
         bestelling4,
         bestelling5,
         bestelling6,
         bestelling7,
         bestelling8
      ];
    }
  }
}
