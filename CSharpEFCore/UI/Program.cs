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
//Console.WriteLine("Minimum wedde:");
//if (decimal.TryParse(Console.ReadLine(), out decimal minWedde))
//{
//    Console.Write("Sorteren: 1 = op wedde, 2 = op familienaam, 3 = op voornaam :");
//    var sorterenOp = Console.ReadLine();
//    Func<Docent, Object> sorteerLambda;
//    switch (sorterenOp)
//    {
//        case "1":
//            sorteerLambda = (d) => d.Wedde;
//            break;
//        case "2":
//            sorteerLambda = (d) => d.Familienaam;
//            break;
//        case "3":
//            sorteerLambda = (d) => d.Voornaam;
//            break;
//        default:
//            Console.WriteLine("Verkeerde keuze");
//            sorteerLambda = null!;
//            break;
//    }
//    if (sorteerLambda != null)
//    {
//        using var context = new EFOpleidingenContext();
//        var query = context.Docenten.Where(d => d.Wedde >= minWedde).OrderBy(sorteerLambda);
//        foreach (var d in query)
//            Console.WriteLine("{0}: {1}", d.Naam, d.Wedde);
//    }
//}
//else
//    Console.WriteLine("Geef een getal in");

// logging van SQL statements
//Console.WriteLine(context.Docenten.ToQueryString());

// Zoeken met Find op PK
//using var context = new EFOpleidingenContext();
//Console.Write("DocentNr.:");
//if (int.TryParse(Console.ReadLine(), out int docentNr))
//{
//    var docent = context.Docenten.Find(docentNr);
//    Console.WriteLine(docent == null ? "Niet gevonden" : docent.Naam);
//}
//else
//    Console.WriteLine("U tikte geen getal");

// alleen kolommen opvragen die nodig zijn
//var query = from campus in context.Campussen orderby campus.Naam select new { campus.CampusId, campus.Naam };
//var query = context.Campussen.OrderBy(campus => campus.Naam).Select(campus => new { campus.CampusId, campus.Naam });
//Console.WriteLine(query.ToQueryString()); foreach (var campusDeel in query)
//Console.WriteLine("{0}: {1}", campusDeel.CampusId, campusDeel.Naam);

// Groeperen en aggregeren
//using var context = new EFOpleidingenContext();
//var query = from docent in context.Docenten group docent by docent.Voornaam into voornaamGroep select new { Voornaam = voornaamGroep.Key, Aantal = voornaamGroep.Count() };
//foreach (var voornaamStatistiek in query)
//{
//    Console.Write(voornaamStatistiek.Voornaam + ": ");
//    Console.WriteLine(voornaamStatistiek.Aantal + " keer.");
//}

// eager loading
//using var context = new EFOpleidingenContext();
//Console.Write("Voornaam:");
//var voornaam = Console.ReadLine();
//var query = from docent in context.Docenten.Include("Campus") where docent.Voornaam == voornaam select docent;
//foreach (var docent in query)
//    Console.WriteLine("{0} : {1}", docent.Naam, docent.Campus.Naam);
//Console.Write("Geef (een deel van) de naam van de campus:");
//var deelNaam = Console.ReadLine();
//var query2 = from campus in context.Campussen.Include(c => c.Docenten) where campus.Naam.Contains(deelNaam) orderby campus.Naam select campus;
//var query2 = context.Campussen.Include(c => c.Docenten).Where(campus => campus.Naam.Contains(deelNaam)).OrderBy(campus => campus.Naam);
//foreach (var campus in query2)
//{
//    var campusNaam = campus.Naam;
//    Console.WriteLine(campusNaam);
//    Console.WriteLine(new string('-', campusNaam.Length));
//    foreach (var docent in campus.Docenten)
//        Console.WriteLine(docent.Naam);
//    Console.WriteLine();
//}

// lazy loading
//using var context = new EFOpleidingenContext();
//Console.WriteLine("Voornaam:");
//var voornaam = Console.ReadLine();
//var query = from docent in context.Docenten where docent.Voornaam == voornaam select docent;
//foreach (var docent in query)
//    Console.WriteLine("{0} : {1}", docent.Naam, docent.Campus.Naam);


// met de method ToList()
//List<Campus> campussen;
//using var context = new EFOpleidingenContext();
//var query = from campus in context.Campussen orderby campus.Naam select campus;
//campussen = query.ToList();
//foreach (var campus in campussen) Console.WriteLine(campus.Naam);
//Console.WriteLine();
//foreach (var campus in campussen) Console.WriteLine(campus.Naam);
//Console.WriteLine(query.ToQueryString());
// list doorgeven aan method
foreach (var campus in FindAllCampussen())
    Console.WriteLine(campus.Naam);
List<Campus> FindAllCampussen()
{
    using var context = new EFOpleidingenContext();
    return (from campus in context.Campussen
            orderby campus.Naam
            select campus).ToList();
}