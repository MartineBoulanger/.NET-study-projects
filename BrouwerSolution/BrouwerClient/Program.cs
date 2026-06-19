using BrouwerClient;
using System.Net;

// delete brouwer
//Console.Write("Id:");
//var id = int.Parse(Console.ReadLine()!);

// show all brouwers
//Console.Write("Druk op enter om de namen te zien");
//Console.ReadLine();

// zoek op het begin van de naam van de brouwer
//Console.Write("Begin van de naam:");
//var begin = Console.ReadLine();

// brouwer toevoegen
//Console.Write("Naam:");
//var naam = Console.ReadLine()!;
//Console.Write("Postcode:");
//var postcode = int.Parse(Console.ReadLine()!);
//Console.Write("Gemeente:");
//var gemeente = Console.ReadLine()!;
//var brouwer = new Brouwer() { Naam = naam, Postcode = postcode, Gemeente = gemeente };

// bewerk brouwer
Console.Write("Id:");
var id = int.Parse(Console.ReadLine()!);

using var client = new HttpClient();

// delete van een brouwer
//var response = await client.DeleteAsync($"http://localhost:5000/brouwers/{id}");

// opvragen van een brouwer
//var response = await client.GetAsync($"http://localhost:5000/brouwers/{id}");

// alle brouwers
//var response = await client.GetAsync("http://localhost:5000/brouwers");

// zoeken op brouwer met begin van de naam
//var response = await client.GetAsync($"http://localhost:5000/brouwers/naam?begin={begin}");

// bewerken van een brouwer
var uri = $"http://localhost:5000/brouwers/{id}";
var response = await client.GetAsync(uri);

switch (response.StatusCode)
{
    case HttpStatusCode.OK:
        // bericht bij verwijderen van brouwer
        //Console.WriteLine("Brouwer is vewijderd");
        //Console.WriteLine(brouwer.Naam);

        // weergeven van een brouwer
        //var brouwer = await response.Content.ReadAsAsync<Brouwer>();
        //Console.WriteLine(brouwer.Naam);

        // weergeven van alle brouwers
        //var brouwers = await response.Content.ReadAsAsync<List<Brouwer>>();
        //brouwers.ForEach(b => Console.WriteLine(b.Naam));

        // bewerken van een brouwer
        var brouwer = await response.Content.ReadAsAsync<Brouwer>();
        brouwer.Gemeente = brouwer.Gemeente.ToUpper();
        response = await client.PutAsJsonAsync(uri, brouwer);
        if (response.StatusCode == HttpStatusCode.OK)
            Console.WriteLine("Brouwer gewijzigd");
        else
            Console.WriteLine("Technisch probleem, contacteer de helpdesk");
        break;
    case HttpStatusCode.NotFound:
        Console.WriteLine("Brouwer niet gevonden");
        break;
    default:
        Console.WriteLine("Technisch probleem, contacteer de helpdesk");
        break;
}

// toevoegen van een brouwer
//var response = await client.PostAsJsonAsync("http://localhost:5000/brouwers", brouwer);
//if (response.StatusCode == HttpStatusCode.Created)
//{
//    Console.WriteLine($$"""
//        Brouwer is toegevoegd.
//        Zijn URI is {{response.Headers.Location}}
//        """);
//}
//else
//{
//    Console.WriteLine("Technisch probleem, contacteer de helpdesk.");
//}