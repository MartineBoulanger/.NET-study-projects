using FactoryDesignPattern;

//DocumentFactory factory = new();
//Document document = DocumentFactory.Open("liedje.docx");
//document.PrintPreview();
//document.Print();
//Document rekenblad = DocumentFactory.Open("rekenblad.xlsx");
//rekenblad.PrintPreview();
//rekenblad.Print();

//DocumentFactory factory = DocumentFactory.GetInstance();
//Document document = DocumentFactory.Open("liedje.docx");
//document.PrintPreview();
//document.Print();
//Document rekenblad = DocumentFactory.Open("rekenblad.xlsx");
//rekenblad.PrintPreview();
//rekenblad.Print();

// oefening
SpeelgoedFactory factory = new();
Speelgoed speelgoed = factory.KiesSpeelgoed(15);
Console.WriteLine(speelgoed.Prijs);
