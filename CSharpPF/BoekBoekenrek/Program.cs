using BoekBoekenrek;
using BoekBoekenrek.Boek;
using BoekBoekenrek.Boek.Materiaal;
using BoekBoekenrek.Boek.BoekSoort;

// tekenLijn initialiseren
TekenLijn tekenLijn = new();

// objecten maken voor de array
Leesboek leesboek = new("Harry Potter", "J.K. Rowling", 20m, new Genre("fictie", 15), "toveren");
Woordenboek woordenboek = new("Vandale", "Kramers", 100m, new Genre("vreemd", 20), "NL-E");
Boekenrek rek = new(3f, 2.5f, 200m);

// IVoorwerp array initialiseren
IVoorwerp[] lijst = [leesboek, woordenboek, rek];

// variabele om de totale winst in op te slaan
decimal totaleWinst = 0m;

// de gegevens van elk object in de array tonen
foreach (var item in lijst) 
{
    string typeNaam = item.GetType().Name;
    Console.WriteLine(typeNaam);
    tekenLijn.Lijn(typeNaam.Length);
    Console.WriteLine(item.Gegevens());
    totaleWinst += item?.Winst ?? 0;
    Console.WriteLine();
}

// totale winst tonen
tekenLijn.Lijn(27);
Console.WriteLine($"Totale winst: {totaleWinst:0.00} euro");