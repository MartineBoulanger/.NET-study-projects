using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Model.Entities;
using System.Transactions;
using var context = new EFTakenContext();

//foreach (var klant in context.Klanten)
//{
//    Console.WriteLine(klant.Voornaam);
//}

// logging van SQL statements
//Console.WriteLine(context.Klanten.ToQueryString());


// Oefening hoofdstuk 6 - blz. 64
//var query = from klant in context.Klanten.Include(k => k.Rekeningen) orderby klant.Voornaam select klant;
//foreach (var klant in query)
//{
//    Console.WriteLine(klant.Voornaam);
//    var totaleSaldo = Decimal.Zero;
//    foreach (var rekening in klant.Rekeningen)
//    {
//        Console.WriteLine("{0}: {1}", rekening.RekeningNr, rekening.Saldo);
//        totaleSaldo += rekening.Saldo;
//    }
//    Console.WriteLine("Totaal: {0}", totaleSaldo);
//    Console.WriteLine();
//}

// Oefening hoofdstuk 7 - blz. 70
//Console.WriteLine("Klantenlijst");
//foreach (var klant in context.Klanten.OrderBy(k => k.Voornaam)) Console.WriteLine("{0}: {1}", klant.KlantNr, klant.Voornaam);
//Console.WriteLine();
//Console.Write("KlantNr: ");
//if (int.TryParse(Console.ReadLine(), out int klantNr))
//{
//    var klant = context.Klanten.Find(klantNr);
//    if (klant is null)
//        Console.WriteLine(" Klant niet gevonden");
//    else
//    {
//        Console.WriteLine("Geef het nieuwe rekeningnummer: ");
//        var nieuwRekeningNr = Console.ReadLine();
//        var rekening = new Rekening { RekeningNr = nieuwRekeningNr, Saldo = 0m, Soort = 'Z', Klant = klant };
//        context.Rekeningen.Add(rekening);
//        context.SaveChanges();
//    }
//}
//else
//    Console.WriteLine("Dit is geen getal");

// Oefening hoofdstuk 8 - blz. 75
//Console.Write("RekeningNr.: ");
//var rekeningNr = Console.ReadLine();
//var rekening = context.Rekeningen.Find(rekeningNr);
//if (rekening is null)
//    Console.WriteLine("Rekening niet gevonden");
//else
//{
//    Console.Write("Bedrag: ");
//    if (decimal.TryParse(Console.ReadLine(), out var bedrag))
//    {
//        if (bedrag <= Decimal.Zero)
//            Console.WriteLine("Tik een positief bedrag");
//        else
//        {
//            rekening.Storten(bedrag);
//            context.SaveChanges();
//        }
//    }
//    else
//        Console.WriteLine("Tik een bedrag");
//}

// Oefening Hoofdstuk 9 - blz. 80
//Console.Write("KlantNr: ");
//if (int.TryParse(Console.ReadLine(), out var klantNr))
//{
//    var klant = context.Klanten.Include(r => r.Rekeningen).FirstOrDefault(k => k.KlantNr == klantNr);
//    if (klant is null)
//        Console.WriteLine("Klant niet gevonden");
//    else
//    {
//        if (klant.Rekeningen.Count > 0)
//            Console.WriteLine("Klant heeft nog rekeningen staan");
//        else
//        {
//            context.Klanten.Remove(klant);
//            context.SaveChanges();
//        }
//    }
//}
//else
//    Console.WriteLine("Geen getal ingebracht");

// Oefening 1 Hoofdstuk 12 - blz. 104
//var hoogstenInHierarchie =
//    (from personeelslid in context.PersoneelsLeden
//     where personeelslid.Manager == null
//     select personeelslid).ToList();
//Afbeelden(hoogstenInHierarchie, 0);
//void Afbeelden(List<Personeelslid> personeel, int insprong)
//{
//    foreach (var personeelslid in personeel)
//    {
//        Console.Write(new String('\t', insprong));
//        Console.WriteLine(personeelslid.Voornaam);
//        if (personeelslid.Ondergeschikten.Count != 0)
//            Afbeelden(personeelslid.Ondergeschikten.ToList(), insprong + 1);
//    }
//}

// Oefening 2 Hoofstuk 12 - blz. 105
//var soepterrine = new NonFoodArtikel { Naam = "Villeroy & Boch", Garantie = 24 };
//var grasmachine = new NonFoodArtikel { Naam = "SABO 40-spirit", Garantie = 60 };
//var frietpatatjes = new FoodArtikel { Naam = "Frietaardappelen 5kg", Houdbaarheid = 1 };
//var tuin = new ArtikelGroep { Naam = "Tuinartikelen" };
//var keuken = new ArtikelGroep { Naam = "Keukenartikelen" };
//tuin.Artikels.Add(grasmachine);
//keuken.Artikels.Add(soepterrine);
//keuken.Artikels.Add(frietpatatjes);
//context.ArtikelGroepen.Add(tuin);
//context.ArtikelGroepen.Add(keuken);
//context.SaveChanges();

// Oefening hoofdstuk 14 - blz. 124
//Console.Write("RekeningNr. van rekening: ");
//var vanRekeningNr = Console.ReadLine();
//Console.Write("RekeningNr. naar rekening: ");
//var naarRekeningNr = Console.ReadLine();
//try
//{
//    Console.Write("Bedrag: ");
//    var bedrag = decimal.Parse(Console.ReadLine());
//    if (bedrag <= decimal.Zero) Console.WriteLine("Tik een positief bedrag");
//    else
//    {
//        var transactionOptions = new TransactionOptions { IsolationLevel = IsolationLevel.RepeatableRead };
//        using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);

//        var vanRekening = context.Rekeningen.Find(vanRekeningNr);

//        if (vanRekening is null) Console.WriteLine("Van rekening niet gevonden");
//        else
//        {
//            var naarRekening = context.Rekeningen.Find(naarRekeningNr);
//            if (naarRekening is null) Console.WriteLine("Naar rekening niet gevonden");
//            else
//            {
//                try
//                {
//                    vanRekening.Overschrijven(naarRekening, bedrag);
//                    context.SaveChanges();
//                    transactionScope.Complete();
//                }
//                catch (Exception ex) { Console.WriteLine(ex.Message); }
//            }
//        }
//    }
//}
//catch (FormatException) { Console.WriteLine("Ongeldig bedrag"); }

// Oefening hoofdstuk 16 - blaz. 129
Console.Write("KlantNr: ");
try
{
    var klantNr = int.Parse(Console.ReadLine());
    var klant = context.Klanten.Find(klantNr);
    if (klant == null) Console.WriteLine("Klant niet gevonden");
    else
    {
        Console.Write("Voornaam: ");
        klant.Voornaam = Console.ReadLine();
        context.SaveChanges();
    }
}
catch (DbUpdateConcurrencyException) { Console.WriteLine("Een andere gebruiker wijzigde deze klant"); }
catch (FormatException) { Console.WriteLine("Ongeldig klantnummer"); }