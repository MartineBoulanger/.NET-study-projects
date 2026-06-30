using StrategyDesignPattern;

Persoon[] personen = 
[
    new("Jean", "Smits", "heer"),
    new("Jeanine", "Desmet", "mevrouw")
];
// briefhoofdingen met informele aansprekingen:
foreach (Persoon persoon in personen) Console.WriteLine(persoon.MaakBriefHoofding((pers) => "Dag " + pers.Voornaam));
// briefhoofdingen met formele aansprekingen:
foreach (Persoon persoon in personen) Console.WriteLine(persoon.MaakBriefHoofding((pers) => "Geachte " + pers.Titel + " " + pers.Familienaam));

Console.WriteLine("--------------------");

// oefening
Vervoer vervoer = new();
Console.WriteLine(vervoer.DoeEenOversteek(() => "Schaatsen want het is koud"));
Console.WriteLine();
Console.WriteLine(vervoer.DoeEenOversteek(() => "Zeilen want er is veel wind"));
Console.WriteLine();
Console.WriteLine(vervoer.DoeEenOversteek(() => "Met de motorboot want het is warm en er isg een wind"));