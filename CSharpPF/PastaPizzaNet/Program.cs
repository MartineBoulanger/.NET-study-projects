//using Dranken;
//using Gerechten;
//using Desserts;
using PastaPizzaNet;
using PastaPizzaNet.Bestellingen;

// om 1 enkele bestelling te testen
//Bestelling bestelling1 = new()
//{
//  Klant = new Klant { KlantID = 2, Naam = "Jan Janssen" },
//  BesteldGerecht = new BesteldGerecht { Gerecht = new Pizza("Pizza Hawaii", 14m, ["Tomatensaus", "ananas", "ham", "kaas", "champignons"]), Grootte = Grootte.Groot, Extras = [Extra.Look, Extra.Kaas] },
//  Drank = new Frisdrank(DrankNaam.Limonade),
//  Dessert = new Dessert(DessertNaam.Ijs),
//  Aantal = 5
//};
//Console.WriteLine(bestelling1);

// initialiseren van de bestellingen in de class Bestellingen
var bestellingen = Bestellingen.GetBestellingen();
TekenLijn tekenLijn = new TekenLijn();

// Alle bestellingen laten zien
Console.WriteLine("Alle bestellingen");
tekenLijn.Lijn(120, '*');
int teller = 1; // om de bestelnummer te weergeven
bestellingen.ForEach(b =>
{
  Console.WriteLine($"Bestelling {teller}:");
  Console.WriteLine(b);
  tekenLijn.Lijn(120);
  teller++;
});


// Bestellingen van Jan Janssen
Console.WriteLine();
Console.WriteLine("Bestellingen van klant Jan Janssen");
tekenLijn.Lijn(120, '*');
//var janBestellingen = bestellingen.Where(b => b.Klant.Naam == "Jan Janssen");
var janBestellingen = from bestelling in bestellingen where bestelling.Klant.Naam == "Jan Janssen" select bestelling;
foreach (var b in janBestellingen)
{
  Console.WriteLine(b);
  tekenLijn.Lijn(120);
}
Console.WriteLine($"Totaal bedrag van alle bestellingen van klant Jan Janssen: {janBestellingen.Sum(b => b.BerekenBedrag()):0.00} euro");
tekenLijn.Lijn(120);

// groeperen per klant
Console.WriteLine();
Console.WriteLine("Bestellingen gegroepeerd per klant");
tekenLijn.Lijn(120, '*');
//var perKlant = bestellingen.GroupBy(b => b.Klant.Naam);
var perKlant = from bestelling in bestellingen group bestelling by bestelling.Klant.Naam;
foreach (var groep in perKlant)
{
  Console.WriteLine();
  if (groep.Key != "Onbekende klant")
    Console.WriteLine($"Bestelling van klant {groep.Key}:\n");
  else
    Console.WriteLine("Onbekende klanten:\n");

  foreach (var b in groep)
  {
    Console.WriteLine(b);
    Console.WriteLine();
  }
  if (groep.Key != "Onbekende klant")
    Console.WriteLine($"Totaal bedrag van alle bestellingen van klant {groep.Key}: {groep.Sum(b => b.BerekenBedrag()):0.00} euro");
  tekenLijn.Lijn(120);
}
