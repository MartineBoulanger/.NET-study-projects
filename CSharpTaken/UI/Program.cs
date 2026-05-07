using Microsoft.EntityFrameworkCore;
using Model.Entities;
using var context = new EFTakenContext();

foreach (var klant in context.Klanten)
{
    Console.WriteLine(klant.Voornaam);
}

// logging van SQL statements
Console.WriteLine(context.Klanten.ToQueryString());
