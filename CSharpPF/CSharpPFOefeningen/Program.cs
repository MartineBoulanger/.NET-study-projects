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
//using System.Text;
//Console.WriteLine("------------------------------------------------------------------");
//const string ALFABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
//string ibanNr, controleNr;
//ulong rest97;
//Console.Write("Geef het IBAN nummer in om te controle of het geldig is: ");
//ibanNr = Console.ReadLine() ?? "";
//controleNr = ibanNr.Trim().Replace(" ", "");
//controleNr = controleNr.Substring(4) + controleNr.Substring(0, 4);
//if (controleNr.Length == 16)
//{    
//    StringBuilder nr = new StringBuilder();
//    char teken;
//    for (int teller = 0; teller < controleNr.Length; teller++)
//    {
//        teken = controleNr[teller];
//        if (char.IsLetter(teken)) nr.Append(ALFABET.IndexOf(teken) + 10);
//        else nr.Append(teken);
//    }
//    rest97 = ulong.Parse(nr.ToString()) % 97ul;
//    if (rest97 == 1) Console.WriteLine("Dit is een geldig IBAN nummer");
//    else Console.WriteLine("Dit is geen geldig IBAN nummer");
//}
//else
//{
//    Console.WriteLine($"{ibanNr} is geen rekening nummer.");
//};
//Console.WriteLine("------------------------------------------------------------------");

// 5. 