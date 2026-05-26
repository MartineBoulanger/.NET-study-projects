using Model;

using var context = new EfbierenContext();

Console.WriteLine("-----------\nAlle Bieren\n-----------");
var bieren = context.Bieren.OrderBy(b => b.Naam).ToList();
foreach (var b in bieren)
{
    Console.WriteLine(b.Naam);
}
Console.WriteLine();
Console.WriteLine("-------------\nAlle Brouwers\n-------------");
var brouwers = context.Brouwers.OrderBy(b => b.BrNaam).ToList();
foreach (var br in brouwers)
{
    Console.WriteLine(br.BrNaam);
}