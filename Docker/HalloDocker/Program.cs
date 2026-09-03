var directory = "/data";
if (!Directory.Exists(directory))
{
    Directory.CreateDirectory(directory);
    Console.WriteLine($"Directory created: {directory}");
}

var bestand = $"{directory}/naam.txt";
if (!File.Exists(bestand))
{
    File.WriteAllText(bestand, "Johnny Dalton");
    Console.WriteLine($"File created: {bestand}");
}