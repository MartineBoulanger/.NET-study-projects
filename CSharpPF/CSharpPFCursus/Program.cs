// See https://aka.ms/new-console-template for more information
//Console.Write("Asterix");
//Console.Write(" en Obelix");
// Console.WriteLine("Hello World!");
//Console.WriteLine("Asterix");
//Console.WriteLine("Obelix");
//Console.WriteLine("Hallo");

//int aantalKinderen = 4;
//Console.WriteLine(aantalKinderen);
//var aantalWagens = 5;
//Console.WriteLine(aantalWagens.GetType());
//var wedde = 1500m;
//Console.WriteLine(wedde.GetType());

//ulong btwNummer = 0213252520UL;
//ulong eersteCijfers = btwNummer / 100;
//int rest = (int)(eersteCijfers % 97);
//int controle = (int)(btwNummer % 100);
//Console.WriteLine("97 - de rest van de deling: " + (97 - rest));
//Console.WriteLine("Twee laatste cijfers: " + controle);

//int aantalMensen = 0;
//Console.WriteLine(++aantalMensen);
//Console.WriteLine(aantalMensen++);
//Console.WriteLine(aantalMensen);

// Console.WriteLine(4 == 3);
// Console.WriteLine(4.2 != 4);
// Console.WriteLine('A' < 'E');

/* Strings gebruiken */
// using System;
// string kinderenWoord = "7";
// Byte kinderen = Convert.ToByte(kinderenWoord);
// Console.WriteLine(kinderen);

// const float CmInch = 2.54f;
// Console.Write("Geef een lengte in cm: ");
// float lengteInCm = float.Parse(Console.ReadLine()); 
// Console.WriteLine("lengte in inch: " + lengteInCm / CmInch);

// Console .WriteLine("Dit is een dubbel aanhalingsteken: \".");
// Console .WriteLine("De standaard windows directory is c:\\windows" );
// char aanhalingsteken = '\'' ;
// Console .WriteLine(aanhalingsteken);

// samengestelde strings
// string krijger1 = "Asterix";
// string krijger2 = "Obelix";
// met de + operator
// Console.WriteLine(krijger1 + " en " + krijger2 + " zijn goede vrienden.");
// met placeholders
// Console.WriteLine("{0} en {1} zijn goede vrienden.", krijger1, krijger2);
// of
// string tekst = string.Format("{0} en {1} zijn goede vrienden.", krijger1, krijger2);
// Console.WriteLine(tekst);
// zonder opmaakcode
// float puntenWiskunde = 7.0f;
// float puntenInformatica = 8.0f;
// float puntenEngels = 5.0f;
// float gemiddelde = (puntenWiskunde + puntenInformatica + puntenEngels) / 3;
// Console.WriteLine("gemiddelde: {0}", gemiddelde);
// met opmaakcode
// Console.WriteLine("gemiddelde: {0:F2}", gemiddelde);
// met interpolatie
// double straal = 5.0;
// Console.WriteLine($"De omtrek van een cirkel met straal {straal} cm bedraagt {2 * Math.PI * straal} cm.");
// Console.WriteLine($"De omtrek van een cirkel met straal {straal} cm bedraagt {2 * Math.PI * straal:0.00} cm.");
//één aanhalingsteken meer dan in de string
// string welkom = """"
// Welkom """Jan"""
// """" ;
// Console .WriteLine(welkom); //Welkom """Jan"""
// Raw string literals en interpolated string literals kunnen gecombineerd worden.
// string naam = "Jan" ;
// int leeftijd = 30;
// string tekst = $"""
// Hallo {naam},
// Je bent {leeftijd} jaar oud.
// """;
// Console.WriteLine(tekst);
// var naam = " Piet " ;
// var leeftijd = 40 ;
// var json = $$"""
// {
// "naam": "{{naam}}",
//  leeftijd": {{leeftijd}}
// }
// """ ;
// Console .WriteLine(json);

/* DateTime gebruiken */
// DateTime beginTijdRekening = new DateTime();
// DateTime beginEuro = new DateTime(2000, 1, 1);
// DateTime mijnGeboorteDatum = new DateTime(1982, 12, 8, 21, 0, 0);
// Console.WriteLine(beginTijdRekening);
// Console.WriteLine(beginEuro);
// Console.WriteLine(mijnGeboorteDatum);
// Verschillende manieren van datum en tijd afbeelden
// DateTime eenDatumTijd = new DateTime (2026, 7, 1, 9, 30, 0); //Belgische landinstellingen
// Console.WriteLine(eenDatumTijd.ToString());
// Console.WriteLine(eenDatumTijd.ToShortDateString());
// Console.WriteLine(eenDatumTijd.ToLongDateString());
// Console.WriteLine(eenDatumTijd.ToShortTimeString());
// Console.WriteLine(eenDatumTijd.ToLongTimeString());
// Console.WriteLine(eenDatumTijd.ToString("yyyy-MM-dd"));
// Console.WriteLine("De datum is {0:dddd d MMMM yyyy}.",eenDatumTijd);
// Console.WriteLine($"De datum is {eenDatumTijd: dd-MM-yyyy}.");
// Datums vergelijken
// DateTime datum1 = new DateTime (2026 , 1, 1);
// DateTime datum2 = new DateTime (2026 , 1, 1);
// DateTime datum3 = new DateTime (2026 , 1, 2);
// Console.WriteLine(datum1 == datum2);
// Console.WriteLine(datum3 > datum2);
// Methods en properties
// DateTime factuurDatum = new DateTime(2026, 2, 1);
// Console.WriteLine(factuurDatum.AddDays(40));
// Console.WriteLine(factuurDatum.DayOfYear);
// DateTime vandaag = DateTime.Today;
// Console.WriteLine(vandaag.DayOfWeek);
// Console.WriteLine(vandaag.DayOfYear);
// Console.WriteLine(vandaag.AddDays(1));
// TimeSpan
// DateTime beginDatum = new DateTime(2026, 1, 1, 8, 0, 0);
// DateTime eindDatum = new DateTime(2026, 2, 1, 12, 30, 50);
// Console.WriteLine(beginDatum);
// Console.WriteLine(eindDatum);
// Console.WriteLine();
// TimeSpan interval = eindDatum - beginDatum;
// Console.WriteLine(interval.ToString());
// DateOnly en TimeOnly
// DateOnly beginZomer = new DateOnly(2026, 6, 21);
// Console.WriteLine(beginZomer);
// Console.WriteLine(beginZomer.ToLongDateString());
// Console.WriteLine(beginZomer.ToShortDateString());
// Console.WriteLine(beginZomer.ToString("dd-MM-yyyy"));
// Console.WriteLine(beginZomer.ToString("dd MM yyyy"));
// TimeOnly sluitingsuur = new TimeOnly(16, 0);
// Console.WriteLine(sluitingsuur);
// Console.WriteLine(sluitingsuur.ToLongTimeString());
// Console.WriteLine(sluitingsuur.ToShortTimeString());
// DateOnly factuurDatum = new DateOnly(2026, 2, 1);
// DateOnly betaalDatum = factuurDatum.AddDays(60);
// Console.WriteLine($"factuurDatum: {factuurDatum.ToShortDateString()}");
// Console.WriteLine($"betaalDatum: {betaalDatum.ToShortDateString()}");
// TimeOnly beginTijd = new TimeOnly (18,0,0);
// TimeOnly eindTijd = new TimeOnly (23,59,59);
// Console.WriteLine($"begin tijd: {beginTijd}");
// Console.WriteLine($"eind tijd: {beginTijd.AddHours(7.5).ToLongTimeString()}");
// // TimeOnly eindTijd = beginTijd.Add(new TimeSpan(7, 50, 0));
// Console.WriteLine($"eind tijd: {eindTijd.ToLongTimeString()}");
// TimeSpan duurtijd = eindTijd - beginTijd;
// Console.WriteLine($"duurtijd: {duurtijd.Hours} uur en {duurtijd.Minutes} minuten");
// TimeOnly nu = new TimeOnly(19, 30, 0);
// Console.WriteLine(nu.IsBetween(beginTijd, eindTijd));
// nu = new TimeOnly(17, 30, 0);
// Console.WriteLine(nu.IsBetween(beginTijd, eindTijd));
// FromDateTime()
// DateTime vandaag = DateTime.Now;
// DateOnly datumVandaag = DateOnly.FromDateTime(vandaag);
// TimeOnly nu = TimeOnly.FromDateTime(vandaag);
// Console.WriteLine(vandaag);
// Console.WriteLine(datumVandaag);
// Console.WriteLine(nu);
// Parse()
// Console.Write("Begintijd? ");
// TimeOnly begintijd = TimeOnly.Parse(Console.ReadLine());
// Console.WriteLine(begintijd);

/* Selecties */
// if structuur
// Console.Write("Geef je leeftijd: ");
// int leeftijd = int.Parse(Console.ReadLine());
// Console.Write("Je bent");
// met 1 opdracht
// if (leeftijd < 18) Console.Write(" niet");
// met meerdere opdrachten
// if (leeftijd < 18)
// {
//   Console.WriteLine("Je bent niet toegelaten.");
//   Console.WriteLine("Kom later terug.");
// }
// Console.WriteLine(" toegelaten.");
// Console.WriteLine("Dag");
// if ... else ... structuur
// if (leeftijd < 18)
// {
//   Console.WriteLine("Niet toegelaten.");
//   Console.WriteLine("Kom later terug.");
// }
// else
// {
//   Console.WriteLine("Kom binnen.");
//   Console.WriteLine("Geniet van de voorstelling!");
// }
// if ... else if ... structuur
// Console.Write("Geef een teken in: ");
// char c = (char)Console.Read();
// if (Char.IsUpper(c))
// {
//   Console.WriteLine("Het teken is een hoofdletter.");
// }
// else if (Char.IsLower(c))
// {
//   Console.WriteLine("Het teken is een kleine letter.");
// }
// else if (Char.IsDigit(c))
// {
//   Console.WriteLine("Het teken is een cijfer.");
// }
// else
// {
//   Console.WriteLine("Het teken is geen letter of cijfer.");
// }
// de ? operator -> verkorte if structuur
// Console.Write("Geef je leeftijd: ");
// byte leeftijd = byte.Parse(Console.ReadLine());
// Console.WriteLine(leeftijd < 18 ? "Niet toegelaten" : "Kom maar binnen");
// Switch
// Console.Write("Typ eerste getal: ");
// decimal getal1 = decimal.Parse(Console.ReadLine());
// Console.Write("Typ tweede getal: ");
// decimal getal2 = decimal.Parse(Console.ReadLine());
// Console.Write("Typ bewerking (+, - ,/,: of *): ");
// char bewerking = char.Parse(Console.ReadLine());
// switch (bewerking)
// {
// case '+':
//   Console.WriteLine(getal1 + getal2);
//   break;
// case '-':
//   Console.WriteLine(getal1 - getal2);
//   break;
// case '*':
//   Console.WriteLine(getal1 * getal2);
//   break;
// case '/' or ':':
//   if (getal2 == 0m) Console.WriteLine("Delen door nul is niet mogelijk.");
//   else Console.WriteLine(getal1 / getal2);
//   break;
// default:
//   Console.WriteLine("Verkeerde bewerking ingetypt.");
//   break;
// }
// switch expression
//Console.Write("Getal tussen 10 en 100? ");
//int getal = int.Parse(Console.ReadLine() ?? "");
//string bericht = getal switch
//{
//  < 0 => "negatief",
//  0 => "nul",
//  < 10 or > 100 => "een foutief getal",
//  >= 10 and <= 50 => "een getal tussen 10 en 50",
//  > 50 and <= 100 => "een getal tussen 50 en 100"
//};
//Console.WriteLine($"Het getal is {bericht}.");

/* Iteraties */
// While structuur
//decimal getal, totaal = 0m;
//Console.WriteLine("Type een reeks getallen, stop de reeks met 0: ");
//while ((getal = decimal.Parse(Console.ReadLine())) != 0m) totaal += getal;
//do totaal += getal = decimal.Parse(Console.ReadLine());
//while (getal != 0m);
//Console.WriteLine($"Totaal: {totaal}");
// For structuur
//decimal totaal = 0m;
//for (int teller = 1; teller < 11; teller++)
//{
//    Console.Write("Typ getal {0}:", teller);
//    totaal += decimal.Parse(Console.ReadLine());
//}
//Console.WriteLine($"Totaal: {totaal}");
//Console.Write("Type een woord: ");
//string woord = Console.ReadLine() ?? "";
//bool palindroom = true;
//int vanafBegin, vanafEinde;
//for (int vanafBegin = 0, vanafEinde = woord.Length - 1; vanafBegin < vanafEinde; vanafBegin++, vanafEinde--)
//    if (woord[vanafBegin] != woord[vanafEinde]) palindroom = false;
//    if (palindroom) Console.WriteLine("Dit woord is een palindroom");
//    else Console.WriteLine("Dit woord is geen palindroom");
//;
//for (vanafBegin = 0, vanafEinde = woord.Length - 1; vanafBegin < vanafEinde && woord[vanafBegin] == woord[vanafEinde]; vanafBegin++, vanafEinde--)
//    if (woord[vanafBegin] == woord[vanafEinde]) Console.WriteLine("Dit woord is een palindroom");
//    else Console.WriteLine("Dit woord is geen palindroom");
//;

/* Functions & Procedures */
// Procedure 
//void TekenLijn()
//{
//    for (int teller = 0; teller < 20; teller++)
//    {
//        Console.Write("-");
//    }
//    Console.WriteLine();
//}
//Console.WriteLine("Asterix");
//TekenLijn();
//Console.WriteLine("Obelix");
//TekenLijn();
//Console.WriteLine("Einde programma");
//TekenLijn();
// Function met terruggeef waarde
//float LeesPunten()
//{
//    Console.Write("Geef een cijfer tussen 0 en 10: ");
//    float punten = float.Parse(Console.ReadLine() ?? "");
//    while (punten < 0 || punten > 10)
//    {
//        Console.Write("Foutief cijfer! Geef een cijfer tussen 0 en 10: ");
//        punten = float.Parse(Console.ReadLine() ?? "");
//    }
//    return punten;
//}
//Console.WriteLine("Punten Wiskunde?");
//LeesPunten();
//Console.WriteLine("Punten Engels?");
//LeesPunten();
//Console.WriteLine("Punten Informatica?");
//LeesPunten();
// Function of procedure met 1 parameter
//void TekenLijn(int lengte)
//{
//    for (int teller = 0; teller < lengte; teller++)
//    {
//        Console.Write("-");
//    }
//    Console.WriteLine();
//}
//Console.WriteLine("Asterix");
//TekenLijn(7);
//Console.WriteLine("Obelix");
//TekenLijn(6);
//Console.WriteLine("Einde programma");
//TekenLijn(15);
// Function of procedure met meeredere parameters
//void TekenLijn(int lengte, char teken)
//{
//    for (int teller = 0; teller < lengte; teller++)
//    {
//        Console.Write(teken);
//    }
//    Console.WriteLine();
//}
//Console.WriteLine("Asterix");
//TekenLijn(7, '-');
//Console.WriteLine("Obelix");
//TekenLijn(6, '=');
//// named parameters
//Console.WriteLine("Idefix");
//TekenLijn(teken: '~', lengte: 6);
//Console.WriteLine("Einde programma");
//TekenLijn(15, '*');
// Optional parameters
//void TekenLijn(int lengte, char teken = '-')
//{
//    for (int teller = 0; teller < lengte; teller++)
//    {
//        Console.Write(teken);
//    }
//    Console.WriteLine();
//}
//Console.WriteLine("Asterix");
//TekenLijn(7);
//Console.WriteLine("Obelix");
//TekenLijn(6, '=');
//Console.WriteLine("Idefix");
//TekenLijn(lengte: 6);
//Console.WriteLine("Einde programma");
//TekenLijn(15, '*');
// Function met een parameter
// double CmToInch(double cm) { return cm / 2.54; };
// double InchToCm(double inch) { return inch * 2.54; };
//Console.Write("Afstand in cm: ");
//double cm = double.Parse(Console.ReadLine() ?? "");
//Console.WriteLine($"{cm} cm = {CmToInch(cm)} inches");
//TekenLijn(20);
//Console.Write("Afstand in inches: ");
//double inch = double.Parse(Console.ReadLine() ?? "");
//Console.WriteLine($"{inch} inch = {InchToCm(inch)} cm");
// Sleutelwoord ref
//void Verwissel(ref int getal1, ref int getal2) {
//    int tussen = getal1;
//    getal1 = getal2;
//    getal2 = tussen;
//};
//int eerste = 10, tweede = 20;
//Verwissel(ref eerste, ref tweede);
//Console.WriteLine(eerste);
//Console.WriteLine(tweede);
// Sleutelwoord out
//void VerwisselNaarAndereVars(int getal1, int getal2, out int verwisseld1, out int verwisseld2)
//{
//    verwisseld1 = getal2;
//    verwisseld2 = getal1;
//};
//int eerste = 10, tweede = 20;
//VerwisselNaarAndereVars(eerste, tweede, out int resultaat1, out int resultaat2);
//Console.WriteLine(resultaat1);
//Console.WriteLine(resultaat2);
// Toespassing TryParse
// Console.Write("Afstand in cm: ");
// if (double.TryParse(Console.ReadLine(), out double cm))
// {
//   Console.WriteLine($"{CmToInch(cm)} inches");
// }
// else
// {
//   Console.WriteLine("Geen correct getal");
// }
// TimeOnly.Add()
// TimeOnly begintijd = new TimeOnly(8, 30, 0);
// Console.WriteLine($"begintijd: {begintijd}");
// TimeOnly eindtijd = begintijd.Add(new TimeSpan(50, 30, 0), out int aantalDagen);
// Console.WriteLine($"eindtijd: {eindtijd} en {aantalDagen} dag(en) later");
// Declaratie plaatsen
//Console.Write("Afstand in cm: ");
//double cm = double.Parse(Console.ReadLine() ?? "");
//Console.WriteLine($"{cm} cm = {CmToInch(cm)} inches");
//TekenLijn(20);

/* Arrays */
//const int AantalMaanden = 12;
//double[] temperaturen = new double[AantalMaanden];
//for (int maand = 1; maand <= AantalMaanden; maand++)
//{
//    Console.Write("Geef de temperatuur voor {0}: ", maand);
//    temperaturen[maand - 1] = double.Parse(Console.ReadLine()!);
//}
//Console.WriteLine("Je typte volgende temperaturen:");
//for (int maand = 1; maand <= AantalMaanden; maand++)
//{
//    Console.WriteLine($"Maand {maand}: {temperaturen[maand-1]}");
//}
//Console.WriteLine(temperaturen.Length);
// met accolades {}
//int[] dagenPerMaand = { 31,28,31,30,31,30,31,31,30,31,30,31 };
//for (int maand = 0; maand < dagenPerMaand.Length; maand++)
//{
//    Console.WriteLine(dagenPerMaand[maand]);
//}
// met een collection expression
//int[] dagenPerMaand = [ 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 ];
//for (int maand = 0; maand < dagenPerMaand.Length; maand++)
//{
//    Console.WriteLine(dagenPerMaand[maand]);
//}
// foreach iteratie met arrays
//string[] striphelden = ["Asterix", "Obelix", "Idefix"];
//foreach (string held in striphelden)
//{
//    Console.WriteLine(held);
//}
// ook met de sleutelwoord var
//var maanden = new string[] { "Jan", "Feb", "Maa", "Apr", "Mei", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
//foreach (var maand in maanden)
//{
//    Console.WriteLine(maand.ToUpper());
//}
//Console.Write("Aantal bankrekeningen: ");
//int aantalrekenignen = int.Parse(Console.ReadLine()!);
//ulong[] rekeningNrs = new ulong[aantalrekenignen];
//for (int teller = 1; teller <= aantalrekenignen; teller++)
//{
//    Console.Write("Nummer van {0} rekening: ", teller);
//    rekeningNrs[teller - 1] = ulong.Parse(Console.ReadLine()!);
//}
//Console.WriteLine("Dit zijn de nummers van je rekeningen: ");
//foreach (ulong rekeningNr in rekeningNrs)
//{
//    Console.WriteLine(rekeningNr);
//}
// index en range cyntaxes
//string[] striphelden = { "Asterix", "Obelix", "Idefix", "Panoramix" };
//string[] deelArray;
//deelArray = striphelden[1..3]; // Obelix Idefix
//Console.WriteLine(string.Join(' ', deelArray));
//deelArray = striphelden[0..]; // alle elementen
//Console.WriteLine(string.Join(' ', deelArray));
//deelArray = striphelden[..2]; // Asterix Obelix
//Console.WriteLine(string.Join(' ', deelArray));
//deelArray = striphelden[2..]; // Idefix Panoramix
//Console.WriteLine(string.Join(' ', deelArray));
//deelArray = striphelden[..^1]; // Asterix Obelix Idefix
//Console.WriteLine(string.Join(' ', deelArray));
//Range range = new Range(1,3);
//deelArray = striphelden[range]; // Obelix en Idefix
//Console.WriteLine(string.Join(' ', deelArray));
// 2-dimensionele arrays (array in array dus)
// De class Array met de methods
//string[] namen = ["Asterix", "Obelix", "Idefix"];
//Console.WriteLine("Beginsituatie:");
//foreach (string naam in namen) Console.WriteLine(naam);
//Array.Sort(namen);
//Console.WriteLine("Na Sort:");
//foreach (string naam in namen) Console.WriteLine(naam);
//Array.Reverse(namen);
//Console.WriteLine("Na Reverse:");
//foreach (string naam in namen) Console.WriteLine(naam);
//string[] kopie = new string[namen.Length];
//Array.Copy(namen,kopie,namen.Length);
//Console.WriteLine("Kopie:");
//foreach (string naam in kopie) Console.WriteLine(naam);
//Console.WriteLine("Eerste Idefix op positie: " + Array.IndexOf(namen, "Idefix"));

/* Enum */
// De enum is gedefinieerd in de file: Seizoen.cs
//Seizoen plukSeizoen = Seizoen.Herfst;
//Console.WriteLine(plukSeizoen);
//Console.WriteLine((int)plukSeizoen);

/* Classes en Objecten */
//using CSharpPFCursus;
// Werknemer ik = new()
// {
//   Naam = "Asterix",
//   Geslacht = Geslacht.Man,
//   InDienst = new DateTime(2021, 3, 10)
// };
// Werknemer jij = new()
// {
//   Naam = "Obelix",
//   Geslacht = Geslacht.Man,
//   InDienst = new DateTime(2026, 1, 2)
// };
// LijnenTrekker lijnenTrekker = new LijnenTrekker();
// Console.WriteLine(ik.GetInfo());
// lijnenTrekker.TekenLijn(30, '=');
// Console.WriteLine(jij.GetInfo());
// lijnenTrekker.TekenLijn(79, '~');
// lijnenTrekker.TekenLijn();
// lijnenTrekker.TekenLijn(30);
// Console.WriteLine(ik.Naam);
// Console.WriteLine(ik.Geslacht);
// Console.WriteLine(ik.InDienst);
// Werknemer mezelf = ik;
// Console.WriteLine(mezelf.Naam);
// Console.WriteLine(ik == mezelf);
// ik = null!;
// Console.WriteLine(ik == mezelf);
// Console.WriteLine(mezelf.Naam);
// Console.WriteLine(ik.VerjaarAncien);
// Console.Write("Afstand in cm: ");
// double cm = double.Parse(Console.ReadLine()!);
// Console.WriteLine($"{lijnenTrekker.CmNaarInch(cm)} inches");
// lijnenTrekker.TekenLijn();
// Console.Write("Afstand in inch: ");
// double inch = double.Parse(Console.ReadLine()!);
// Console.WriteLine($"{lijnenTrekker.InchNaarCm(inch)} cm");
// lijnenTrekker.TekenLijn();
//int eerste = 10, tweede = 20;
//Verwisselaar verwisselaar = new Verwisselaar();
// ook hier ref gebruiken
//verwisselaar.Verwissel(ref eerste, ref tweede);
//Console.WriteLine(eerste);
//Console.WriteLine(tweede);

/* Constructors */
// using CSharpPFCursus;
//Werknemer ik = new();
//Console.WriteLine(ik.GetInfo());
//Console.WriteLine(ik.Naam.ToUpper());
//Werknemer ik = new("Asterix", new DateTime(2026,2,1), Geslacht.Man);
//Console.WriteLine(ik.GetInfo());
//Werknemer jij = new();
//Werknemer jij = new("Obelix", new DateTime(2026,2,1));
//Console.WriteLine(jij.GetInfo());
//Werknemer2 ik = new("Martine", DateTime.Today, Geslacht.Vrouw);
//Console.WriteLine(ik.GetInfo());
//Werknemer2 jij = new();
//Console.WriteLine(jij.GetInfo());
//Werknemer2 mezelf = new("", new DateTime(2025,3,1), Geslacht.Man);
//Console.WriteLine(mezelf.GetInfo());
//mezelf.Naam = "Asterix";
//Console.WriteLine(mezelf.GetInfo());
//mezelf.Naam = string.Empty;
//Console.WriteLine(mezelf.GetInfo());
// Werknemer ik = new()
// {
//     Naam = "Asterix",
//     InDienst = new DateTime(2026, 2, 1),
//     Geslacht = Geslacht.Man
// };
// Werknemer ik = new("Asterix", new DateTime(2026,3,1), Geslacht.Man);
// Console.WriteLine(ik.GetInfo());
// ik.Naam = "Obelix";
// Console.WriteLine(ik.GetInfo());

/* Static classes */
//using CSharpPFCursus;
// Werknemer ik = new Werknemer("Martine", DateTime.Today, Geslacht.Vrouw);
// Werknemer.Personeelsfeest = new DateOnly(2026, 12, 21);
// Console.WriteLine(ik.GetInfo());
// Console.WriteLine(Werknemer.Personeelsfeest);
// ik.Personeelsfeest = new DateOnly.FromDateTime(DateTime.Today);
//Console.WriteLine(Rekenaar.Kwadraat(3));

/* Inheritance */
//using CSharpPFCursus;
//Arbeider ik = new Arbeider("Asterix", new DateTime(2026,3,1), Geslacht.Man, 24.79m, 3);
//Werknemer ik = new Arbeider("Asterix", new DateTime(2026,3,1), Geslacht.Man, 24.79m, 3);
//Console.WriteLine(ik.GetInfo());
//Bediende jij = new Bediende("Obelix", new DateTime(2026, 3, 1), Geslacht.Man, 3500.56m);
//Werknemer jij = new Bediende("Obelix", new DateTime(2026, 3, 1), Geslacht.Man, 3500.56m);
//Bediende? hij;
//hij = (Bediende) ik;
//Console.WriteLine(hij.GetInfo());
//hij = (Bediende) jij;
//Console.WriteLine(hij.GetInfo());
//hij = ik as Bediende;
//if (hij != null) Console.WriteLine(hij.GetInfo());
//hij = jij as Bediende;
//if (hij != null) Console.WriteLine(hij.GetInfo());
//Console.WriteLine(jij.GetInfo());
//Manager hij = new Manager("Idefix", new DateTime(2026,3,1), Geslacht.X, 4000m, 10000m);
//Manager zij = new Manager("Bellefleur", new DateTime(2026, 3, 1), Geslacht.Vrouw, 4000m, 10000m);
//Console.WriteLine(hij.GetInfo());
// controlerebn van welke class het object komt, gebeurd met de het sleutelwoord is
//Console.WriteLine(hij is Manager);
//Console.WriteLine(hij is Bediende);
//Console.WriteLine(hij is Werknemer);
//Console.WriteLine(hij is Arbeider);
//Console.WriteLine(hij is string);
//hij = null!;
//Console.WriteLine(hij is Manager);
//Console.WriteLine(hij.ToString());
//Console.WriteLine(hij.Equals(zij));
//Console.WriteLine(zij.Equals(zij));

/* Abstract classes and sealed classes, abstract methods */
//using CSharpPFCursus;
//Werknemer ik = new Werknemer(); // dit kan nu niet meer vanwege het sleutelwoord abstract
//Manager jij = new Manager("Asterix", DateTime.Today, Geslacht.Man, 4000m, 8000m);
//Arbeider asterix = new("Asterix", DateTime.Today, Geslacht.Man, 23.55m, 3);
//Bediende obelix = new("Obelix", DateTime.Today, Geslacht.Man, 2386.99m);
//Manager idefix = new("Idefix", DateTime.Today, Geslacht.Man, 2800m, 9000m);
//Console.WriteLine(asterix.Premie);
//Console.WriteLine(obelix.Premie);
//Console.WriteLine(idefix.Premie);

/* Inheritance polymorphism */
//using CSharpPFCursus;
//Werknemer[] wij = new Werknemer[3];
//wij[0] = new Arbeider("Asterix", DateTime.Today, Geslacht.Man, 22.45m, 2);
//wij[1] = new Bediende("Obelix", DateTime.Today, Geslacht.X, 2400m);
//wij[2] = new Manager("Bellefleur", DateTime.Today, Geslacht.Vrouw, 2700m, 8000m);
//foreach (Werknemer nemer in wij) Console.WriteLine(nemer.GetInfo());

/* Extension Members */
// using CSharpPFCursus;
// string land = "belgie";
// Console.WriteLine(land.ToUpperFirst());
// Console.WriteLine(land.Right(2));
// string tekst = "Groeten van Martine";
// Console.WriteLine(tekst.WordCount);
// Console.WriteLine(string.GenerateCode(8));

/* Aggregation */
// using CSharpPFCursus;
// Doe dit met een contructor met parameters in de class Afdeling
// Afdeling afdelingStrijd = new("Strijd", 0);
// Afdeling afdelingFeest = new("Feest", 1);
// Doe dit als er geen contructor is, maar wel als de properties required zijn
// Afdeling afdelingStrijd = new Afdeling
// {
//   Naam = "Strijd",
//   Verdieping = 0
// };
// Afdeling afdelingFeest = new Afdeling
// {
//   Naam = "Feest",
//   Verdieping = 1,
// };
// Werknemer[] wij = new Werknemer[3];
// wij[0] = new Arbeider("Asterix", new DateTime(2026, 1, 1), Geslacht.Man, 23.67m, 3);
// wij[0].Afdeling = afdelingStrijd;
// wij[1] = new Bediende("Obelix", new DateTime(2025, 12, 1), Geslacht.Man, 2500m);
// wij[1].Afdeling = afdelingStrijd;
// wij[2] = new Manager("Bellefleur", DateTime.Today, Geslacht.Vrouw, 2600m, 9000m);
// wij[2].Afdeling = afdelingFeest;
// foreach (Werknemer nemer in wij)
// {
//   Console.WriteLine(nemer.GetInfo());
//   Console.WriteLine();
// }
// Ik heb de parameters in ed Arbeider contructor ook optioneel gemaakt, en kan ik dit nu dus zo uitvoeren
// Werknemer ik = new Arbeider();
// Console.WriteLine(ik.GetInfo());

/* Nested Classes */
// using CSharpPFCursus;
// Arbeider ik = new Arbeider("Martine", DateTime.Today, Geslacht.Vrouw, 33.56m, 3);
// ik.Regime = new Werknemer.WerkRegime
// {
//   Type = Werknemer.WerkRegime.RegimeType.Voltijds
// };
// Console.WriteLine(ik.Regime);
// Console.WriteLine(ik.Regime.AantalVakantiedagen);

/* Interfaces */
// using CSharpPFCursus;
// IKost[] kosten = new IKost[4];
// kosten[0] = new Arbeider("Asterix", new DateTime(2026, 3, 12), Geslacht.Man, 22.45m, 2);
// kosten[1] = new Bediende("Obelix", new DateTime(2026, 2, 1), Geslacht.Man, 2500m);
// kosten[2] = new Manager("Bellefleur", new DateTime(2026, 1, 1), Geslacht.Vrouw, 2800m, 8000m);
// kosten[3] = new Fotokopiemachine("234", 300, 0.025m);
// decimal totaleKost = 0m;
// foreach (IKost kost in kosten)
// {
//   Console.WriteLine(kost.Menselijk);
//   Console.WriteLine(kost.BerekenKostprijs());
//   totaleKost += kost.BerekenKostprijs();
// }
// Console.WriteLine(totaleKost);
// // controleren of een object een class is die een interface heeft geimplementeerd.
// foreach (Object item in kosten) Console.WriteLine(item is IKost);

/* Pattern Matching */
//using Firma.Personeel;
// static void ToonGegevens(Object? obj)
// {
// de klassieke schrijfwijze zonder pattern matching
// if (obj is Werknemer)
// {
//   Werknemer w = (Werknemer)obj;
//   Console.WriteLine($"Werknemer {w.Naam} kost {w.BerekenKostprijs()} euro");
// }
// else if (obj is Fotokopiemachine)
// {
//   Fotokopiemachine f = (Fotokopiemachine)obj;
//   Console.WriteLine($"Fotokopiemachine {f.SerieNr} kopieerde {f.AantalGekopieerdeBlz} en kost {f.BerekenKostprijs()} euro");
// }
// else
// {
//   Console.WriteLine("Onbekend Type");
// }
// schrijfwijze met type pattern matching
// if (obj is Werknemer w)
// {
//   Console.WriteLine($"Werknemer {w.Naam} kost {w.BerekenKostprijs()} euro");
// }
// else if (obj is Fotokopiemachine f)
// {
//   Console.WriteLine($"Fotokopiemachine {f.SerieNr} kopieerde {f.AantalGekopieerdeBlz} en kost {f.BerekenKostprijs()} euro");
// }
// else
// {
//   Console.WriteLine("Onbekend Type");
// }
// Switch pattern matching
//   switch (obj)
//   {
//     case Werknemer w:
//       Console.WriteLine($"Werknemer {w.Naam} kost {w.BerekenKostprijs()} euro");
//       break;
//     case Fotokopiemachine f:
//       Console.WriteLine($"Fotokopiemachine {f.SerieNr} kopieerde {f.AantalGekopieerdeBlz} en kost {f.BerekenKostprijs()} euro");
//       break;
//     case null:
//       Console.WriteLine("Parameter = null");
//       break;
//     default:
//       Console.WriteLine("Onbekend Type");
//       break;
//   }
// }
//Object?[] lijst = new Object?[5];
//lijst[0] = new Arbeider("Asterix", new DateTime(2026, 3, 12), Geslacht.Man, 22.45m, 2);
//lijst[1] = new Bediende("Obelix", new DateTime(2026, 2, 1), Geslacht.Man, 2500m);
//lijst[2] = null;
//lijst[3] = "C# 10";
//lijst[4] = new Bediende("Bellefleur", new DateTime(2026, 2, 1), Geslacht.Vrouw, 2500m);
//foreach (var item in lijst)
//{
//  // ToonGegevens(item);
//  switch (item)
//  {
//    case Arbeider a when a.Geslacht == Geslacht.Vrouw:
//      Console.WriteLine($"{a.Naam} is een vrouwelijke arbeider met een uurloon van {a.Uurloon} euro");
//      break;
//    case Arbeider a when a.Geslacht == Geslacht.Man:
//      Console.WriteLine($"{a.Naam} is een mannelijke arbeider met een uurloon van {a.Uurloon} euro");
//      break;
//    case Bediende b when b.Geslacht == Geslacht.Vrouw:
//      Console.WriteLine($"{b.Naam} is een vrouwelijke bediende met een wedde van {b.Wedde} euro");
//      break;
//    case Bediende b when b.Geslacht == Geslacht.Man:
//      Console.WriteLine($"{b.Naam} is een mannelijke bediende met een wedde van {b.Wedde} euro");
//      break;
//    case Werknemer w when w.Geslacht == Geslacht.Man:
//      Console.WriteLine($"{w.Naam} is een mannelijke werknemer");
//      break;
//    case null:
//      Console.WriteLine("NULL");
//      break;
//    default:
//      Console.WriteLine($"{item} is geen werknemer");
//      break;
//  }
//}

/* Exceptions */
//decimal getal1, getal2;
//Console.Write("eerste getal: ");
//getal1 = decimal.Parse(Console.ReadLine()!);
//Console.Write("tweede getal: ");
//getal2 = decimal.Parse(Console.ReadLine()!);
// met if controleren zodat exceptions vermeden kunnen worden
//Console.WriteLine("deling: " + getal1 / getal2);
//if (getal2 != 0m) Console.WriteLine("deling: " + getal1 / getal2);
//else Console.WriteLine("delen door null niet toegelaten");
// maar met een if kun je niet alle fouten voorkomen - hiervoor kun je dan best een trycatch gebruiken
//try
//{
//  Console.Write("eerste getal: ");
//  getal1 = decimal.Parse(Console.ReadLine()!);
//  Console.Write("tweede getal: ");
//  getal2 = decimal.Parse(Console.ReadLine()!);
//  if (getal2 != 0m)
//    Console.WriteLine("deling: " + getal1 / getal2);
//  else
//    Console.WriteLine("delen door null niet toegelaten");
//}
//catch
//{
//  Console.WriteLine("Je typt geen getal");
//}
// je kunt ook meerdere catch opdrachten gebruiken
//try
//{
//  Console.Write("eerste getal: ");
//  getal1 = decimal.Parse(Console.ReadLine()!);
//  Console.Write("tweede getal: ");
//  getal2 = decimal.Parse(Console.ReadLine()!);
//  Console.WriteLine("deling: " + getal1 / getal2);
//  // we gebruiken nu even geen if statement - in de praktijk moet je dit wel altijd doen
//  //if (getal2 != 0m)
//  //  Console.WriteLine("deling: " + getal1 / getal2);
//  //else
//  //  Console.WriteLine("delen door null niet toegelaten");
//}
// als je de technische informatie wilt weten - dan zet je achter de exception class in de catch een variabele
//catch (FormatException ex)
//{
//  Console.WriteLine("Je type geen getal");
//  Console.WriteLine(ex.Message);
//  Console.WriteLine(ex.StackTrace);
//}
//catch (FormatException)
//{
//  Console.WriteLine("Je typt geen getal");
//}
//catch (DivideByZeroException)
//{
//  Console.WriteLine("Delen door nul is niet toegestaan");
//}
//catch (Exception)
//{
//  Console.WriteLine("Een fout heeft zich voorgedaan");
//}
// de volgorde van de catch is belangrijk
// wil je weten bij welke variabele de fout is opgetreden dan kun je meerdere try gebruiken
//try
//{
//  Console.Write("eerste getal: ");
//  getal1 = decimal.Parse(Console.ReadLine()!);
//  try
//  {
//    Console.Write("tweede getal: ");
//    getal2 = decimal.Parse(Console.ReadLine()!);
//    if (getal2 != 0m)
//      Console.WriteLine("deling: " + getal1 / getal2);
//    else
//      Console.WriteLine("delen door null niet toegelaten");
//  }
//  catch (FormatException)
//  {
//    Console.WriteLine("Je typte geen getal bij getal2");
//  }
//}
//catch (FormatException)
//{
//  Console.WriteLine("Je typte geen getal bij getal1");
//}
// een error gooien met throw - je kunt een throw new Exception() gooi bij de validatie in de properties van een class
//using Firma.Materiaal;
//try
//{
//  Fotokopiemachine machine = new("123678", 100, -5.4m);
//  Console.WriteLine("Machine goed ingevuld");
//}
//catch (Exception ex)
//{
//  Console.WriteLine("Fout: " + ex.Message);
//}
//Console.WriteLine("Einde programma");
// Je kunt ook een eigen Exception class maken - zie de Fotokopiemachien class hiervoor
//try
//{
//  Fotokopiemachine machine = new("123678", 100, -5.4m);
//  Console.WriteLine("Machine goed ingevuld");
//}
//catch (Fotokopiemachine.KostPerBlzException ex)
//{
//  Console.WriteLine($"Fout: {ex.Message}: {ex.VerkeerdeKost}");
//}
//catch (Fotokopiemachine.AantalGekopieerdeBlzException ex)
//{
//  Console.WriteLine($"Fout: {ex.Message}: {ex.VerkeerdAantalBlz}");
//}
//Console.WriteLine("Einde programma");

/* garbage collector */
//StreamReader lezer = new StreamReader(@"C:\Users\marti\source\repos\DOTNET\provincies.txt");
//string regel = lezer.ReadLine();
//lezer.Close();
//using CSharpPFCursus;
//Console.Write("Provincie: ");
//string provincie = Console.ReadLine()!;
//try
//{
//  ProvincieInfo info = new ProvincieInfo();
//  Console.WriteLine(info.ProvincieGrootte(provincie));
//}
//catch (Exception ex)
//{
//  Console.WriteLine(ex.Message);
//}

/* Collections & Generics */
//using CSharpPFCursus;
//using Firma.Personeel;
//using System.Collections;
//Arbeider asterix = new Arbeider("Asterix", new DateTime(2026,2,1), Geslacht.Man, 24.79m, 3);
//Bediende obelix = new Bediende("Obelix", new DateTime(2026,1,1), Geslacht.Man, 2400.79m);
//Manager bellefleur = new Manager("Bellefleur", new DateTime(2026,3,1), Geslacht.Vrouw, 2400.79m, 7000m);
//ArrayList personeel = new ArrayList();
//List<Werknemer> personeel = new List<Werknemer>();
//personeel.Add(asterix);
//personeel.Add(obelix);
//personeel.Insert(1, bellefleur);
//Console.WriteLine($"{(personeel[0] as Werknemer)?.Naam} is de 1ste van {personeel.Count} personeelsleden.");
//Console.WriteLine($"{personeel[0].Naam} is de 1ste van {personeel.Count} personeelsleden.");
//foreach (Werknemer personeelslid in personeel) Console.WriteLine(personeelslid.Naam);
//Afdeling eenAfdeling = new Afdeling { Naam = "Verzending", Verdieping = 0 };
//personeel.Add(eenAfdeling);
//foreach (Werknemer personeelslid in personeel) Console.WriteLine(personeelslid.Naam);
// beginwaarden meegeven met een collection initializer
//var getallen = new ArrayList { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
//var maanden = new List<string>{ "Januari", "Februari", "Maart", "April", "Mei", "Juni", "Juli", "Augustus", "September", "Oktober", "November", "December" };
//var personeel = new List<Werknemer>
//{
//    new Arbeider("Asterix", new DateTime(2026,2,1), Geslacht.Man, 24.79m, 3),
//    new Bediende("Obelix", new DateTime(2026,1,1), Geslacht.Man, 2400.79m),
//    new Manager("Bellefleur", new DateTime(2026,3,1), Geslacht.Vrouw, 2400.79m, 7000m)
//};
// beginwaarden meegeven met een collection expression
//ArrayList getallen2 = [ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 ];
//List<string> maanden2 = [ "Januari", "Februari", "Maart", "April", "Mei", "Juni", "Juli", "Augustus", "September", "Oktober", "November", "December" ];
//List<Werknemer> personeel2 =
//[
//    new Arbeider("Asterix", new DateTime(2026,2,1), Geslacht.Man, 24.79m, 3),
//    new Bediende("Obelix", new DateTime(2026,1,1), Geslacht.Man, 2400.79m),
//    new Manager("Bellefleur", new DateTime(2026,3,1), Geslacht.Vrouw, 2400.79m, 7000m)
//];
// een dictionary gebruiken - dit gaat altijd met een key/value pair
//Dictionary<int, string> opleidingen = new Dictionary<int, string>() { { 1, "Word" }, { 2, "Excel" }, { 3, "Access" } };
//Dictionary<string, string> extensies = new() { { "txt", "Notepad" }, { "docx", "Word" }, { "xlsx", "Excel" } };
// het kan ook geschreven worden zoals hieronder -- misschien voor mij wel wat duidelijker
//Dictionary<int, string> opleidingen2 = new Dictionary<int, string>() { [1] = "Word", [2] = "Excel", [3] = "Access" };
//Dictionary<string, string> extensies2 = new() { ["txt"] = "Notepad", ["docx"] = "Word", ["xlsx"] = "Excel" };
// toevoegen van een element
//opleidingen2.Add(4, "Powerpoint");
//opleidingen.Add(4, "Outlook"); // zal een fout geven!
//opleidingen2[5] = "Outlook"; // dit is voor mij leesbaarder
// een element opvragen
//Console.WriteLine(opleidingen2[2]);
//Console.WriteLine(extensies2["docx"]);
//Console.WriteLine(extensies2["xxx"]); // gaat een fout geven!
// met de TryGetValue() method
//if(opleidingen.TryGetValue(2, out string? opleiding))
//{
//    Console.WriteLine($"opleiding {opleiding} gevonden");
//    // of in het kort!
//    Console.WriteLine($"Opleiding {(opleidingen.TryGetValue(8, out string? opleiding) ? opleiding : "niet")} gevonden");
//}
//else
//{
//    Console .WriteLine( "opleiding niet gevonden" );
//}
//foreach (KeyValuePair<int, string> opleiding in opleidingen2)
//{
//    Console.WriteLine($"Key = {opleiding.Key}, Value = {opleiding.Value}");
//}
// of met var
//foreach (var opleiding in opleidingen2)
//{
//    Console.WriteLine($"Key = {opleiding.Key}, Value = {opleiding.Value}");
//}
// of met enkel de keys
//foreach (int key in opleidingen2.Keys)
//{
//    Console.WriteLine(key);
//}
// of met enkel de values
//foreach (string value in opleidingen2.Values)
//{
//    Console.WriteLine(value);
//}

/* Delegates & events */
//using Firma.Personeel;
//using Firma.Materiaal;
//Werknemer[] wij = 
//[
//    new Arbeider("Asterix", new DateTime(2026, 1, 1), Geslacht.Man, 24.79m, 3),
//    new Bediende("Obelix", new DateTime(1995, 2, 1), Geslacht.Man, 2400.79m),
//    new Manager("Idefix", new DateTime(1996, 3, 1), Geslacht.Man, 2400.79m, 7000m)
//];
//WerknemersLijst lijst;
//lijst = Werknemer.UitgebreideWerknemersLijst;
//Console.WriteLine(lijst(wij));
//Console.WriteLine();
//lijst = Werknemer.KorteWerknemersLijst;
//Console.WriteLine(lijst(wij));
// een event triggeren
//Bediende obelix = new Bediende("Obelix", new DateTime(1995, 2, 1), Geslacht.Man, 2400.79m);
//Manager idefix = new Manager("Idefix", new DateTime(1996, 3, 1), Geslacht.Man, 2400.79m, 7000m);
//Fotokopiemachine machine1 = new Fotokopiemachine("12345", 0, 0.30m);
//Fotokopiemachine machine2 = new Fotokopiemachine("67890", 0, 0.50m); // laten zien dat 1 object op meerdere events kan reageren
//machine1.OnderhoudNodig += obelix.DoeOnderhoud;
//machine1.OnderhoudNodig += idefix.OnderhoudNoteren;
//machine2.OnderhoudNodig += obelix.DoeOnderhoud;
//machine2.OnderhoudNodig += idefix.OnderhoudNoteren;
//machine1.Fotokopieer(45);
//machine2.Fotokopieer(27);
// met een anonymous method - dit kan ook, maar wordt niet altijd aangeraden to gebruiken
//machine1.OnderhoudNodig += delegate (Fotokopiemachine apparaat)
//{
//    Console.WriteLine($"Onderhoud is aangevraagd voor machine {apparaat.SerieNr}");
//};
//machine1.Fotokopieer(50);

/* lambda expressies */
//using CSharpPFCursus;
//Kwadraat kwadraat = getal => getal * getal;
//Console.WriteLine(kwadraat(5));
//Console.WriteLine(kwadraat(10));
//FunctieMet2Parameters som = (getal1, getal2) => getal1 + getal2;
//FunctieMet1Parameter omgekeerdeString = (tekst) => new string(tekst.Reverse().ToArray());
//FunctieZonderParameters willekeurigGetal = () => new Random().Next(10);
//Console.WriteLine(som(3,7));
//Console.WriteLine(som(10,6));
//Console.WriteLine(omgekeerdeString("VDAB"));
//Console.WriteLine(willekeurigGetal());
//KwadraatOtp kwadraatOtp = getal => getal * getal;
//Console.WriteLine(kwadraatOtp(5));
//Console.WriteLine(kwadraatOtp());
//int[] getallen = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
//Filter filterEvenGetallen = getal => getal % 2 == 0;
//Console.WriteLine("Even getallen:");
//ToonGetallen(getallen,filterEvenGetallen);
//Console.WriteLine("Oneven getallen:");
//ToonGetallen(getallen, getal => getal % 2 == 1);
//Console.WriteLine("Getallen deelbaar door 5:");
//ToonGetallen(getallen, getal => getal % 5 == 0);
//static void ToonGetallen(int[] getallen, Filter filter)
//{
//    foreach (var getal in getallen)
//    {
//        if (filter(getal)) Console.WriteLine(getal);
//    }
//}
// met Action
//Action<int> kwadraat = getal => Console.WriteLine(getal * getal);
//kwadraat(10);
//Action<string, int> tekstDeel = (tekst, vanaf) => Console.WriteLine(tekst.Substring(vanaf));
//Action<string, int> tekstDeel = (tekst, vanaf) => Console.WriteLine(tekst[vanaf..]); // met range operator
//tekstDeel("VDAB", 2);
// met Func
//Func<int, int, int> som = (getal1, getal2) => getal1 + getal2;
//Console.WriteLine(som(10,5));
//Func<string, int, string> tekstDeel = (tekst, vanaf) => tekst.Substring(vanaf);
//Func<string, int, string> tekstDeel = (tekst, vanaf) => tekst[vanaf..]; // met range operator
//Console.WriteLine(tekstDeel("VDAB", 1));

/* LINQ */
//using CSharpPFCursus;
//List<string> namen = ["Asterix", "Obelix", "Idefix", "Ambiorix"];
//var namenDieMetABeginnen = namen.Where(naam => naam.StartsWith('A')).ToList();
//namen.Remove("Ambiorix");
//foreach (var naam in namenDieMetABeginnen)
//{
//  Console.WriteLine(naam);
//}
// Extension methocs
// filteren met Where()
//var getallen = new[] { 0, 2, 1, 4, 3, 5, 7, 6, 8, 9 };
//Console.WriteLine("Getallen groter dan 3:");
//var getallenGroterDan3 = getallen.Where(getal => getal > 3);
//foreach (var getal in getallenGroterDan3) Console.WriteLine(getal);
//List<string> namen = ["Asterix", "Obelix", "Idefix", "Ambiorix"];
//Console.WriteLine("Geef de beginletter(s) in: ");
//var beginVanNaam = Console.ReadLine()!;
//var gevondenNamen = namen.Where(naam => naam.StartsWith(beginVanNaam));
//foreach (var naam in gevondenNamen) Console.WriteLine(naam);
// sorteren met OrderBy()
// op waarde van het element
//var getallen = new[] { 0, 2, 1, 4, 3, 5, 7, 6, 8, 9 };
//Console.WriteLine("Gesorteerde lijst:");
//var gesorteerdeGetallen = getallen.OrderBy(getal => getal);
//foreach (var getal in gesorteerdeGetallen) Console.WriteLine(getal);
// op een property
//var landen = new[] { new { Naam = "Frankrijk", Oppervlakte = 643427 }, new { Naam = "Belgie", Oppervlakte = 30688 }, new { Naam = "Nederland", Oppervlakte = 41528 } };
//Console.WriteLine("Landen gesorteerd op oppervlakte:");
//var landenGesorteerdOpOppervlakte = landen.OrderBy(land => land.Oppervlakte);
//foreach (var land in landenGesorteerdOpOppervlakte) Console.WriteLine($"{land.Naam} {land.Oppervlakte}");
//Console.WriteLine();
//Console.WriteLine("Landen gesorteerd op naam (descending):");
//var landenGesorteerdOpNaamDesc = landen.OrderByDescending(land => land.Naam);
//foreach (var land in landenGesorteerdOpNaamDesc) Console.WriteLine($"{land.Naam} {land.Oppervlakte}");
// sorteren op meerdere waarden
//var namen = new List<String> {"Asterix", "Obelix", "Idefix", "Ambiorix"};
//var gesorteerdeNamen = namen.OrderBy(naam => naam.Length).ThenBy(naam => naam);
//foreach (var naam in gesorteerdeNamen) Console.WriteLine(naam);
// extension method Select()
//List<string> namen = ["Asterix", "Obelix", "Idefix", "Ambiorix"];
//var namenInHoofdletters = namen.Select(naam => naam.ToUpper());
//foreach (var naam in namenInHoofdletters) Console.WriteLine(naam);
//int[] getallen = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
//var kwadraten = getallen.Select(getal => getal * getal);
//foreach (var k in kwadraten) Console.WriteLine(k);
//var landen = new[]
//{
//  new {Naam = "Frankrijk", Oppervlakte = 643427},
//  new {Naam = "Belgie", Oppervlakte = 30688},
//  new {Naam = "Nederland", Oppervlakte = 41528}
//};
//var landOppervlaktes = landen.Select(land => land.Oppervlakte);
//foreach (var opp in landOppervlaktes) Console.WriteLine(opp);
//using Firma.Personeel;
//List<Werknemer> werknemers = 
//[
//  new Arbeider("Asterix", new DateTime(2026, 1, 1), Geslacht.Man, 24.79m, 3),
//  new Bediende("Obelix", new DateTime(2026, 2, 1), Geslacht.Man, 2400.79m),
//  new Manager("Idefix", new DateTime(2026, 3, 1), Geslacht.Man, 2400.79m, 7000m)
//];
////var werknemersMetNaamEnDatumInDienst = werknemers.Select(w => new { Werknemernaam = w.Naam, DatumInDienst = w.InDienst });
//var werknemersMetNaamEnDatumInDienst = werknemers.Select(w => new { w.Naam, w.InDienst }); // kan ook zonder een key te definieren
//foreach (var werknemer in werknemersMetNaamEnDatumInDienst) Console.WriteLine($"{werknemer.Naam}\t(in dienst: {werknemer.InDienst.ToShortDateString()})");
// Chain LINQ queries
//var namen = new List<String> { "Asterix", "Obelix", "Idefix", "Ambiorix" };
//var geselecteerdeNamen = namen.Where(n => n.Length > 6).OrderBy(n => n).Select(n => n.ToUpper());
//foreach (var n in geselecteerdeNamen) Console.WriteLine(n);
// Aggregatie functies
//var getallen = new[] { 0, 2, 1, 4, 3, 5, 7, 6, 8, 9 };
//Console.WriteLine("Aantal getallen: ");
//Console.WriteLine(getallen.Count());
//Console.WriteLine("Som van alle getallen: ");
//Console.WriteLine(getallen.Sum());
//Console.WriteLine("Gemiddelde van alle getallen: ");
//Console.WriteLine(getallen.Average());
//Console.WriteLine("Kleinste getal: ");
//Console.WriteLine(getallen.Min());
//Console.WriteLine("Grootste getal: ");
//Console.WriteLine(getallen.Max());
//Console.WriteLine("Aantal getallen > 3: ");
//Console.WriteLine(getallen.Count(getal => getal > 3));
//var landen = new[]
//{
//  new {Naam = "Frankrijk", Oppervlakte = 643427},
//  new {Naam = "Belgie", Oppervlakte = 30688},
//  new {Naam = "Nederland", Oppervlakte = 41528}
//};
//var alleOppervlaktes = landen.Select(l => l.Oppervlakte); // ipv lambda te schrijven tussen de () om de oppervlakte parameter te gerbuiken - map deze gewoon in een nieuwe verzameling
//Console.WriteLine("Aantal landen: ");
//Console.WriteLine(landen.Count());
//Console.WriteLine("Totale oppervlakte: ");
////Console.WriteLine(landen.Sum(l => l.Oppervlakte));
//Console.WriteLine(alleOppervlaktes.Sum());
//Console.WriteLine("Gemiddelde oppervlakte: ");
////Console.WriteLine(landen.Average(l => l.Oppervlakte));
//Console.WriteLine(alleOppervlaktes.Average());
//Console.WriteLine("Kleinste oppervlakte: ");
////Console.WriteLine(landen.Min(l => l.Oppervlakte));
//Console.WriteLine(alleOppervlaktes.Min());
//Console.WriteLine("Grootste oppervlakte: ");
////Console.WriteLine(landen.Max(l => l.Oppervlakte));
//Console.WriteLine(alleOppervlaktes.Max());
// bewerkingen met verzamelingen
//List<string> groep1 = ["An", "Johan", "Els", "Hans", "an", "Hans"];
//List<string> groep2 = ["An", "Peter", "Wim", "Hans"];
//Console.WriteLine($"Distinct() - unieke namen: \n{string.Join('-', groep1.Distinct())}");
//Console.WriteLine($"Concat() - groepen samenvoegen - alle namen: \n{string.Join('-', groep1.Concat(groep2))}");
//Console.WriteLine($"Union() - groepen samenvoegen - geen dubbele namen: \n{string.Join('-', groep1.Union(groep2))}");
//Console.WriteLine($"Intersect():\n{string.Join('-', groep1.Intersect(groep2))}");
//Console.WriteLine($"Except():\n{string.Join('-', groep1.Except(groep2))}");
// extension method Any()
//List<string> namen = ["Asterix", "Obelix", "Idefix", "Ambiorix"];
//Console.WriteLine("Geef de beginletter(s) in: ");
//var beginVanNaam = Console.ReadLine()!;
//// met extra parameter om aan te geven dat er geen onderscheidt gemaakt moet worden tussen hofod- en kleine letters
//var gevondenNamen = namen.Where(n => n.StartsWith(beginVanNaam, StringComparison.CurrentCultureIgnoreCase));
//if (gevondenNamen.Any())
//{
//  foreach (var naam in gevondenNamen)
//  {
//    Console.WriteLine(naam);
//  }
//}
//else
//{
//  Console.WriteLine("Het resultaat bevat geen elementen");
//}
// extension method GroupBy()
//List<string> namen = ["An", "Piet", "Els", "Peter", "Anne", "Axelle"];
//var namenGegroepeerd = namen.GroupBy(n => n[0]);
//Console.WriteLine("Aantal namen die beginnen met ");
//foreach (var gr in namenGegroepeerd) Console.WriteLine($"{gr.Key}: {gr.Count()}");
//Console.WriteLine();
//Console.WriteLine("Namen per eerste letter:");
//foreach (var gr in namenGegroepeerd)
//{
//  Console.WriteLine(gr.Key);
//  foreach (var n in gr) Console.WriteLine($"  {n}");
//}
// query comprehension syntax
//List<String> namen = ["Asterix", "Obelix", "Idefix", "Ambiorix", "Bellefleur"];
//var geselecteerdeNamen = namen.Where(n => n.Length > 6).OrderBy(n => n).Select(n => n.ToUpper());
//foreach (var n in geselecteerdeNamen) Console.WriteLine(n);
// dit hierboven kan dus ook als volgt geschreven worden:
//List<String> namen = ["Asterix", "Obelix", "Idefix", "Ambiorix", "Bellefleur"];
//var geselecteerdeNamen = from naam in namen where naam.Length > 6 orderby naam select naam.ToUpper(); // query comprehensive syntax
//foreach (var n in geselecteerdeNamen) Console.WriteLine(n);
// deferred execution
//List<string> namen = new List<String>() { "Asterix", "Obelix" };
//var namenDieBeginnenMetA =
//from naam in namen
//where naam.StartsWith("A")
//select naam;
//namen.Add("Ambiorix ");
//foreach (var naam in namenDieBeginnenMetA)
//Console.WriteLine(naam);
// onmiddelijk executeren met ToList()
//List<string> namen = new List<String>() { "Asterix", "Obelix" };
//var namenDieBeginnenMetA =
//(from naam in namen
// where naam.StartsWith("A")
// select naam).ToList();
//namen.Add("Ambiorix ");
//foreach (var naam in namenDieBeginnenMetA)
//  Console.WriteLine(naam);
// meer extension methods
// FirstOrDefault()
//List<string> namen = new List<String>() { "Asterix", "Obelix", "Ambiorix" };
//var eersteNaam = namen.FirstOrDefault();
//Console.WriteLine(eersteNaam);
//Console.WriteLine("Beginletter? ");
//var beginLetter = Console.ReadLine()!;
//var eersteNaamMetBeginLetter = (from naam in namen where naam.StartsWith(beginLetter) select naam).FirstOrDefault();
//if (eersteNaamMetBeginLetter != null)
//  Console.WriteLine(eersteNaamMetBeginLetter);
//else
//  Console.WriteLine($"Er zijn geen namen die beginnen met {beginLetter}");
// LastOrDefault()
//List<String> namen = ["Asterix", "Obelix", "Idefix", "Ambiorix", "Bellefleur"];
//var laatsteNaam = namen.LastOrDefault();
//Console.WriteLine(laatsteNaam);
//Console.WriteLine("Beginletter? ");
//var beginLetter = Console.ReadLine()!;
//var naamMetBeginLetter = (from naam in namen where naam.StartsWith(beginLetter) select naam).LastOrDefault();
//if (naamMetBeginLetter != null)
//  Console.WriteLine(naamMetBeginLetter);
//else
//  Console.WriteLine($"Er zijn geen namen die beginnen met {beginLetter}");
// SingleOrDefault()
//List<String> namen = ["Asterix", "Obelix", "Idefix", "Ambiorix", "Bellefleur"];
//Console.WriteLine("Beginletter? ");
//var beginLetter = Console.ReadLine()!;
//var naamMetBeginLetter = (from naam in namen where naam.StartsWith(beginLetter) select naam).SingleOrDefault();
//if (naamMetBeginLetter != null)
//  Console.WriteLine(naamMetBeginLetter);
//else
//  Console.WriteLine($"Er zijn geen namen die beginnen met {beginLetter}");
// ElementAtOrDefault()
//List<String> namen = ["Asterix", "Obelix", "Idefix", "Ambiorix", "Bellefleur"];
//var naamOpPositie = namen.ElementAtOrDefault(7);
//if (naamOpPositie != null) Console.WriteLine(naamOpPositie);
//else Console.WriteLine("De opgegeven index is niet correct!");
// Nog enkele andere voorbeelden
//using CSharpPFCursus;
// Selecties
//var brouwers = Brouwers.GetBrouwers();
//var belgischeBrouwers = brouwers.Where(b => b.Belgisch);
//foreach (var b in belgischeBrouwers) Console.WriteLine(b.ToString());
//Console.WriteLine(); // of
//var belgischeBrouwers2 = from brouwer in brouwers where brouwer.Belgisch select brouwer;
//foreach (var b in belgischeBrouwers2) Console.WriteLine(b.ToString());
//Console.WriteLine();
//// of
//Console.WriteLine("Belgische brouwerijen met 3 bieren:");
//var belgischeBrouwersMet3Bieren = brouwers.Where(b => b.Belgisch && b.Bieren.Count == 3);
//foreach (var b in belgischeBrouwersMet3Bieren) Console.WriteLine(b.Brouwernaam);
//Console.WriteLine();
//// of
//var belgischeBrouwersMet3Bieren2 = from brouwer in brouwers where brouwer.Belgisch && brouwer.Bieren.Count == 3 select brouwer;
//foreach (var b in belgischeBrouwersMet3Bieren2) Console.WriteLine(b.Brouwernaam);
//Console.WriteLine();
//// of
//Console.WriteLine("Brouwers met een ingegeven aantal bieren: ");
//Console.Write("Geef een aantal: ");
//var aantal = int.Parse(Console.ReadLine()!);
//var brouwersMetXAantalBieren = from brouwer in brouwers where brouwer.Bieren.Count == aantal select brouwer;
//foreach (var b in brouwersMetXAantalBieren) Console.WriteLine(b.Brouwernaam);
//Console.WriteLine();
// Sorteren
//using CSharpPFCursus;
//var brouwers = Brouwers.GetBrouwers();
//var brouwersGesorteerdAsc = brouwers.OrderBy(b => b.Brouwernaam);
//foreach (var b in brouwersGesorteerdAsc) Console.WriteLine(b.ToString());
//Console.WriteLine();
//var brouwersGesorteerdDesc = from b in brouwers orderby b.Brouwernaam descending select b;
//foreach (var b in brouwersGesorteerdDesc) Console.WriteLine(b.ToString());
// Anonymous type
//using CSharpPFCursus;
//var brouwers = Brouwers.GetBrouwers();
//var brouwerGegevens = from b in brouwers select new { b.Brouwernaam, b.Bieren.Count };
//foreach (var b in brouwerGegevens) Console.WriteLine($"{b.Brouwernaam}: {b.Count} bier(en)");
//Console.WriteLine();
//// of
//var brouwerGegevens2 = brouwers.Select(b => new {b.Brouwernaam, b.Bieren.Count});
//foreach (var b in brouwerGegevens2) Console.WriteLine($"{b.Brouwernaam}: {b.Count} bier(en)");
//Console.WriteLine();
//// of
//var brouwerGegevens3 = from b in brouwers select new { Naam = b.Brouwernaam, AantalBieren = b.Bieren.Count };
//foreach (var b in brouwerGegevens3) Console.WriteLine($"{b.Naam}: {b.AantalBieren} bier(en)");
// van een hierarchische structuur naar een platte structuur
// om de verzamelingen in de verzameling aan te roepen, kun je zo doen
//using CSharpPFCursus;
//var brouwers = Brouwers.GetBrouwers();
//var bieren = from brouwer in brouwers from bier in brouwer.Bieren select bier;
//foreach (var b in bieren) Console.WriteLine(b.ToString());
// je kunt het dus niet zo doen
//var bieren = from brouwer in brouwers select brouwer.Bieren;
//foreach (var b in bieren) Console.WriteLine(b.ToString());
// je kunt ook gebruik maken van de extension method SelectMany()
//var bieren = brouwers.SelectMany(b => b.Bieren);
//foreach (var b in bieren) Console.WriteLine(b.ToString());
// overzicht alcoholarme bieren
//var bieren = from brouwer in brouwers from bier in brouwer.Bieren where bier.Alcohol < 0.2f select bier;
// of
//var bieren = brouwers.SelectMany(b => b.Bieren).Where(b => b.Alcohol < 0.2f);
//foreach (var b in bieren) Console.WriteLine(b.ToString());
// aggregatie functies
//using CSharpPFCursus;
//var brouwers = Brouwers.GetBrouwers();
// aantal belgische brouwers
//var aantalBeBrouwers = (from brouwer in brouwers where brouwer.Belgisch select brouwer).Count();
// of gemakkelijker
//var aantalBeBrouwers = brouwers.Count(b => b.Belgisch);
//Console.WriteLine($"Aantal Belgische brouwers: {aantalBeBrouwers}");
// totaal aantal bieren
//var alleBieren = from br in brouwers from b in br.Bieren select b;
//foreach (var b in alleBieren) Console.WriteLine($"Totaal aantal bieren: {alleBieren.Count()}");
// of in 1 statement
//Console.WriteLine($"Totaal aantal bieren: {(from br in brouwers from b in br.Bieren select b).Count()}");
// of met SelectMany()
//Console.WriteLine($"Totaal aantal bieren: {brouwers.SelectMany(b => b.Bieren).Count()}");
// aantal belgische bieren
//var aantalBeBieren = (from br in brouwers where br.Belgisch from b in br.Bieren select b).Count();
//Console.WriteLine($"Aantal Belgische bieren: {aantalBeBieren}");
// gemiddelde alcoholgehalte van alle bieren
//var bieren = from br in brouwers from b in br.Bieren select b;
//var gemiddeldeAlcohol = bieren.Any() ? bieren.Average(b => b.Alcohol) : 0.0; // met extra null check
//Console.WriteLine($"Gemiddelde alcoholgehalte van de bieren: {gemiddeldeAlcohol}");
// Groeperen
//using CSharpPFCursus;
//var brouwers = Brouwers.GetBrouwers();
// met query syntax
//var opBelgisch = from br in brouwers group br by br.Belgisch;
//foreach (var gr in opBelgisch)
//{
//  Console.WriteLine(gr.Key ? "Belgisch" : "Niet Belgisch");
//  foreach (var br in gr)
//    Console.WriteLine($"  {br.Brouwernaam}");
//}
// met extension method
//var opBelgisch2 = brouwers.GroupBy(b => b.Belgisch);
//foreach (var gr in opBelgisch2)
//{
//  Console.WriteLine(gr.Key ? "Belgisch" : "Niet Belgisch");
//  foreach (var br in gr)
//    Console.WriteLine($"  {br.Brouwernaam}");
//}
// groeperen met sorteren
//var opAantalBieren = from br in brouwers group br by br.Bieren.Count into mijnGroep orderby mijnGroep.Key select mijnGroep;
//foreach (var gr in opAantalBieren)
//{
//  Console.WriteLine($"Brouwers met {gr.Key} bieren:");
//  foreach (var br in gr)
//    Console.WriteLine($"  {br.Brouwernaam}");
//}
// alternatieve oplossing
//var opAantalBieren = brouwers.GroupBy(b => b.Bieren.Count).OrderBy(g => g.Key);
//foreach (var gr in opAantalBieren)
//{
//  Console.WriteLine($"Brouwers met {gr.Key} bieren:");
//  foreach (var br in gr)
//    Console.WriteLine($"  {br.Brouwernaam}");
//}
// Join 
//using CSharpPFCursus;
//var personen = new[]
//{
//  new {Naam = "Jan", AantalKinderen = 1},
//  new {Naam = "Mieke", AantalKinderen = 2},
//  new {Naam = "Else", AantalKinderen = 1}
//};
//var toegangsprijzen = new[]
//{
//  new {AantalKinderen = 1, Bedrag = 10},
//  new {AantalKinderen = 1, Bedrag = 25}
//};
////var toegangsPrijzenPerPersoon = from p in personen join prijs in toegangsprijzen on p.AantalKinderen equals prijs.AantalKinderen select new { p.Naam, prijs.Bedrag }; // -- query manier
//var toegangsPrijzenPerPersoon = personen.Join(toegangsprijzen, p => p.AantalKinderen, prijs => prijs.AantalKinderen, (p, prijs) => new { p.Naam, prijs.Bedrag }); // -- method manier
//foreach (var p in toegangsPrijzenPerPersoon) Console.WriteLine($"{p.Naam}: {p.Bedrag} euro");
// LINQ query op basis van een string als data
//using CSharpPFCursus;
//var tekst = "Vlaamse Dienst Voor Arbeidsbemiddeling en Beroepsopleiding";
//var lettersA = from l in tekst.ToUpper() where l == 'A' select l;
//Console.WriteLine($"De tekst {tekst} bevat {lettersA.Count()} A's");
//var zin = "The quick brown fox jumps over the lazy dog";
//var woorden = zin.Split(' ');
//var woordenVan3Tekens = from w in woorden where w.Length == 3 select w.ToLower();
//foreach (var w in woordenVan3Tekens.Distinct()) Console.WriteLine(w);

// Regex
// - bij JS staat een regex tussen / /, bij C# is dit @" "
// Voorbeeld
//using System.Text.RegularExpressions;
//var regex = new Regex(@"^(\d{4})-(\d{4})$");
//var match = regex.Match("2000-2026");
//if (match.Success)
//{
//  Console.WriteLine(match.Groups[1]);
//  Console.WriteLine(match.Groups[2]);
//}
//else
//{
//  Console.WriteLine("Verkeerd");
//}
// oefening emailadres
//var regex = new Regex(@"^.+@.+\..+$"); // dit is wel makkelijker, maar ik weet dat dit niet vaak gebruikt wordt want is te generic
//var regex = new Regex(@"^[0-9a-zA-Z\-\._]+@[a-zA-Z]+\.[a-z]{2,5}$"); // dit is meer specifiek, meer restricted, dus beter -- zo heb ik het bij JS geleerd
//var email = regex.Match("martine.boulanger@gmail.com");
//if (email.Success)
//{
//  Console.WriteLine(email);
//}
//else
//{
//  Console.WriteLine("Verkeerd");
//}
// oefening bankrekening
//var regex = new Regex(@"^BE[.\s?\d]{17}$"); // met spacies tussen de cijfers in de iban nummer
//var bank = regex.Match("BE03 0014 4794 6884");
//var regex = new Regex(@"^BE\d{14}$"); // zonder spacies tussen de cijfers in de iban nummer
//var bank = regex.Match("BE03001447946884");
//if (bank.Success)
//{
//  Console.WriteLine(bank);
//}
//else
//{
//  Console.WriteLine("Verkeerd");
//}
// oefening nummerplaat
//var regex = new Regex(@"(\d{1})-(\D{3})-(\d{3})$");
//var nummerplaat = regex.Match("2-HDC-811");
//if (nummerplaat.Success)
//{
//  Console.WriteLine(nummerplaat);
//}
//else
//{
//  Console.WriteLine("Verkeerd");
//}

// Tuples
//using Firma.Personeel;
//Werknemer asterix = new Arbeider("Asterix", new DateTime(2020,1,1), Geslacht.Man, 24.79m, 3);
//asterix.Verlofdagen = [
//    new DateTime(2026,1,2),
//    new DateTime(2026,2,3),
//    new DateTime(2026,2,4),
//];
//asterix.Ziektedagen = [
//    new DateTime(2026,1,6),
//    new DateTime(2026,1,7),
//    new DateTime(2026,1,8),
//    new DateTime(2026,1,9),
//    new DateTime(2026,1,10),
//];
//(int aantalVerlofdagen, int aantalZiektedagen) afwezighedenasterix = asterix.Afwezigheden();
//Console.WriteLine($"Asterix: {afwezighedenasterix.aantalVerlofdagen} verlofdagen + {afwezighedenasterix.aantalZiektedagen} ziektedagen");

// partial methods
//using Firma;
//var klant = new Klant { Naam = "Jan" };
//klant.Naam = "Piet";
//Console.WriteLine(klant.Naam);

// Files and Streams - I/O
//using CSharpPFCursus;
//using System.Text;
//List<Pizza> pizzas = [
//    new Pizza { Naam = "Pizza Margherita", Onderdelen = ["Tomatensaus", "Mozzarella"], Prijs = 8m },
//    new Pizza { Naam = "Pizza Vegetariana", Onderdelen = ["Tomatensaus", "Mozzarella", "Groenten"], Prijs = 9.5m },
//    new Pizza { Naam = "Pizza Napoli", Onderdelen = ["Tomatensaus", "Mozzarella", "Ansjovis", "Kappers", "Olijven"], Prijs = 10m },
//];
// de gegevens wegschrijven
//string locatie = @"C:\Data\";
//StringBuilder pizzaRegel;
//try
//{
//    using var schrijver = new StreamWriter(locatie + "pizzas.txt");
//    foreach (var pizza in pizzas)
//    {
//        pizzaRegel = new StringBuilder();
//        pizzaRegel.Append($"{pizza.Naam}");
//        pizzaRegel.Append($"{pizza.Onderdelen?.Count ?? 0}");
//        pizzaRegel.Append($"{(pizza.Onderdelen != null ? string.Join(":", pizza.Onderdelen) : "")}:");
//        pizzaRegel.Append(pizza.Prijs);
//        schrijver.WriteLine(pizzaRegel);
//    }
//}
//catch (IOException)
//{
//    Console.WriteLine("Fout bij het schrijven naar het bestand!");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
// het lezen van het bestand
//List<Pizza> pizzas = [];
//String? pizzaRegel;
//string pizzaNaam;
//int aantalOnderdelen;
//List<string> pizzaOnderdelen;
//decimal prijs;
//try
//{
//    using var lezer = new StreamReader(locatie + "pizzas.txt");
//    while ((pizzaRegel = lezer.ReadLine()) is not null)
//    {
//        string[] gegevens = pizzaRegel.Split(':');
//        pizzaNaam = gegevens[0];
//        aantalOnderdelen = int.Parse(gegevens[1]);
//        pizzaOnderdelen = [];
//        for (var teller = 0; teller < aantalOnderdelen; teller++) pizzaOnderdelen.Add(gegevens[teller + 2]);
//        prijs = decimal.Parse(gegevens[gegevens.Length - 1]);
//        pizzas.Add(new Pizza { Naam = pizzaNaam, Onderdelen = pizzaOnderdelen, Prijs = prijs });    
//    }
//}
//catch (IOException)
//{
//    Console.WriteLine("Fout bij het lezen van het bestand!");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
//// de gegevens tonen
//foreach (Pizza pizza in pizzas) 
//{
//    Console.WriteLine(pizza.ToString());
//    if (pizza.Onderdelen != null)
//    {
//        foreach (string onderdeel in pizza.Onderdelen)
//        {
//            Console.WriteLine($"  {onderdeel}");
//        }
//    }
//    Console.WriteLine();
//}

// Indexers
using Firma.Personeel;
Overuren mijnOveruren = new Overuren();
try
{
    mijnOveruren[0] = 4;
    mijnOveruren["apr"] = 2;
    Console.WriteLine(mijnOveruren["jan"]);
    Console.WriteLine(mijnOveruren[3]);
    Console.WriteLine(mijnOveruren.Totaal);
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}