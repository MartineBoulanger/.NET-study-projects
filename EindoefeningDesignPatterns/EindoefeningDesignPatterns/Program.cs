using EindoefeningDesignPatterns.Builder;
using EindoefeningDesignPatterns.Decorator;
using EindoefeningDesignPatterns.Facade;
using EindoefeningDesignPatterns.Inheritance;
using EindoefeningDesignPatterns.Singleton;

var facade = new KerstdagFacade();

// ----- Familie Hermans ----- //
Console.WriteLine(Kerstdag.GetInstance());
Console.WriteLine();
IKerstboom kerstboomHermans = new Slingers(new Lichtjes(new Ballen(new Kerstboom())));
Gezin hermans = new GezinBuilder()
    .SetNaam("Hermans")
    .VoegGezinslidToe("Opa", 85)
    .VoegGezinslidToe("Oma", 83)
    .SetKerstboom(kerstboomHermans)
    .VoegVerlichtingToe(new BinnenVerlichting())
    .VoegVerlichtingToe(new BuitenVerlichting())
    .Build();
facade.ToonGezin(hermans);
Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");

// ----- Familie Janssens ----- //
Console.WriteLine(Kerstdag.GetInstance());
Console.WriteLine();
IKerstboom kerstboomJanssens = new Lichtjes(new Ballen(new Kerstboom()));
Gezin janssens = new GezinBuilder()
    .SetNaam("Janssens")
    .VoegGezinslidToe("pa", 47)
    .VoegGezinslidToe("ma", 45)
    .VoegGezinslidToe("dochter", 13)
    .VoegGezinslidToe("zoon", 11)
    .SetKerstboom(kerstboomJanssens)
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
