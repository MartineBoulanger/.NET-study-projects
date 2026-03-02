// 1. Variabelen, constanten en bewerkingen
// 1.1 Conversie Celsius -> Fahrenheit
const float GemLichaamsTempCelsius = 37.0f;
float gemLichaamsTempFahrenheit = GemLichaamsTempCelsius * 9f / 5f + 32f;
Console.WriteLine($"Gemiddelde lichaamstemperatuur in Celsius: {GemLichaamsTempCelsius}");
Console.WriteLine($"Gemiddelde lichaamstemperatuur in Fahrenheit: {gemLichaamsTempFahrenheit}");
Console.WriteLine("------------------------------------------------------------------");
// 1.2 Omrekening seconden
int aantalSeconden = 23456;
const int aantalSecPerUur = 3600;
const int aantalSecPerMin = 60;
int uren, minuten, seconden, restSeconden;
uren = aantalSeconden / aantalSecPerUur;
restSeconden = aantalSeconden % aantalSecPerUur;
minuten = restSeconden / aantalSecPerMin;
seconden = restSeconden % aantalSecPerMin;
Console.WriteLine("U:" + uren + " M:" + minuten + " S:" + seconden);
Console.WriteLine("------------------------------------------------------------------");
// 1.3 Snoepautomaat
const decimal invoerMunt = 2m;
decimal bedrag = 1.67m;
int aantal1E, aantal50C, aantal20C, aantal10C, aantal5C, aantal2C, aantal1C;
decimal wisselgeld = invoerMunt - bedrag;
int wisselGeldInCenten = (int)(wisselgeld * 100);
aantal1E = wisselGeldInCenten / 100;
wisselGeldInCenten %= 100;
aantal50C = wisselGeldInCenten / 50;
wisselGeldInCenten %= 50;
aantal20C = wisselGeldInCenten / 20;
wisselGeldInCenten %= 20;
aantal10C = wisselGeldInCenten / 10;
wisselGeldInCenten %= 10;
aantal5C = wisselGeldInCenten / 5;
wisselGeldInCenten %= 5;
aantal2C = wisselGeldInCenten / 2;
aantal1C = wisselGeldInCenten % 2;
Console.WriteLine("Te betalen: " + bedrag + " euro");
Console.WriteLine("Wisselgeld: " + wisselgeld + " euro");
Console.WriteLine("Munten van 1 euro: " + aantal1E);
Console.WriteLine("Munten van 50 cent: " + aantal50C);
Console.WriteLine("Munten van 20 cent: " + aantal20C);
Console.WriteLine("Munten van 10 cent: " + aantal10C);
Console.WriteLine("Munten van 5 cent: " + aantal5C);
Console.WriteLine("Munten van 2 cent: " + aantal2C);
Console.WriteLine("Munten van 1 cent: " + aantal1C);
Console.WriteLine("------------------------------------------------------------------");
