using Microsoft.EntityFrameworkCore;
using Model.Entities;
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
//    if (klant is null) Console.WriteLine(" Klant niet gevonden");
//    else
//    {
//        Console.WriteLine("Geef het nieuwe rekeningnummer: ");
//        var nieuwRekeningNr = Console.ReadLine();
//        var rekening = new Rekening { RekeningNr = nieuwRekeningNr, Saldo = 0m, Soort = 'Z', Klant = klant };
//        context.Rekeningen.Add(rekening);
//        context.SaveChanges();
//    }
//}
//else Console.WriteLine("Dit is geen getal");

// Oefening hoofdstuk 8 - blz. 75
Console.Write("RekeningNr.: ");
var rekeningNr = Console.ReadLine();
var rekening = context.Rekeningen.Find(rekeningNr);
if (rekening is null) Console.WriteLine("Rekening niet gevonden");
else
{
    Console.Write("Bedrag: ");
    if (decimal.TryParse(Console.ReadLine(), out var bedrag))
    {
        if (bedrag <= Decimal.Zero) Console.WriteLine("Tik een positief bedrag");
        else
        {
            rekening.Storten(bedrag);
            context.SaveChanges();
        }
    }
    else Console.WriteLine("Tik een bedrag");
}