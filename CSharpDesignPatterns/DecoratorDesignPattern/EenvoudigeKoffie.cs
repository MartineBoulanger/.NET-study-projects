namespace DecoratorDesignPattern
{
    public class EenvoudigeKoffie : IKoffie
    {
        public string Bereidingswijze() => "maal de koffiebonen, laat kokend water over het poeder lopen";

        public decimal Kost() => 3m;
    }
}
