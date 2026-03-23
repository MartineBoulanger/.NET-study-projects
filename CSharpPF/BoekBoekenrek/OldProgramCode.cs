//using BoekBoekenrek;
//using BoekBoekenrek.Boek;
//using BoekBoekenrek.Boek.Materiaal;
//using BoekBoekenrek.Boek.BoekSoort;

//// tekenLijn initialiseren
//TekenLijn tekenLijn = new();

//// doelgroepen initialiseren
//Doelgroep doelgroepJeugd = new() { Leeftijd = 15 };
//Doelgroep doelgroepVolwassenen = new() { Leeftijd = 20 };

//// genres initialiseren
//Genre fictie = new()
//{
//    Naam = "fictie",
//    Doelgroep = doelgroepJeugd
//};
//Genre vreemd = new()
//{
//    Naam = "vreemd",
//    Doelgroep = doelgroepVolwassenen
//};

//// objecten maken voor de array
//Leesboek leesboek = new("Harry Potter", "J.K. Rowling", 20m, fictie, "toveren");
//Woordenboek woordenboek = new("Vandale", "Kramers", 100m, vreemd, "NL-E");
//Boekenrek rek = new(3f, 2.5f, 200m);

//// IVoorwerp array initialiseren
//IVoorwerp[] lijst = [leesboek, woordenboek, rek];

//// de gegevens van elk object in de array tonen
//foreach (var item in lijst)
//{
//    string typeNaam = item.GetType().Name;
//    Console.WriteLine(typeNaam);
//    tekenLijn.Lijn(typeNaam.Length);
//    switch (item)
//    {
//        case Leesboek l:
//            Console.WriteLine(l.Gegevens());
//            break;
//        case Woordenboek w:
//            Console.WriteLine(w.Gegevens());
//            break;
//        case Boekenrek b:
//            Console.WriteLine(b.Gegevens());
//            break;
//        default:
//            break;
//    }
//    Console.WriteLine();
//}

//// totale winst berekenen
//tekenLijn.Lijn(27);
//decimal totaleWinst = 0m;
//foreach (var item in lijst)
//{
//    if (item != null) totaleWinst += item.Winst();
//}
//Console.WriteLine($"Totale winst: {totaleWinst:0.00} euro");