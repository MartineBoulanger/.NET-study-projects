namespace DecoratorDesignPattern
{
    public class MetMelk(IKoffie gedecoreerdeKoffie):KoffieDecorator(gedecoreerdeKoffie)
    {
        public override decimal Kost() => base.GedecoreerdeKoffie.Kost() + 1m;
        public override string Bereidingswijze() => base.GedecoreerdeKoffie.Bereidingswijze() + ", warm de melk, voeg de melk toe";
    }
}
