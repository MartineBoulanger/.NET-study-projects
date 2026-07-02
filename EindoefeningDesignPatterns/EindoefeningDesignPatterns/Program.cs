using EindoefeningDesignPatterns.Builder;
using EindoefeningDesignPatterns.Decorator;
using EindoefeningDesignPatterns.Facade;
using EindoefeningDesignPatterns.Inheritance;
using EindoefeningDesignPatterns.Singleton;

var facade = new KerstdagFacade();
IKerstboom boom = new Kerstboom();

// ----- Familie Hermans ----- //
Console.WriteLine(Kerstdag.GetInstance());
Console.WriteLine();
Gezin hermans = new GezinBuilder()
    .SetNaam("Hermans")
    .VoegGezinslidToe("Opa", 85)
    .VoegGezinslidToe("Oma", 83)
    .SetKerstboom(new Slingers(new Lichtjes(new Ballen(boom))))
    .VoegVerlichtingToe(new BinnenVerlichting())
    .VoegVerlichtingToe(new BuitenVerlichting())
    .Build();
facade.ToonGezin(hermans);

Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");

// ----- Familie Janssens ----- //
Console.WriteLine(Kerstdag.GetInstance());
Console.WriteLine();
Gezin janssens = new GezinBuilder()
    .SetNaam("Janssens")
    .VoegGezinslidToe("pa", 47)
    .VoegGezinslidToe("ma", 45)
    .VoegGezinslidToe("dochter", 13)
    .VoegGezinslidToe("zoon", 11)
    .SetKerstboom(new Lichtjes(new Ballen(boom)))
    .VoegVerlichtingToe(new BinnenVerlichting())
    .Build();
facade.ToonGezin(janssens);

Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");

// ----- Familie Peeters ----- //
Console.WriteLine(Kerstdag.GetInstance());
Console.WriteLine();
Gezin peeters = new GezinBuilder()
    .SetNaam("Peeters")
    .VoegGezinslidToe("ma", 55)
    .VoegGezinslidToe("zoon", 25)
    .VoegVerlichtingToe(new BuitenVerlichting())
    .Build();
facade.ToonGezin(peeters);

Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");
