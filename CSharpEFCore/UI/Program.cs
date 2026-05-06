using Model.Entities;
using var context = new EFOpleidingenContext();

foreach (var docent in context.Docenten)
{
    Console.WriteLine(docent.Naam);
}

// logging van SQL statements
//Console.WriteLine(context.Docenten.ToQueryString());
