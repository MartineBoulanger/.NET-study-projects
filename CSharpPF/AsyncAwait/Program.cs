// synchroon programma
//public class Program
//{
//  static void Main(string[] args)
//  {
//    Console.WriteLine("Synchroon voorbeeld:");
//    Console.WriteLine("Druk een willekeurige toets om de synchrone taak te starten.");
//    Console.ReadKey(true);
//    Console.WriteLine("Start lange berekening...");
//    LangeBerekening();
//    //ik wil iets anders doen terwijl de berekening uitgevoerd wordt
//    //maar dat is niet mogelijk
//    DoeIetsAnders();
//    Console.WriteLine("Maar dat is niet mogelijk!");
//  }

//  // synchrone method
//  static void LangeBerekening()
//  {
//    Console.WriteLine(" \t berekening is gestart");
//    Console.WriteLine(" \t wachten maar...");
//    //simuleer een tijdrovende taak
//    Task.Delay(5000).Wait(); // 5 seconden wachten
//    Console.WriteLine(" \t berekening klaar!");
//  }

//  static void DoeIetsAnders()
//  {
//    Console.WriteLine("Ondertussen wil ik iets anders doen.");
//  }
//}

// asynchroon programma
public class Program
{
  static async Task Main(string[] args)
  {
    Console.WriteLine("Asynchroon voorbeeld:");
    Console.WriteLine(
    "Druk een willekeurige toets om de asynchrone taak te starten.");
    Console.ReadKey(true);
    Console.WriteLine("Start lange berekening...");
    // Start de taak op de achtergrond
    Task taak = LangeBerekeningAsync();
    // Ondertussen kan de gebruiker iets anders doen
    DoeIetsAnders();
    // Wacht tot de asynchrone taak klaar is
    await taak;
    Console.WriteLine("langdurige berekening is klaar (main)!");
    Console.WriteLine("Einde");
  }

  // asynchrone method
  static async Task LangeBerekeningAsync()
  {
    Console.WriteLine(" \t berekening is bezig");
    // 7 seconden wachten, maar ondertussen gebeurt iets anders
    await Task.Delay(7000);
  }

  static void DoeIetsAnders()
  {
    Console.WriteLine("Ondertussen wil ik iets anders doen.");
    for (int i = 0; i < 5; i++)
    {
      Console.WriteLine($"Ik doe iets anders!" +
      $" {i + 1} seconden voorbij...");
      Thread.Sleep(1000); // synchrone wachttijd 1 s
    }
    Console.WriteLine("DoeIetsAnders is klaar.");
  }
}