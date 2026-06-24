namespace SingletonDesignPattern
{
    public sealed class Magic8Ball
    {
        private static readonly Lazy<Magic8Ball> _lazyInstantie = new(() => new Magic8Ball());
        private static readonly string[] antwoorden = [
            "Zoals ik het zie, ja." ,
            "Het is zeker." ,
            "Hoogst waarschijnlijk." ,
            "Ziet er goed uit." ,
            "Zonder twijfel." ,
            "Ja." ,
            "Zeker." ,
            "Je mag er op rekenen." ,
            "Vraag dit later nog eens." ,
            "Dit wil je niet weten." ,
            "Ik kan dit nu niet voorspellen." ,
            "Concentreer je en stel je vraag opnieuw." ,
            "Je moet er niet op rekenen." ,
            "Nee." ,
            "Ziet er niet goed uit." ,
            "Zeer twijfelachtig."
        ];
        private string laatsteAntwoord = "";
        private Magic8Ball() { }
        public static Magic8Ball GetInstance() => _lazyInstantie.Value;
        public string GeefVoorspelling()
        {
            string antwoord;
            Random random = new();
            do
            {
                antwoord = antwoorden[random.Next(0, 16)];
            }
            while (antwoord == laatsteAntwoord);
            laatsteAntwoord = antwoord;
            return antwoord;
        }
    }
}
