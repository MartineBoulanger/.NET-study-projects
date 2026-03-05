// See https://aka.ms/new-console-template for more information
//Console.Write("Asterix");
//Console.Write(" en Obelix");
//Console.WriteLine("Hello World!");
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
Console.Write("Type een woord: ");
string woord = Console.ReadLine() ?? "";
//bool palindroom = true;
int vanafBegin, vanafEinde;
//for (int vanafBegin = 0, vanafEinde = woord.Length - 1; vanafBegin < vanafEinde; vanafBegin++, vanafEinde--)
//    if (woord[vanafBegin] != woord[vanafEinde]) palindroom = false;
//    if (palindroom) Console.WriteLine("Dit woord is een palindroom");
//    else Console.WriteLine("Dit woord is geen palindroom");
//;
for (vanafBegin = 0, vanafEinde = woord.Length - 1; vanafBegin < vanafEinde && woord[vanafBegin] == woord[vanafEinde]; vanafBegin++, vanafEinde--)
    if (woord[vanafBegin] == woord[vanafEinde]) Console.WriteLine("Dit woord is een palindroom");
    else Console.WriteLine("Dit woord is geen palindroom");
;