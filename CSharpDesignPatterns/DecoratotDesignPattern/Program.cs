using DecoratorDesignPattern;

// hardcoded
//IKoffie eenvoudig = new EenvoudigeKoffie();
//Console.WriteLine("Eenvoudige koffie");
//Console.WriteLine("Kostprijs : {0} euro", eenvoudig.Kost());
//Console.WriteLine("Bereiding : " + eenvoudig.Bereidingswijze());
//Console.WriteLine();
//IKoffie metMelk = new MetMelk(new EenvoudigeKoffie());
//Console.WriteLine("Koffie met melk");
//Console.WriteLine("Kostprijs : {0} euro", metMelk.Kost());
//Console.WriteLine("Bereiding : " + metMelk.Bereidingswijze());
//Console.WriteLine();
//IKoffie metChocolade = new MetChocolade(new EenvoudigeKoffie());
//Console.WriteLine("Koffie met chocolade");
//Console.WriteLine("Kostprijs : {0} euro", metChocolade.Kost());
//Console.WriteLine("Bereiding : " + metChocolade.Bereidingswijze());
//Console.WriteLine();
//IKoffie metMelkEnChocolade = new MetChocolade(new MetMelk(new EenvoudigeKoffie()));
//Console.WriteLine("Koffie met melk en chocolade");
//Console.WriteLine("Kostprijs : {0} euro", metMelkEnChocolade.Kost());
//Console.WriteLine("Bereiding : " + metMelkEnChocolade.Bereidingswijze());
//Console.WriteLine();

// dynamisch
//IKoffie koffie = new EenvoudigeKoffie();
//Console.Write("Melk (j/n):");
//var invoer = Console.ReadLine()!;
//if (invoer.ToUpper().Equals("J")) koffie = new MetMelk(koffie);
//Console.Write("Chocolade (j/n):");
//invoer = Console.ReadLine()!;
//if (invoer.ToUpper().Equals("J")) koffie = new MetChocolade(koffie);
//Console.WriteLine("Kostprijs : {0} euro", koffie.Kost());
//Console.WriteLine("Bereiding : " + koffie.Bereidingswijze());

// oefening
IArrangement arrangement = new Bungalow();
Console.Write("Barbeque (j/n):");
if (Console.ReadLine()!.Equals("j")) arrangement = new MetBarbeque(arrangement);
Console.Write("Fietsen (j/n):");
if (Console.ReadLine()!.Equals("j")) arrangement = new MetFietsen(arrangement);
Console.WriteLine(arrangement.Taak);