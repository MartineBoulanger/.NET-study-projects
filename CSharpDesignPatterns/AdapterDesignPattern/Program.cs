using AdapterDesignPattern;

// met oude versie
//OudeSpellingsControle controle = new OudeSpellingsControle(); // zonder adpater design pattern
SpellingsControleAdapter controle = new(); // met adapter design pattern
controle.Taal = "nl";
controle.Tekst = "Ik kom onmidelijk met een paralelogram.";
controle.ControleerSpelling();
int aantalFouten = controle.AantalFouten();
for (int index = 0; index != aantalFouten; index++) Console.WriteLine(controle.Fout(index));
Console.WriteLine();
// met nieuwe versie
//NieuweSpellingsControle controle2 = new NieuweSpellingsControle("nl", "Ik kom onmidelijk met een paralelogram."); // zonder adpater design pattern
//SpellingsControleAdapter controle2 = new(); // met adapter design pattern
//foreach (string fout in controle2.Controleer()) Console.WriteLine(fout);

// oefening
CalculatorAdapter adapter = new();
Rechthoek rechthoek = new(4, 2);
Console.WriteLine(adapter.BerekenOppervlakte(rechthoek));
Console.WriteLine();
Vierkant vierkant = new(3);
Console.WriteLine(adapter.BerekenOppervlakte(vierkant));
