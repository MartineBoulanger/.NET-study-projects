using BuilderDesignPattern;

Inwoner.InwonerBuilder builder = new Inwoner.InwonerBuilder();
Inwoner inwoner = builder.MetVoornaam("Olivier")
    .MetFamilienaam("Gerard")
    .MetAantalKinderen(1)
    .MetAantalKeerVerhuisd(3)
    .MetGehuwd(true)
    .MetGescheiden(false)
    .MaakInwoner();
Console.WriteLine(inwoner);
Console.WriteLine();
// oefening
Coordinator.CoordinatorBuilder build = new Coordinator.CoordinatorBuilder();
Coordinator coord = build.MetX(135).MetY(75).MetZ(22).MaakCoordinator();
Console.WriteLine(coord.ToString());
