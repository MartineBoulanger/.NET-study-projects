using SingletonDesignPattern;
//var singleton = Singleton.GetInstance();
//singleton.ZegGoeiedag();
//var tweedeSingleton = Singleton.GetInstance();
//if (singleton == tweedeSingleton) Console.WriteLine("Zelfde instanties");
//Console.ReadLine();

//var deMotor = Motor.GetInstance();
//deMotor.Start();
////allerlei andere code
//var mijnMotor = Motor.GetInstance();
//mijnMotor.Start();
//mijnMotor.Stop();
//Console.ReadLine();

// oefening 1
//var bak = Versnellingsbak.GetInstance();
//bak.GaNaarVersnelling(1);
//bak.GaNaarVersnelling(7);
////als test een tweede verwijzing naar dezelfde versnellingsbak
//var bak2 = Versnellingsbak.GetInstance();
//bak2.GaNaarVersnelling(0);
//bak2.GaNaarVersnelling(-1);

// oefening 2
var eightball = Magic8Ball.GetInstance();
Console.Write("Stel jouw vraag: ");
string vraag = Console.ReadLine()!;
while (vraag != "stop")
{
    Console.WriteLine(eightball.GeefVoorspelling());
    Console.WriteLine();
    Console.Write("Stel jouw vraag: ");
    vraag = Console.ReadLine()!;
}
;
