using Microsoft.EntityFrameworkCore;
using Model.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using var context = new EFOpleidingenContext();
//foreach (var docent in context.Docenten)
//{
//    Console.WriteLine(docent.Naam);
//}

//Console.WriteLine("Minimum wedde:");
//if (decimal.TryParse(Console.ReadLine(), out decimal minWedde))
//{
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
//var query = from docent in context.Docenten group docent by docent.Voornaam into voornaamGroep select new { Voornaam = voornaamGroep.Key, Aantal = voornaamGroep.Count() };
//foreach (var voornaamStatistiek in query)
//{
//    Console.Write(voornaamStatistiek.Voornaam + ": ");
//    Console.WriteLine(voornaamStatistiek.Aantal + " keer.");
//}

// eager loading
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
//Console.WriteLine("Voornaam:");
//var voornaam = Console.ReadLine();
//var query = from docent in context.Docenten where docent.Voornaam == voornaam select docent;
//foreach (var docent in query)
//    Console.WriteLine("{0} : {1}", docent.Naam, docent.Campus.Naam);


// met de method ToList()
//List<Campus> campussen;
//var query = from campus in context.Campussen orderby campus.Naam select campus;
//campussen = query.ToList();
//foreach (var campus in campussen) Console.WriteLine(campus.Naam);
//Console.WriteLine();
//foreach (var campus in campussen) Console.WriteLine(campus.Naam);
//Console.WriteLine(query.ToQueryString());
// list doorgeven aan method
//foreach (var campus in FindAllCampussen())
//    Console.WriteLine(campus.Naam);
//List<Campus> FindAllCampussen()
//{
//    return (from campus in context.Campussen
//            orderby campus.Naam
//            select campus).ToList();
//}

// Entity toevoegen aan database
//var campus = new Campus { Naam = "Campus01", Straat = "Straat01", Huisnummer = "1", Postcode = "1111", Gemeente = "Gemeente01" };
//context.Campussen.Add(campus);
//context.SaveChanges(); // hier pas worden de wijzigingen in de database doorgevoerd
//Console.WriteLine(campus.CampusId);

// meerdere entiteiten toevoegen
//var campus2 = new Campus { Naam = "Campus02", Straat = "Straat02", Huisnummer = "2", Postcode = "2222", Gemeente = "Gemeente02" };
//var campus3 = new Campus { Naam = "Campus03", Straat = "Straat03", Huisnummer = "3", Postcode = "3333", Gemeente = "Gemeente03" };
//var campus4 = new Campus { Naam = "Campus04", Straat = "Straat04", Huisnummer = "4", Postcode = "4444", Gemeente = "Gemeente04" };
//var campus5 = new Campus { Naam = "Campus05", Straat = "Straat05", Huisnummer = "5", Postcode = "5555", Gemeente = "Gemeente05" };
//context.Campussen.AddRange(campus2, campus3);
//context.AddRange(new List<Campus> { campus4, campus5 });
//context.SaveChanges();

// meerdrere entiteiten toevoegen van verschillende types
//var campus6 = new Campus { Naam = "Campus06", Straat = "Straat06", Huisnummer = "6", Postcode = "6666", Gemeente = "Gemeente06" };
//var docent1 = new Docent { Familienaam = "Docent01", Voornaam = "Voornaam01", Wedde = 1111m, CampusId = 1, LandCode = "FR" };
//context.AddRange(campus6, docent1);
//context.SaveChanges();

// entiteiten met bijbehorende associaties toevoegen
//var campus7 = new Campus { Naam = "Campus07", Straat = "Straat07", Huisnummer = "7", Postcode = "7777", Gemeente = "Gemeente07" };
//var docent2 = new Docent { Familienaam = "Docent02", Voornaam = "Voornaam02", Wedde = 2222m, LandCode = "NL" };
//campus7.Docenten.Add(docent2);
//context.Campussen.AddRange(campus7);
//context.SaveChanges();

// tweede voorbeeld van entiteiten met bijbehorende associaties toevoegen
//var campus8 = new Campus { Naam = "Campus08", Straat = "Straat08", Huisnummer = "8", Postcode = "8888", Gemeente = "Gemeente08" };
//var docent3 = new Docent { Familienaam = "Docent03", Voornaam = "Voornaam03", Wedde = 3333m, LandCode = "IT" };
//docent3.Campus = campus8;
//context.Add(docent3);
//context.SaveChanges();

// nieuwe entiteit koppelen aan een bestaande entiteit
//var docent4 = new Docent { Voornaam = "Voornaam04", Familienaam = "Docent04", Wedde = 4444m, LandCode = "GB" };
// methode 1
//var campus1 = context.Campussen.Find(1);
//if (campus1 != null)
//{
//    context.Docenten.Add(docent4);
//    docent4.Campus = campus1;
//    context.SaveChanges();
//}
//else
//    Console.WriteLine("Campus 1 niet gevonden");
// methode 2
//var docent5 = new Docent { Voornaam = "Voornaam05", Familienaam = "Docent05", Wedde = 5555m, LandCode = "LU", CampusId = 1 };
//context.Docenten.Add(docent5);
//context.SaveChanges();

// vanuit de een-kant van de relatie -- de andere werken vanuit de veel-kant van de relatie
//var docent6 = new Docent { Voornaam = "Voornaam06", Familienaam = "Docent06", Wedde = 6666m, LandCode = "DE" };
//var campus1 = context.Campussen.Find(1);
//if (campus1 != null)
//{
//    campus1.Docenten.Add(docent6);
//    context.SaveChanges();
//}
//else
//    Console.WriteLine("Campus 1 niet gevonden");

// wijzigen van gegevens
// wijziging van 1 property waarde
//Console.Write("DocentNr: ");
//if (int.TryParse(Console.ReadLine(), out int docentNr))
//{
//    var docent = context.Docenten.Find(docentNr);
//    if (docent is not null)
//    {
//        Console.WriteLine("Wedde:{0}", docent.Wedde);
//        Console.Write(" Bedrag: ");
//        if (decimal.TryParse(Console.ReadLine(), out decimal bedrag))
//        {
//            docent.Opslag(bedrag);
//            context.SaveChanges();
//        }
//        else
//            Console.WriteLine("Tik een getal");
//    }
//    else
//        Console.WriteLine("Docent niet gevonden");
//}
//else
//    Console.WriteLine("Tik een getal");
// wijzigen van enkele gegevens terwijl alle gegevens worden opgeroepen
//Console.Write("Bovengrens: ");
//if (int.TryParse(Console.ReadLine(), out int grens))
//{
//    foreach (var docent in context.Docenten)
//        if (docent.Wedde <= grens)
//            docent.Opslag(100m);
//    context.SaveChanges();
//}
//else
//    Console.WriteLine("Tik een getal");

// wijzigen van enititeiten rechtstreeks in de database
//Console.Write("DocentNr: ");
//if (int.TryParse(Console.ReadLine(), out int docentNr))
//{
//    Console.Write("Bedrag: ");
//    if (decimal.TryParse(Console.ReadLine(), out decimal bedrag))
//    {
//        context.Docenten.Where(d => d.DocentId == docentNr).ExecuteUpdate(d => d.SetProperty(p => p.Wedde, p => p.Wedde + bedrag));
//    }
//    else
//        Console.WriteLine("Tik een getal");
//}
//else
//    Console.WriteLine("Tik een getal");

// entiteit wijzigen die inderect geassocieerd is met de entiteit die we opvragen
//var campus1 = context.Campussen.Include(c => c.Docenten).FirstOrDefault(c => c.CampusId == 1);
//if (campus1 != null) { foreach (var docent in campus1.Docenten) docent.Opslag(10m); context.SaveChanges(); }

// associaties wijzigen
// manier 1
//var docent1 = context.Docenten.Find(1);
//if (docent1 is not null)
//{
//    var campus6 = context.Campussen.Find(6);
//    if (campus6 is not null)
//    {
//        docent1.Campus = campus6;
//        context.SaveChanges();
//    }
//    else
//        Console.WriteLine("Campus 6 niet gevonden");
//}
//else
//    Console.WriteLine("Docent 1 is niet gevonden");
// manier 2 dmv de FK
//var docent1 = context.Docenten.Find(1);
//if (docent1 is not null)
//{
//    docent1.CampusId = 2;
//    context.SaveChanges();
//}
//else
//    Console.WriteLine("Docent 1 is niet gevonden");
// het verhuizen van docent naar een andere campus - de een-kant relatie wijziging
//var docent1 = context.Docenten.Find(1);
//if (docent1 is not null)
//{
//    var campus3 = context.Campussen.Find(3);
//    if (campus3 is not null)
//    {
//        campus3.Docenten.Add(docent1);
//        context.SaveChanges();
//    }
//    else
//        Console.WriteLine("Campus 3 niet gevonden");
//}
//else
//    Console.WriteLine("Docent 1 is niet gevonden");

// een entiteit verwijderen
//Console.Write("DocentNr: ");
//if (int.TryParse(Console.ReadLine(), out int docentNr))
//{
//    var docent = context.Docenten.Find(docentNr);
//    if (docent != null)
//    {
//        context.Docenten.Remove(docent);
//        context.SaveChanges();
//    }
//    else
//        Console.WriteLine("Docent niet gevonden");
//}
//else
//    Console.WriteLine("Tik een getal");

// een entiteit verwijderen rechtstreeks in de database
//Console.Write("DocentNr: ");
//if (int.TryParse(Console.ReadLine(), out int docentNr))
//{
//    context.Docenten.Where(d => d.DocentId == docentNr).ExecuteDelete();
//}
//else
//    Console.WriteLine("Tik een getal");

// een land verwijderen om te kijken of de geassocieerde docenten ook worden aangepast
//var duitsland = context.Landen.Find("DE");
//if (duitsland != null)
//{
//    context.Landen.Remove(duitsland);
//    context.SaveChanges();
//}

// Owned types
//var genk = context.Campussen.Find(3);
//if (genk != null)
//{
//    genk.Adres.Straat = "Thor Park";
//    genk.Adres.Huisnummer = "8040";
//    context.SaveChanges();
//}

// TPH - Table Per Hierarchy
//context.TPHCursussen.Add(new TPHKlassikaleCursus { Naam = "Frans in 24 uur", Van = DateTime.Today, Tot = DateTime.Today });
//context.TPHCursussen.Add(new TPHZelfstudieCursus { Naam = "Engels in 24 uur", AantalDagen = 1 });
//context.SaveChanges();

// TPT - Table Per Type
//context.TPTCursussen.Add(new TPTKlassikaleCursus { Naam = "Frans in 24 uur", Van = DateTime.Today, Tot = DateTime.Today });
//context.TPTCursussen.Add(new TPTZelfstudieCursus { Naam = "Engels in 24 uur", AantalDagen = 1 });
//context.SaveChanges();

// TPC - Table Per Concrete Type
//context.TPCCursussen.Add(new TPCKlassikaleCursus { Naam = "Frans in 24 uur", Van = DateTime.Today, Tot = DateTime.Today });
//context.TPCCursussen.Add(new TPCZelfstudieCursus { Naam = "Engels in 24 uur", AantalDagen = 1 });
//context.SaveChanges();

// speciale associaties - veel-op-veel zonder tussen klasse
//var query = from cursus in context.Cursussen.Include(c => c.Boeken) orderby cursus.Naam select cursus;
//foreach (var cursus in query)
//{
//    Console.WriteLine(cursus.Naam);
//    foreach (var boek in cursus.Boeken)
//    {
//        Console.WriteLine("\t{0} ({1})", boek.Titel, boek.IsbnNr);
//    }
//}
// data toevoegen
//var nieuwBoek = new Boek { IsbnNr = "0-201-70431-5", Titel = "Modern C++ Design" };
//context.Boeken.Add(nieuwBoek);
//context.Cursussen.Include(c => c.Boeken).Where(c => c.Naam == "C++").FirstOrDefault()?.Boeken.Add(nieuwBoek);
//context.SaveChanges();
//var query = from cursus in context.Cursussen.Include(c => c.Boeken) orderby cursus.Naam select cursus;
//foreach (var cursus in query)
//{
//    Console.WriteLine(cursus.Naam);
//    foreach (var boek in cursus.Boeken)
//    {
//        Console.WriteLine("\t{0} ({1})", boek.Titel, boek.IsbnNr);
//    }
//}

// veel-op-vel relatie met tussen klasse
var campus = new Campus
{
    Naam = "CC Roeselare ",
    Adres = new Adres
    {
        Straat = " Pilders weg",
        Huisnummer = " 7",
        Postcode = " 88 00",
        Gemeente = " Roeselare "
    }
};
var jean = new Docent
{
    Voornaam = "Jean",
    Familienaam = "Smits",
    Wedde = 1000,
    InDienst = new DateTime(1966, 8, 1),
    HeeftRijbewijs = true,
    ThuisAdres = new Adres
    {
        Straat = "Keizerslaan",
        Huisnummer = "11",
        Postcode = "1000",
        Gemeente = "Brussel"
    },
    LandCode = "BE",
    Campus = campus
};
var kiekeboe = new Docent
{
    Voornaam = "Marcel",
    Familienaam = "Kiekeboe",
    Wedde = 500,
    InDienst = new DateTime(1948, 10, 24),
    HeeftRijbewijs = true,
    ThuisAdres = new Adres
    {
        Straat = "Merholaan",
        Huisnummer = "1B",
        Postcode = "3000",
        Gemeente = "Zoersel"
    },
    LandCode = "BE",
    Campus = campus
};
var activiteit1 = new Activiteit { Naam = "EHBO" };
var activiteit2 = new Activiteit { Naam = "Vergaderen" };
var activiteit3 = new Activiteit { Naam = "Overleggen" };
var activiteit4 = new Activiteit { Naam = "Studie" };

context.Campussen.Add(campus);
context.SaveChanges();
context.Docenten.Add(jean);
context.Docenten.Add(kiekeboe);
context.SaveChanges();
context.Activiteiten.Add(activiteit1);
context.Activiteiten.Add(activiteit2);
context.Activiteiten.Add(activiteit3);
context.Activiteiten.Add(activiteit4);
context.SaveChanges();

var da1 = new DocentActiviteit
{
    DocentId = jean.DocentId,
    ActiviteitId = activiteit2.ActiviteitId,
    AantalUren = 4
};
var da2 = new DocentActiviteit
{
    DocentId = jean.DocentId,
    ActiviteitId = activiteit3.ActiviteitId,
    AantalUren = 1
};
var da3 = new DocentActiviteit
{
    DocentId = kiekeboe.DocentId,
    ActiviteitId = activiteit4.ActiviteitId,
    AantalUren = 4
};
var da4 = new DocentActiviteit
{
    DocentId = kiekeboe.DocentId,
    ActiviteitId = activiteit1.ActiviteitId,
    AantalUren = 1
};
var da5 = new DocentActiviteit
{
    DocentId = kiekeboe.DocentId,
    ActiviteitId = activiteit2.ActiviteitId,
    AantalUren = 2
};

context.AddRange(da1, da2, da3, da4, da5);
context.SaveChanges();

var docent = context.Docenten.Include("DocentenActiviteiten.Activiteit").Where(d => d.DocentId == 4).FirstOrDefault();
docent.DocentenActiviteiten.Add(new DocentActiviteit { ActiviteitId = 3, AantalUren = 6 });
context.SaveChanges();

foreach (var d in context.Docenten.Include("DocentenActiviteiten.Activiteit"))
{
    Console.WriteLine(d.Naam);
    if (d.DocentenActiviteiten.Count == 0)
        Console.WriteLine("\tGeen activiteiten");
    else
        foreach (var da in d.DocentenActiviteiten)
            Console.WriteLine("\t{0} {1} uur",
            da.Activiteit.Naam, da.AantalUren);
    Console.WriteLine();
}