namespace DecoratorDesignPattern
{
    public class MetChocolade(IKoffie gedecoreerdeKoffie):KoffieDecorator(gedecoreerdeKoffie)
    {
        public override decimal Kost() => base.GedecoreerdeKoffie.Kost() + 2m;
        public override string Bereidingswijze() => base.GedecoreerdeKoffie.Bereidingswijze() + ", schilfer de chocolade, voed de schilfers toe";
    }
}
