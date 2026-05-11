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
var query = from klant in context.Klanten.Include(k => k.Rekeningen) orderby klant.Voornaam select klant;
foreach (var klant in query)
{
    Console.WriteLine(klant.Voornaam);
    var totaleSaldo = Decimal.Zero;
    foreach (var rekening in klant.Rekeningen)
    {
        Console.WriteLine("{0}: {1}", rekening.RekeningNr, rekening.Saldo);
        totaleSaldo += rekening.Saldo;
    }
    Console.WriteLine("Totaal: {0}", totaleSaldo);
    Console.WriteLine();
}