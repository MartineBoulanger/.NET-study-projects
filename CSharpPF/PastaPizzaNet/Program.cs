using PastaPizzaNet;
using Gerechten;
using Dranken;
using Desserts;

// Voorbeeld gerechten
Pizza pizza = new Pizza("Pizza Margherita", 8m, new List<string> { "Tomatensaus", "Mozzarella" });
//{
//    Naam = "Pizza Margherita",
//    Prijs = 8m,
//    Onderdelen = new List<string> { "Tomatensaus", "Mozzarella" }
//};

Pasta pasta = new Pasta(
    "Spaghetti Bolognese",
    12m,
    "met gehaktsaus"
);

// Bestelling maken
BesteldGerecht bestelling1 = new BesteldGerecht(
    pizza,
    Grootte.Groot,
    new List<Extra> { Extra.Kaas, Extra.Look }
);

BesteldGerecht bestelling2 = new BesteldGerecht(
    pasta,
    new List<Extra>()
);

Klant klant = new Klant(1, "Jan Janssen");

Bestelling bestel = new Bestelling
{
    Klant = new Klant(2, "Piet Pieters"),
    BesteldGerecht = bestelling2,
    Drank = new Frisdrank(DrankNaam.Water),
    Dessert = new Dessert(DessertNaam.Ijs),
    Aantal = 1
};

Bestelling bestel2 = new Bestelling
{
    Klant = new Klant(2, "Piet Pieters"),
    BesteldGerecht = bestelling2,
    Drank = new Frisdrank(DrankNaam.Water),
    Aantal = 1
};

Bestelling bestel3 = new Bestelling
{
    Klant = new Klant(2, "Piet Pieters"),
    Drank = new Frisdrank(DrankNaam.Water),
    Dessert = new Dessert(DessertNaam.Ijs),
    Aantal = 1
};

Bestelling bestel4 = new Bestelling
{
    Klant = new Klant(2, "Piet Pieters"),
    BesteldGerecht = bestelling2,
    Dessert = new Dessert(DessertNaam.Ijs),
    Aantal = 1
};

// Output
Console.WriteLine(bestel);
Console.WriteLine("--------------------------");
Console.WriteLine(bestel2);
Console.WriteLine("--------------------------");
Console.WriteLine(bestel3);
Console.WriteLine("--------------------------");
Console.WriteLine(bestel4);