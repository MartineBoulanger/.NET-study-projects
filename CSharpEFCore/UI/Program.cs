using Model.Entities;
//using var context = new EFOpleidingenContext();
//foreach (var docent in context.Docenten)
//{
//    Console.WriteLine(docent.Naam);
//}

//Console.WriteLine("Minimum wedde:");
//if (decimal.TryParse(Console.ReadLine(), out decimal minWedde))
//{
//    using var context = new EFOpleidingenContext();
//    //var query = from docent in context.Docenten where docent.Wedde >= minWedde orderby docent.Voornaam, docent.Familienaam select docent;
//    var query = context.Docenten.Where(d => d.Wedde >= minWedde).OrderBy(d => d.Voornaam).ThenBy(d => d.Familienaam); // met de query-methods
//    foreach (var d in query)
//        Console.WriteLine("{0}: {1}", d.Naam, d.Wedde);
//    //Console.WriteLine(query.ToQueryString()); //to check out the SQL statement that EF has used
//}
//else
//    Console.WriteLine("Geef een getal in");

// laat de gebruiker zelf kiezen hoe hij de docent wilt sorteren
// volledige versie, maar met repeat van LINQ queries
//Console.WriteLine("Minimum wedde:");
//if (decimal.TryParse(Console.ReadLine(), out decimal minWedde))
//{
//    Console.Write("Sorteren: 1 = op wedde, 2 = op familienaam, 3 = op voornaam :");
//    var sorterenOp = Console.ReadLine();
//    using var context = new EFOpleidingenContext();
//    IQueryable<Docent> query;
//    switch (sorterenOp)
//    {
//        case "1":
//            query = from docent in context.Docenten where docent.Wedde >= minWedde orderby docent.Wedde select docent;
//            break;
//        case "2":
//            query = from docent in context.Docenten where docent.Wedde >= minWedde orderby docent.Familienaam select docent;
//            break;
//        case "3":
//            query = from docent in context.Docenten where docent.Wedde >= minWedde orderby docent.Voornaam select docent;
//            break;
//        default:
//            Console.WriteLine("Verkeerde keuze");
//            query = null!;
//            break;
//    }
//    if (query != null)
//        foreach (var d in query)
//            Console.WriteLine("{0}: {1}", d.Naam, d.Wedde);
//}
//else
//    Console.WriteLine("Geef een getal in");

// met query-methods maar bevat maar 1 query-definitie
Console.WriteLine("Minimum wedde:");
if (decimal.TryParse(Console.ReadLine(), out decimal minWedde))
{
    Console.Write("Sorteren: 1 = op wedde, 2 = op familienaam, 3 = op voornaam :");
    var sorterenOp = Console.ReadLine();
    Func<Docent, Object> sorteerLambda;
    switch (sorterenOp)
    {
        case "1":
            sorteerLambda = (d) => d.Wedde;
            break;
        case "2":
            sorteerLambda = (d) => d.Familienaam;
            break;
        case "3":
            sorteerLambda = (d) => d.Voornaam;
            break;
        default:
            Console.WriteLine("Verkeerde keuze");
            sorteerLambda = null!;
            break;
    }
    if (sorteerLambda != null)
    {
        using var context = new EFOpleidingenContext();
        var query = context.Docenten.Where(d => d.Wedde >= minWedde).OrderBy(sorteerLambda);
        foreach (var d in query)
            Console.WriteLine("{0}: {1}", d.Naam, d.Wedde);
    }
}
else
    Console.WriteLine("Geef een getal in");

// logging van SQL statements
//Console.WriteLine(context.Docenten.ToQueryString());
