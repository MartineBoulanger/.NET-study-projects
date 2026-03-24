// 1. Variabelen, constanten en bewerkingen
// 1.1 Conversie Celsius -> Fahrenheit
// const float GemLichaamsTempCelsius = 37.0f;
// float gemLichaamsTempFahrenheit = GemLichaamsTempCelsius * 9f / 5f + 32f;
// Console.WriteLine($"Gemiddelde lichaamstemperatuur in Celsius: {GemLichaamsTempCelsius}");
// Console.WriteLine($"Gemiddelde lichaamstemperatuur in Fahrenheit: {gemLichaamsTempFahrenheit}");
// Console.WriteLine("------------------------------------------------------------------");
// 1.2 Omrekening seconden
// int aantalSeconden = 23456;
// const int aantalSecPerUur = 3600;
// const int aantalSecPerMin = 60;
// int uren, minuten, seconden, restSeconden;
// uren = aantalSeconden / aantalSecPerUur;
// restSeconden = aantalSeconden % aantalSecPerUur;
// minuten = restSeconden / aantalSecPerMin;
// seconden = restSeconden % aantalSecPerMin;
// Console.WriteLine("U:" + uren + " M:" + minuten + " S:" + seconden);
// Console.WriteLine("------------------------------------------------------------------");
// 1.3 Snoepautomaat
// const decimal invoerMunt = 2m;
// decimal bedrag = 1.67m;
// int aantal1E, aantal50C, aantal20C, aantal10C, aantal5C, aantal2C, aantal1C;
// decimal wisselgeld = invoerMunt - bedrag;
// int wisselGeldInCenten = (int)(wisselgeld * 100);
// aantal1E = wisselGeldInCenten / 100;
// wisselGeldInCenten %= 100;
// aantal50C = wisselGeldInCenten / 50;
// wisselGeldInCenten %= 50;
// aantal20C = wisselGeldInCenten / 20;
// wisselGeldInCenten %= 20;
// aantal10C = wisselGeldInCenten / 10;
// wisselGeldInCenten %= 10;
// aantal5C = wisselGeldInCenten / 5;
// wisselGeldInCenten %= 5;
// aantal2C = wisselGeldInCenten / 2;
// aantal1C = wisselGeldInCenten % 2;
// Console.WriteLine("Te betalen: " + bedrag + " euro");
// Console.WriteLine("Wisselgeld: " + wisselgeld + " euro");
// Console.WriteLine("Munten van 1 euro: " + aantal1E);
// Console.WriteLine("Munten van 50 cent: " + aantal50C);
// Console.WriteLine("Munten van 20 cent: " + aantal20C);
// Console.WriteLine("Munten van 10 cent: " + aantal10C);
// Console.WriteLine("Munten van 5 cent: " + aantal5C);
// Console.WriteLine("Munten van 2 cent: " + aantal2C);
// Console.WriteLine("Munten van 1 cent: " + aantal1C);
// Console.WriteLine("------------------------------------------------------------------");

// 2. Strings 
// using System.Text;
// Met StringBuilder
// Console.WriteLine("------------------------------------------------------------------");
// Console.Write("Uw familie naam: ");
// string naam = Console.ReadLine();
// Console.Write("Uw telefoonnummer: ");
// string zoneNummer = Console.ReadLine();
// Console.Write("Uw postcode: ");
// string postcode = Console.ReadLine();
// StringBuilder wachtwoord = new StringBuilder();
// wachtwoord.Append(naam[1].ToString().ToLower() + naam[0].ToString().ToUpper());
// wachtwoord.Append(zoneNummer.AsSpan(1,3));
// wachtwoord.Append(Math.Pow(int.Parse(postcode.Substring(postcode.Length - 1, 1)), 2));
// wachtwoord.Insert(3, "*");
// Console.WriteLine($"Het gegenereerde wachtwoord is: {wachtwoord}");
// Console.WriteLine("------------------------------------------------------------------");
// Zonder StringBuilder
// Console.WriteLine("------------------------------------------------------------------");
// Console.Write("Uw familie naam: ");
// string naam = Console.ReadLine() ?? "";
// Console.Write("Uw telefoonnummer: ");
// string zoneNummer = Console.ReadLine() ?? "";
// Console.Write("Uw postcode: ");
// string postcode = Console.ReadLine() ?? "";
// string wachtwoord = $"{naam.Substring(1,1).ToLower()}{naam.Substring(0,1).ToUpper()}{zoneNummer.AsSpan(1,3)}{Math.Pow(int.Parse(postcode.Substring(postcode.Length - 1, 1)), 2)}";
// Console.WriteLine($"Het gegenereerde wachtwoord is: {wachtwoord.Insert(3, "*")}");
// Console.WriteLine("------------------------------------------------------------------");

// 3. Selecties
// 3.1 Kortingsbon
// Console.WriteLine("------------------------------------------------------------------");
// Console.Write("Wat is het aankoopbedrag? ");
// decimal aankoopBedrag = Decimal.Parse(Console.ReadLine() ?? "");
// decimal korting = aankoopBedrag switch
// {
//   < 25 => aankoopBedrag * 0.01m,
//   >= 25 and <= 50 => aankoopBedrag * 0.02m,
//   > 50 and <= 100 => aankoopBedrag * 0.03m,
//   > 100 => aankoopBedrag * 0.05m,
// };
// Console.WriteLine($"De korting bedraagt: {korting:0.00} euro");
// Console.WriteLine("------------------------------------------------------------------");
// 3.2 Schrikkeljaar
// Console.WriteLine("------------------------------------------------------------------");
// Console.Write("Wat is het jaartal? ");
// int jaar = int.Parse(Console.ReadLine());
// string schrikkeljaar;
// if (jaar % 4 == 0) 
//   if (jaar % 100 == 0 && jaar % 400 != 0) schrikkeljaar = "geen";
//   else schrikkeljaar = "een";
// else schrikkeljaar = "geen";
// Console.WriteLine($"Het jaar {jaar} is {schrikkeljaar} schrikkeljaar");
// // of
// string schrikjaar = (jaar % 4 == 0 && jaar % 100 != 0) || jaar % 400 == 0 ? "een" : "geen";
// Console.WriteLine($"Het jaar {jaar} is {schrikjaar} schrikkeljaar");
// Console.WriteLine("------------------------------------------------------------------");
// 3.3 Lichtkrant
//using System.Text;
//Console.WriteLine("------------------------------------------------------------------");
//Console.Write("Wat is de datum? ");
//DateOnly vandaag = DateOnly.Parse(Console.ReadLine() ?? "");
//StringBuilder boodschap = new StringBuilder("Openingsuren: ");
//switch (vandaag.DayOfWeek)
//{
//  case DayOfWeek.Monday or DayOfWeek.Tuesday or DayOfWeek.Wednesday or DayOfWeek.Thursday or DayOfWeek.Friday:
//    boodschap.AppendLine("9u00-12u00 en 13u00-18u00");
//    boodschap.Append("We wensen u een prettige werkdag!");
//    break;
//  case DayOfWeek.Saturday:
//    boodschap.AppendLine("10u00-12u00");
//    boodschap.Append("We wensen u een fijn weekend!");
//    break;
//  case DayOfWeek.Sunday:
//    boodschap.Append("We zijn gesloten! Fijne Zondag gewenst!");
//    break;
//  default:
//    break;
//}
//Console.WriteLine(boodschap.ToString());
//Console.WriteLine("------------------------------------------------------------------");

// 4. Iteraties
// 4.1 kleinste, grootste en gemiddelde
//Console.WriteLine("------------------------------------------------------------------");
//int getal;
//do
//{
//    Console.Write("Voer een positief geheel getal in of -1 (stoppen): ");
//    getal = int.Parse(Console.ReadLine() ?? "");
//}
//while (getal < 0 && getal != -1);
//int kleinste = getal, grootste = getal, totaal = 0, aantal = 0;
//while (getal != -1)
//{
//    if (getal < kleinste) kleinste = getal;
//    else if (getal > grootste) grootste = getal;
//    totaal += getal;
//    aantal++;
//    do
//    {
//       Console.Write("Voer een positief geheel getal in of -1 (stoppen): ");
//        getal = int.Parse(Console.ReadLine() ?? "");
//    }
//    while (getal < 0 && getal != -1);
//};
//if (aantal > 0)
//{
//    Console.WriteLine("Kleinste getal is: {0}", kleinste);
//    Console.WriteLine("Grootste getal is: {0}", grootste);
//    Console.WriteLine("Gemiddelde is: {0}", (double)totaal / aantal);
//}
//else
//{
//    Console.WriteLine("Er werden geen getallen ingevoerd");
//};
//Console.WriteLine("------------------------------------------------------------------");
// 4.2 Priemgetal
//Console.WriteLine("------------------------------------------------------------------");
//int delers = 1;
//Console.Write("Voer een positief getal in dat is groter dan 1: ");
//int getal = int.Parse(Console.ReadLine() ?? "");
//if (getal > 1)
//{
//    for (int teller = 2; teller <= getal / 2; teller++)
//    {
//        if (getal % teller == 0)
//        {
//            Console.WriteLine($"{getal} is deelbaar door {teller}");
//            delers++;
//        }
//    }
//    if (delers > 1) Console.WriteLine("Het getal is geen priemgetal");
//    else Console.WriteLine("Het getal is een priemgetal");
//}
//else Console.WriteLine("Verkeerde invoer, probeer opnieuw.");
//Console.WriteLine("------------------------------------------------------------------");
// 4.3 IBAN rekeningnummer generator
//using System.Text;
//Console.WriteLine("------------------------------------------------------------------");
//const string ALFABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
//string beRekeningNr, ibanRekeningNr, ibanControle, controleGetal;
//ulong rest97;
//Console.Write("Typ het Belgisch rekening nummer in: ");
//beRekeningNr = Console.ReadLine() ?? "";
//ibanControle = beRekeningNr.Replace("-", "") + "BE00";
//StringBuilder nr = new StringBuilder();
//char teken;
//for (int teller = 0; teller < ibanControle.Length; teller++)
//{
//    teken = ibanControle[teller];
//    if (char.IsLetter(teken)) nr.Append(ALFABET.IndexOf(teken) + 10);
//    else nr.Append(teken);
//}
//rest97 = ulong.Parse(nr.ToString()) % 97ul;
//controleGetal = (98 - rest97).ToString();
//ibanRekeningNr = "BE" + (controleGetal.Length == 2 ? controleGetal : "0" + controleGetal) + ibanControle.Substring(0, ibanControle.Length - 4);
//ibanRekeningNr = ibanRekeningNr.Insert(12, " ");
//ibanRekeningNr = ibanRekeningNr.Insert(8, " ");
//ibanRekeningNr = ibanRekeningNr.Insert(4, " ");
//Console.WriteLine($"Het BE rekening nummer: {beRekeningNr} is het volgende IBAN nummer: {ibanRekeningNr}");
//Console.WriteLine("------------------------------------------------------------------");
// 4.4 Controle IBAN nummers
// using System.Text;
// Console.WriteLine("------------------------------------------------------------------");
// const string ALFABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
// string ibanNr, controleNr;
// ulong rest97;
// Console.Write("Geef het IBAN nummer in om te controle of het geldig is: ");
// ibanNr = Console.ReadLine() ?? "";
// controleNr = ibanNr.Trim().Replace(" ", "");
// controleNr = controleNr.Substring(4) + controleNr.Substring(0, 4);
// if (controleNr.Length == 16)
// {    
//     StringBuilder nr = new StringBuilder();
//     char teken;
//     for (int teller = 0; teller < controleNr.Length; teller++)
//     {
//         teken = controleNr[teller];
//         if (char.IsLetter(teken)) nr.Append(ALFABET.IndexOf(teken) + 10);
//         else nr.Append(teken);
//     }
//     rest97 = ulong.Parse(nr.ToString()) % 97ul;
//     if (rest97 == 1) Console.WriteLine("Dit is een geldig IBAN nummer");
//     else Console.WriteLine("Dit is geen geldig IBAN nummer");
// }
// else
// {
//     Console.WriteLine($"{ibanNr} is geen rekening nummer.");
// };
// Console.WriteLine("------------------------------------------------------------------");

// 5. Functies
// 5.1 Even
// Console.WriteLine("------------------------------------------------------------------");
// Console.Write("Geef een geheel getal in: ");
// bool IsEven (int getal) {return getal % 2 == 0;};
// if (int.TryParse(Console.ReadLine(), out int getal))
// {
//   Console.WriteLine($"{getal} is een {(IsEven(getal) ? "even" : "oneven")} getal.");
// }
// Console.WriteLine("------------------------------------------------------------------");
// 5.2 Examens
//Console.WriteLine("------------------------------------------------------------------");
//double LeesCijfer(string vak)
//{
//  double cijfer;
//  Console.Write($"Punten voor {vak} (tussen 0 en 10)> ");
//  while (!double.TryParse(Console.ReadLine(), out cijfer) || cijfer < 0 || cijfer > 10)
//  {
//    Console.Write($"Verkeerde invoer, geef de punten voor {vak} opnieuw in (tussen 0 en 10): ");
//  }
//  return cijfer;
//}
//bool OpAllesGeslaagd(double puntWis, double puntBoek, double puntIT)
//{
//  return puntWis >= 5 && puntBoek >= 5 && puntIT >= 5;
//}
//double Percentage(double puntWis, double puntBoek, double puntIT)
//{
//  return Math.Round((puntWis + puntBoek + puntIT) / 30.0 * 100.00, 0, MidpointRounding.AwayFromZero);
//}
//string Resultaat(double percentage)
//{
//  string result = percentage switch
//  {
//    < 68 => "voldoende",
//    < 77 => "onderscheiding",
//    < 85 => "grote onderscheiding",
//    _ => "grootste onderscheiding"
//  };
//  return result;
//}

//double puntenWiskunde = LeesCijfer("wiskunde");
//double puntenBoekhouden = LeesCijfer("boekhouden");
//double puntenInformatica = LeesCijfer("informatica");
//if (OpAllesGeslaagd(puntenWiskunde, puntenBoekhouden, puntenInformatica))
//{
//  double percentage = Percentage(puntenWiskunde, puntenBoekhouden, puntenInformatica);
//  string result = Resultaat(percentage);
//  Console.WriteLine($"Student behaalde {percentage}% met als resultaat {result}.");
//}
//else
//{
//  Console.WriteLine("Student is niet voor alles geslaagd.");
//}
//Console.WriteLine("------------------------------------------------------------------");

// 6. Arrays
// 6.1 Codeerprogramma
//Console.WriteLine("------------------------------------------------------------------");
//char[] sleutel = { 'Q', 'S', 'P', 'A', 'T', 'V', 'X', 'B', 'C', 'R', 'J', 'Y', 'E', 'D', 'U', 'O', 'H', 'Z', 'G', 'I', 'F', 'L', 'N', 'W', 'K', 'M' };
//Console.Write("Voer tekst in: ");
//string tekst = Console.ReadLine()!.ToUpper();
//string geheim = string.Empty;
//for (int letter = 0; letter < tekst.Length; letter++)
//{
//    if (char.IsUpper(tekst[letter])) geheim += sleutel[(int)tekst[letter] - (int)'A'];
//    else geheim += tekst[letter];
//}
//Console.WriteLine($"In code: {geheim}");
//Console.WriteLine("------------------------------------------------------------------");
// 6.2 Examens 2
// Console.WriteLine("------------------------------------------------------------------");
// double LeesCijfer(string vak)
// {
//     double cijfer;
//     Console.Write($"Punten voor {vak} (tussen 0 en 10)> ");
//     while (!double.TryParse(Console.ReadLine(), out cijfer) || cijfer < 0 || cijfer > 10)
//     {
//         Console.Write($"Verkeerde invoer, geef de punten voor {vak} opnieuw in (tussen 0 en 10): ");
//     }
//     return cijfer;
// }
// bool OpAllesGeslaagd(double[] punten)
// {
//     foreach (var punt in punten) if (punt < 5) return false;
//     return true;
// }
// double Percentage(double[] punten)
// {
//     double sum = 0;
//     for (int i = 0; i < punten.Length; i++) sum += punten[i];
//     return Math.Round(sum / (punten.Length * 10) * 100.00, 0, MidpointRounding.AwayFromZero);
// }
// string Resultaat(double percentage)
// {
//     string result = percentage switch
//     {
//         < 68 => "voldoende",
//         < 77 => "onderscheiding",
//         < 85 => "grote onderscheiding",
//         _ => "grootste onderscheiding"
//     };
//     return result;
// }
// string[] vakken = ["wiskunde","boekhouden","informatica"];
// double[] punten = new double[vakken.Length];
// for (int i = 0; i < vakken.Length; i++) punten[i] = LeesCijfer(vakken[i]);
// if (OpAllesGeslaagd(punten))
// {
//     double percentage = Percentage(punten);
//     string resultaat = Resultaat(percentage);
//     Console.WriteLine($"Student behaalde {percentage}% met als resultaat {resultaat}.");
// }
// else
// {
//     Console.WriteLine("Student is niet voor alles geslaagd.");
// }
// Console.WriteLine("------------------------------------------------------------------");

// 7. Classes en Objects + 8. Methods + 9. Constructors
// 7.1 + 8.1 + 9.1 De class Rekening - zie file Rekening.cs
// 7.2 + 8.2 + 9.2 Het Hoofdprogramma
//using CSharpPFOefeningen;
//Console.WriteLine("------------------------------------------------------------------");
//Rekening mijnRekening = new Rekening("BE03001447946884", 235m, DateOnly.FromDateTime(DateTime.Today));
//Console.WriteLine(mijnRekening.GetInfo());
//decimal newSaldo = mijnRekening.Storten(100m);
//Console.WriteLine(mijnRekening.GetInfo());
//Console.WriteLine("------------------------------------------------------------------");
// 7.3 + 8.3 + 9.3 De class Voertuig - zie file Voertuig.cs
// 7.4 + 8.4 + 9.4 Het hoofdprogramma
//Console.WriteLine("------------------------------------------------------------------");
//Voertuig auto1 = new Voertuig("Anna Dackus", 499.99m, 119, 4.5f, "2-HDC-811");
//Voertuig auto2 = new Voertuig();
//Voertuig auto3 = new Voertuig("Martine");
//Voertuig auto4 = new Voertuig("Emile", 23m);
//Voertuig auto5 = new Voertuig(nummerplaat: "1-sug-546");
//Console.WriteLine(auto1.GetInfo());
//Console.WriteLine(auto2.GetInfo());
//Console.WriteLine(auto3.GetInfo());
//Console.WriteLine(auto4.GetInfo());
//Console.WriteLine(auto5.GetInfo());
//Console.WriteLine("------------------------------------------------------------------");

// 10. primary constructors
// 10.1 Rekening2
// using CSharpPFOefeningen;
// Console.WriteLine("------------------------------------------------------------------");
// Rekening2 rek = new("BE03001447946884",1025.65m,DateOnly.FromDateTime(new DateTime(2015,5,4)));
// Console.WriteLine(rek.GetInfo());
// Console.WriteLine("------------------------------------------------------------------");
// // 10.2 Voertuig2
// Console.WriteLine("------------------------------------------------------------------");
// Voertuig2 auto = new("Martine", 788.99m, 119, 5.6f, "2-HDC-811");
// Console.WriteLine(auto.GetInfo());
// Voertuig2 auto2 = new();
// Console.WriteLine(auto2.GetInfo());
// Voertuig2 auto3 = new();
// Console.WriteLine(auto3.GetInfo());
// auto3.Nummerplaat = "1-sug-456";
// Console.WriteLine(auto3.GetInfo());
// Console.WriteLine("------------------------------------------------------------------");

// 11. Object initializers
// 11.1 Rekening
//using CSharpPFOefeningen;
// Console.WriteLine("------------------------------------------------------------------");
// Rekening rek = new("BE03001447946884", 1025.65m, DateOnly.FromDateTime(new DateTime(2015, 5, 4)));
// Console.WriteLine(rek.GetInfo());
// rek.Rekeningnummer = "BE03001348746772";
// Console.WriteLine(rek.GetInfo());
// Console.WriteLine("------------------------------------------------------------------");
// 11.2 Voertuig
//Console.WriteLine("------------------------------------------------------------------");
// Voertuig auto = new("Martine", 788.99m, 119, 5.6f, "2-HDC-811");
// Console.WriteLine(auto.GetInfo());
//Voertuig auto = new()
//{
//  Polishouder = "Boulanger",
//  Kostprijs = 500m,
//  Pk = 500,
//  GemiddeldVerbruik = 5f,
//  Nummerplaat = "2-HDG-432"
//};
//Voertuig auto2 = new()
//{
//  Polishouder = "Boulanger",
//  Nummerplaat = "2-HDG-432"
//};
//Voertuig auto3 = new()
//{
//  Polishouder = "Boulanger",
//};
// Voertuig auto4 = new()
// {
//   Nummerplaat = "2-HDG-432"
// };
//Console.WriteLine(auto.GetInfo());
//Console.WriteLine(auto2.GetInfo());
//Console.WriteLine(auto3.GetInfo());
// Console.WriteLine(auto4.GetInfo());
//Console.WriteLine("------------------------------------------------------------------");

// 12. Inheritance
// 12.1 Classes Zichtrekening & Spaarrekening
//using CSharpPFOefeningen;
//Console.WriteLine("------------------------------------------------------------------");
//Zichtrekening mijn = new Zichtrekening("BE03001447946884", 0m, DateOnly.FromDateTime(DateTime.Today), -600m);
//mijn.Storten(125m);
//Console.WriteLine(mijn.GetInfo());
//Console.WriteLine("------------------------------------------------------------------");
//Spaarrekening mijne = new Spaarrekening("BE03001447946884", 0m, DateOnly.FromDateTime(DateTime.Today), 10m);
//mijne.Storten(1000m);
//Console.WriteLine(mijne.GetInfo());
//Console.WriteLine("------------------------------------------------------------------");
// 12.2 Classes Vrachtwagen & Personenwagen
//Console.WriteLine("------------------------------------------------------------------");
//Vrachtwagen daf = new Vrachtwagen("Geerstrans", 112500.56m, 525, 11.6f, "2-TGY-456", 10000f);
//Console.WriteLine(daf.GetInfo());
//Console.WriteLine("------------------------------------------------------------------");
//Personenwagen citroen = new Personenwagen("Anna Dackus", 19990m, 119, 4.5f, "2-HDC-811", 4, 4);
//Console.WriteLine(citroen.GetInfo());
//Console.WriteLine("------------------------------------------------------------------");

// 13. Abstract classes, abstract members, static members
// 13.1 Oefening Bank
//using CSharpPFOefeningen;
//Console.WriteLine("------------------------------------------------------------------");
//Spaarrekening mijn = new Spaarrekening("BE03001467893452", 100m, DateOnly.FromDateTime(DateTime.Today));
//Spaarrekening jouw = new Spaarrekening("BE03001467893450", 100m, DateOnly.FromDateTime(DateTime.Today));
//Spaarrekening.Intrest = 3m;
//Console.WriteLine(mijn.GetInfo());
//Console.WriteLine(jouw.GetInfo());
//Spaarrekening.Intrest = 2m;
//Console.WriteLine(mijn.GetInfo());
//Console.WriteLine(jouw.GetInfo());
//Console.WriteLine("------------------------------------------------------------------");
//Vrachtwagen daf = new Vrachtwagen("Willem", 40000m, 500, 30, "2-ABC-987", 10000f);
//Personenwagen bmw = new Personenwagen("Hendrik", 20000m, 249, 8.5f, "1-TRC-567", 5, 5);
//Console.WriteLine(daf.GetInfo());
//Console.WriteLine($"kyotoscore: {daf.GetKyotoScore():F2}");
//Console.WriteLine();
//Console.WriteLine(bmw.GetInfo());
//Console.WriteLine($"kyotoscore: {bmw.GetKyotoScore():F2}");
//Console.WriteLine("------------------------------------------------------------------");

// 14. Inheritance polymorphism
// 14.1 Oefening Bank
// using CSharpPFOefeningen;
// Console.WriteLine("------------------------------------------------------------------");
// Spaarrekening.Intrest = 2m;
// Rekening[] arrRekeningen = new Rekening[2];
// arrRekeningen[0] = new Spaarrekening("BE03001447946884", 100m, DateOnly.FromDateTime(DateTime.Today));
// arrRekeningen[1] = new Zichtrekening("BE03001447946884", 235.45m, new DateOnly(2012, 4, 5), 0m);
// foreach (Rekening rek in arrRekeningen)
// {
//     Console.WriteLine(rek.GetInfo());
//     Console.WriteLine();
// }
// Console.WriteLine("------------------------------------------------------------------");
// //Voertuig[] vehicles = new Voertuig[2];
// Personenwagen auto = new Personenwagen("Anna", 15000m, 100, 5.6f, "2-DHC-811", 4, 4);
// Vrachtwagen camion = new Vrachtwagen("Martine", 123000m, 525, 15.6f, "2-ABC-456", 10000f);
// Voertuig[] vehicles = [auto, camion]; // kunt het ook zo doen
// foreach (Voertuig vehicle in vehicles)
// {
//     Console.WriteLine(vehicle.GetInfo());
//     Console.WriteLine($"kyotoscore: {vehicle.GetKyotoScore():F2}");
//     Console.WriteLine();
// }
// Console.WriteLine("------------------------------------------------------------------");

// 15. Aggregation
// 15.1 Oefening Bank
// using CSharpPFOefeningen;
// Console.WriteLine("------------------------------------------------------------------");
// Spaarrekening.Intrest = 3m;
// Klant eigenaar = new Klant
// {
//     Voornaam = "Martine",
//     Familienaam = "Boulanger"
// };
// Spaarrekening spaar = new Spaarrekening("BE03001447946884", 100m, DateOnly.FromDateTime(DateTime.Today), eigenaar);
// Zichtrekening zicht = new Zichtrekening("BE03001447946884", 100m, DateOnly.FromDateTime(DateTime.Today), eigenaar, -500m);
// Console.WriteLine(spaar.GetInfo());
// Console.WriteLine();
// Console.WriteLine(zicht.GetInfo());
// Console.WriteLine("------------------------------------------------------------------");

// 16. Interfaces
// 16.1 Oefening Bank
//using CSharpPFOefeningen;
//Console.WriteLine("------------------------------------------------------------------");
//Spaarrekening.Intrest = 2m;
//Klant eigenaar = new Klant
//{
//    Voornaam = "Anna",
//    Familienaam = "Dackus"
//};
//ISpaarmiddel[] spaarmiddels = new ISpaarmiddel[3];
//spaarmiddels[0] = new Zichtrekening("BE03001447946884", 335.56m, new DateOnly(2026, 2, 1), eigenaar, 0m);
//spaarmiddels[1] = new Spaarrekening("BE03001447946884", 200m, new DateOnly(2026, 3, 1), eigenaar);
//spaarmiddels[2] = new Kasbon(new DateOnly(2026, 4, 1), 2300.45m, 5, 4m, eigenaar);
//foreach (ISpaarmiddel middel in spaarmiddels)
//{
//    Console.WriteLine(middel.GetInfo());
//    Console.WriteLine();
//}
//Console.WriteLine("------------------------------------------------------------------");
//IVervuiler[] vervuilers = new IVervuiler[3];
//vervuilers[0] = new Personenwagen("Piet", 15000m, 150, 5.6f, "2-ABC-234", 3, 5);
//vervuilers[1] = new Vrachtwagen("Jan", 123000m, 500, 20.4f, "1-DVF-987", 5600f);
//vervuilers[2] = new Stookketel(12.3f);
//foreach (IVervuiler vervuiler in vervuilers)
//{
//    Console.WriteLine($"Vervuiling: {vervuiler.GeefVervuiling():F2}");
//}
//Console.WriteLine("------------------------------------------------------------------");
//Personenwagen bmw = new Personenwagen("Martine", 2400m, 89, 7.6f, "1-SUG-567", 3, 4);
//Vrachtwagen scania = new Vrachtwagen("Jan", 123000m, 500, 20.4f, "1-DVF-987", 5600f);
//Personenwagen citroen = new Personenwagen("Anna", 19900m, 119, 5.5f, "2-HDC-811", 4, 5);
//Vrachtwagen daf = new Vrachtwagen("Pieter", 140000m, 525, 14.3f, "2-ABC-987", 10000f);
//IPrivaat[] houders = [bmw, scania, citroen, daf];
//Console.WriteLine("Privaat gegevens voertuigen:");
//foreach (IPrivaat houder in houders)
//{
//    Console.WriteLine(houder.GeefPrivaatData());
//}
//Console.WriteLine("------------------------------------------------------------------");
//IMilieu[] milieus = [bmw, scania, citroen, daf];
//Console.WriteLine("Milieu gegevens voertuigen:");
//foreach (IMilieu milieu in milieus)
//{
//    Console.WriteLine(milieu.GeefMilieuData());
//}
//Console.WriteLine("------------------------------------------------------------------");

// 17. Exceptions
// 17.1 Oefening Bank
//using CSharpPFOefeningen;
//Console.WriteLine("------------------------------------------------------------------");
//try
//{
//  Klant ik = new Klant { Familienaam = "Boulanger", Voornaam = "Martine" };
//  Spaarrekening.Intrest = 2m;
//  Zichtrekening zicht = new("BE03001447946884", 240.40m, DateOnly.FromDateTime(new DateTime(200, 1, 1)), ik, -100m);
//  Spaarrekening spaar = new("BE03001447946889", 10m, DateOnly.FromDateTime(new DateTime(2026, 1, 1)), ik);
//  Kasbon bon = new (new DateOnly(2000, 4, 1), -2300.45m, -5, -4m, ik);
//  ISpaarmiddel[] lijst = [zicht, spaar, bon];
//  foreach (ISpaarmiddel item in lijst)
//  {
//    Console.WriteLine(item.GetInfo());
//    Console.WriteLine();
//  }
//}
//catch (Exception ex)
//{
//  Console.WriteLine(ex.Message);
//}
//Console.WriteLine("------------------------------------------------------------------");

// 18. Delegates en Events
// 18.1 Oefening Bank
//using CSharpPFOefeningen;
//Console.WriteLine("------------------------------------------------------------------");
//// objecten initialiseren
//Bank bnp = new() { BankId = 1, Naam = "VDAB" };
//Klant ik = new() { Familienaam = "Boulanger", Voornaam = "Martine" };
//Zichtrekening mijnRekening = new("BE03001447946884", 100m, new DateOnly(2020,1,1), ik, -10);
//Spaarrekening.Intrest = 0.01m;
//Spaarrekening mijnSpaar = new("BE40645100000163", 1000m, new DateOnly(2020, 1, 1), ik);
//// events initialiseren
//mijnRekening.RekeningUittreksel += bnp.RekeningUittrekselTonen;
//mijnRekening.RekeningUittreksel += bnp.RekeningInRoodMelding;
//mijnSpaar.RekeningUittreksel += bnp.RekeningUittrekselTonen;
//mijnSpaar.RekeningUittreksel += bnp.RekeningInRoodMelding;
//// zichtrekening
//Console.WriteLine("Zichtrekening: ");
//Console.WriteLine(mijnRekening.GetInfo());
//Console.WriteLine();
//Console.WriteLine("Storting");
//mijnRekening.Storten(50m);
//Console.WriteLine();
//Console.WriteLine("Afhalen");
//mijnRekening.Afhalen(100m);
//Console.WriteLine();
//Console.WriteLine("Afhalen"); // hier gaat de rekening in het rood staan
//mijnRekening.Afhalen(100m);
//Console.WriteLine();
//// spaarrekening
//Console.WriteLine("Spaarrekening: ");
//Console.WriteLine(mijnSpaar.GetInfo());
//Console.WriteLine();
//Console.WriteLine("Storting");
//mijnSpaar.Storten(2000m);
//Console.WriteLine();
//Console.WriteLine("Afhalen");
//mijnSpaar.Afhalen(1000m);
//Console.WriteLine();
//Console.WriteLine("Afhalen"); // hier gaat de rekening in het rood staan
//mijnSpaar.Afhalen(4000m);
//Console.WriteLine("------------------------------------------------------------------");

// 19. Lambda expressies
using CSharpPFOefeningen;
// array met getallen
//Console.WriteLine("------------------------------------------------------------------");
// lambda expression met de Func - kan ook met een delegate, maar vind dit gemakkelijker en logischer ook
// dit is mijn eigen oplossing - met Func zonder delegate voor de tekstkleur
//int[] getallen = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
//Func<int, bool> filterEvenGetallen = getal => getal % 2 == 0;
//Func<int, bool> filterOnEvenGetallen = getal => getal % 2 == 1;
// even getallen tonen
//foreach (var getal in getallen)
//{
//  Console.ForegroundColor = ConsoleColor.Green;
//  //if (filterEvenGetallen(getal)) Console.WriteLine($"{getal}: {filterEvenGetallen(getal)}");
//  if (filterEvenGetallen(getal)) Console.WriteLine(getal);
//  Console.ForegroundColor = ConsoleColor.White;
//}
//Console.WriteLine("------------------------------------------------------------------");
// oneven getallen tonen
//foreach (var getal in getallen)
//{
//  Console.ForegroundColor = ConsoleColor.Red;
//  //if (filterEvenGetallen(getal)) Console.WriteLine($"{getal}: {filterEvenGetallen(getal)}");
//  if (filterOnEvenGetallen(getal)) Console.WriteLine(getal);
//  Console.ForegroundColor = ConsoleColor.White;
//}
//Console.WriteLine("------------------------------------------------------------------");
// hier de voorbeeld oplossing van de leraar - eerst met Func
//Func<int, ConsoleColor> kleurEvenOneven = getal => getal % 2 == 0 ? ConsoleColor.Green : ConsoleColor.Red;
//Func<int, ConsoleColor> kleurPositiefNegatief = getal => getal < 0 ? ConsoleColor.Yellow : ConsoleColor.Blue;
//int[] getallen = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
//int[] getallen2 = [0, -1, 2, -3, 4, -5, 6, -7, 8, -9];
//// method om de getallen in de juiste kleur te tonen
//static void ToonGetallen(int[] getallen, Func<int, ConsoleColor> kleurGetal)
//{
//  foreach (var getal in getallen)
//  {
//    Console.ForegroundColor = kleurGetal(getal);
//    Console.WriteLine(getal);
//  }
//  Console.ForegroundColor = ConsoleColor.White;
//}
//ToonGetallen(getallen, kleurEvenOneven);
//ToonGetallen(getallen2, kleurPositiefNegatief);
Console.WriteLine("------------------------------------------------------------------");
// voorbeeld oplossing met delegate
KleurGetal kleurEvenOneven = getal => getal % 2 == 0 ? ConsoleColor.Green : ConsoleColor.Red;
KleurGetal kleurPositiefNegatief = getal => getal < 0 ? ConsoleColor.Yellow : ConsoleColor.Blue;
int[] getallen = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
int[] getallen2 = [0, -1, 2, -3, 4, -5, 6, -7, 8, -9];
static void ToonGetallen(int[] getallen, KleurGetal kleurGetal)
{
  foreach (var getal in getallen)
  {
    Console.ForegroundColor = kleurGetal(getal);
    Console.WriteLine(getal);
  }
  Console.ForegroundColor = ConsoleColor.White;
}
ToonGetallen(getallen, kleurEvenOneven);
ToonGetallen(getallen2, kleurPositiefNegatief);
Console.WriteLine("------------------------------------------------------------------");