using CompositeDesignPattern;

Tekening hoofdtekening = new();
hoofdtekening.Add(new Rechthoek(2, 1));
hoofdtekening.Add(new Cirkel(3));
Tekening subtekening = new();
subtekening.Add(new Rechthoek(3, 2));
subtekening.Add(new Cirkel(4));
hoofdtekening.Add(subtekening);
Console.WriteLine(hoofdtekening.Oppervlakte());
Console.WriteLine();

// oefening
Project project = new();
project.AddKost(new GrondstofKost(1000m, 3m));
project.AddKost(new Arbeidskost(10m, 100m));
Project subProject = new();
subProject.AddKost(new GrondstofKost(1000m, 4m));
subProject.AddKost(new Arbeidskost(10m, 200m));
project.AddKost(subProject);
Console.WriteLine(project.Bedrag);