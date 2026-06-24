namespace FactoryDersignPattern
{
    public class DocumentFactory
    {
        private static readonly Lazy<DocumentFactory> deFactory = new Lazy<DocumentFactory>(() => new DocumentFactory());
        private DocumentFactory() { }
        public static DocumentFactory GetInstance() => deFactory.Value;
        public static Document Open(string bestandsnaam)
        {
            string extensie = bestandsnaam.Substring(bestandsnaam.Length - 4);
            return extensie switch
            {
                "docx" => new Tekst(bestandsnaam),
                "xlsx" => new Rekenblad(bestandsnaam),
                "pptx" => new Presentatie(bestandsnaam),
                _ => throw new Exception("Verkeerde extensie."),
            };
        }
    }

    public abstract class Document
    {
        public string Bestandsnaam { get; set; }
        protected Document(string bestandsnaam)
        {
            Bestandsnaam = bestandsnaam;
        }
        public abstract void Print();
        public abstract void PrintPreview();
    }

    public class Tekst:Document
    {
        public Tekst(string bestandsnaam) : base(bestandsnaam) { }
        public override void Print()
        {
            Console.WriteLine("Een afdruk van een tekst");
        }
        public override void PrintPreview()
        {
            Console.WriteLine("Een afdrukvoorbeeld van een tekst");
        }
    }

    public class Rekenblad:Document
    {
        public Rekenblad(string bestandsnaam) : base(bestandsnaam) { }
        public override void Print()
        {
            Console.WriteLine("Een afdruk van een rekenblad");
        }
        public override void PrintPreview()
        {
            Console.WriteLine("Een afdrukvoorbeeld van een rekenblad");
        }
    }

    public class Presentatie:Document
    {
        public Presentatie(string bestandsnaam) : base(bestandsnaam) { }
        public override void Print()
        {
            Console.WriteLine("Een afdruk van een presentatie");
        }
        public override void PrintPreview()
        {
            Console.WriteLine("Een afdrukvoorbeeld van een presentatie");
        }
    }
}
