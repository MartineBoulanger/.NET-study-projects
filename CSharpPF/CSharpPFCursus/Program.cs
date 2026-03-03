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