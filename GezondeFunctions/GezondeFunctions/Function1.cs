using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace GezondeFunctions;

public class Function1
{
    [Function("randomGetal")]
    public IActionResult Random([HttpTrigger] HttpRequest request) => new OkObjectResult(new Random().Next(10));

    [Function("kwadraat")]
    public IActionResult Kwadraat([HttpTrigger(Route = "kwadraat/{getal:int}")] HttpRequest request, int getal) => new OkObjectResult(getal * getal);

    [Function("speciaalGetal")]
    public IActionResult SpeciaalGetal([HttpTrigger("post")][FromBody] SpeciaalGetal speciaalGetal) 
    {
        Console.WriteLine($"{speciaalGetal.Naam}: {speciaalGetal.Waarde}");
        return new OkObjectResult(null);
    }
}