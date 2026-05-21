
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Entities;

using var context = new EFEindoefeningContext();
Land? gekozenLand = null;
bool running = true;

// ═══════════════════════════════════════
// menu
// ═══════════════════════════════════════
while (running)
{
    ToonHoofdMenu();
    string keuze = LeesInput("Geef uw keuze (KX)*").ToUpper();
    switch (keuze)
    {
        case "K":
            KiesLand();
            break;
        case "W":
            WijzigLand();
            break;
        case "S":
            LijstSteden();
            break;
        case "A":
            LijstTalen();
            break;
        case "T":
            StadToevoegen();
            break;
        case "V":
            StadVerwijderen();
            break;
        case "X":
            running = false;
            break;
        default:
            ToonFout("Ongeldige keuze. Kies K, W, S, A, T, V of X");
            break;
    }
}
Console.WriteLine("\nTot ziens!");

// ═══════════════════════════════════════
// help functies
// ═══════════════════════════════════════
void ToonHoofdMenu()
{
    Console.Clear();
    string landInfo = gekozenLand != null ? gekozenLand.Naam : "Geen land gekozen";
    Console.WriteLine($"Info:  Land: {landInfo}");
    Console.WriteLine();
    Console.WriteLine("+---------------------+");
    Console.WriteLine("|  H O O F D M E N U  |");
    Console.WriteLine("+---------------------+");
    Console.WriteLine("|  <K>ies een land    |");
    Console.WriteLine("+---------------------+");
    Console.WriteLine("|  <W>ijzig land      |");
    Console.WriteLine("|  Lijst <S>teden     |");
    Console.WriteLine("|  Lijst T<a>len      |");
    Console.WriteLine("|  Stad <T>oevoegen   |");
    Console.WriteLine("|  Stad <V>erwijderen |");
    Console.WriteLine("+---------------------+");
    Console.WriteLine("|  E<x>it toepassing  |");
    Console.WriteLine("+---------------------+");
    Console.WriteLine();
}

string LeesInput(string prompt)
{
    Console.Write($"{prompt} : ");
    return Console.ReadLine() ?? "";
}

void ToonFout(string bericht)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\n{bericht}");
    Console.ResetColor();
    Pauze();
}

void Pauze()
{
    Console.WriteLine("\nDruk een toets om verder te gaan");
    Console.ReadKey();
}

bool LandGekozen()
{
    if (gekozenLand == null)
    {
        ToonFout("Kies eerst een land via optie K");
        return false;
    }
    return true;
}

void KiesLand()
{
    Console.WriteLine();
    Console.WriteLine("+-----------------------------+");
    Console.WriteLine("|  K I E S   E E N   L A N D  |");
    Console.WriteLine("+-----------------------------+");
    var landen = context.Landen.OrderBy(l => l.Naam).ToList();
    Console.WriteLine();
    Console.WriteLine("----------------\nLijst van Landen\n----------------");
    foreach (var land in landen)
    {
        Console.WriteLine(
            $"{land.ISOLandCode,-4} {land.Naam,-25} {land.AantalInwoners,15:N0} {land.Oppervlakte,15:F2}"
        );
    }
    Console.WriteLine();
    string code = LeesInput("Geef een landcode in").ToUpper();
    if (string.IsNullOrEmpty(code))
    {
        ToonFout($"Geef een landcode in");
        return;
    }
    var gekozen = context.Landen.FirstOrDefault(l => l.ISOLandCode == code);
    if (gekozen == null)
    {
        ToonFout($"Landcode '{code}' niet gevonden");
        return;
    }
    gekozenLand = gekozen;
    Console.WriteLine($"\nLand '{gekozenLand.Naam}' gekozen");
    Pauze();
}

void WijzigLand()
{
    if (!LandGekozen())
        return;
    Console.WriteLine();
    Console.WriteLine("+-----------------------------------------------------------------+");
    Console.WriteLine("|  W I J Z I G   D E   G E G E V E N S   V A N   E E N   L A N D  |");
    Console.WriteLine("+-----------------------------------------------------------------+");
    Console.WriteLine($"\nGegevens land {gekozenLand!.Naam} :");
    Console.WriteLine($"      Aantal inwoners:  {gekozenLand.AantalInwoners,15:N0}");
    Console.WriteLine($"      Oppervlakte:      {gekozenLand.Oppervlakte,15:F2}");
    Console.WriteLine();
    string inputInwoners = LeesInput("Wijzig aantal inwoners (<Enter> = niet wijzigen)");
    if (!string.IsNullOrEmpty(inputInwoners))
    {
        if (int.TryParse(inputInwoners, out int nieuweInwoners) && nieuweInwoners > 0)
            gekozenLand.AantalInwoners = nieuweInwoners;
        else
            ToonFout("Ongeldig getal voor aantal inwoners");
    }
    string inputOppervlakte = LeesInput("Wijzig aantal oppervlakte (<Enter> = niet wijzigen)");
    if (!string.IsNullOrEmpty(inputOppervlakte))
    {
        if (float.TryParse(inputOppervlakte, out float nieuweOppervlakte) && nieuweOppervlakte > 0)
            gekozenLand.Oppervlakte = nieuweOppervlakte;
        else
            ToonFout("Ongeldige waarde voor oppervlakte");
    }
    context.SaveChanges();
    Console.WriteLine($"\nGegevens land {gekozenLand.Naam} :");
    Console.WriteLine($"      Aantal inwoners:  {gekozenLand.AantalInwoners,15:N0}");
    Console.WriteLine($"      Oppervlakte:      {gekozenLand.Oppervlakte,15:F2}");
    Pauze();
}

void LijstSteden()
{
    if (!LandGekozen())
        return;
    Console.WriteLine();
    Console.WriteLine("+-----------------------------------+");
    Console.WriteLine("|  L I J S T   V A N   S T E D E N  |");
    Console.WriteLine("+-----------------------------------+");
    var steden = context.Steden.Where(s => s.ISOLandCode == gekozenLand!.ISOLandCode).OrderBy(s => s.Naam).ToList();
    Console.WriteLine();
    Console.WriteLine("----------------\nLijst van Steden\n----------------");
    if (!steden.Any())
        Console.WriteLine("(geen steden gevonden)");
    else
        foreach (var stad in steden)
            Console.WriteLine(stad.Naam);
    Pauze();
}

void LijstTalen()
{
    if (!LandGekozen())
        return;
    Console.WriteLine();
    Console.WriteLine("+---------------------------------+");
    Console.WriteLine("|  L I J S T   V A N   T A L E N  |");
    Console.WriteLine("+---------------------------------+");
    var talen = context.LandenTalen.Where(lt => lt.LandCode == gekozenLand!.ISOLandCode).Include(lt => lt.Taal).OrderBy(lt => lt.Taal.NaamNL).ToList();
    Console.WriteLine();
    Console.WriteLine("---------------\nLijst van Talen\n---------------");
    if (!talen.Any())
        Console.WriteLine("(geen talen gevonden)");
    else
        foreach (var lt in talen)
            Console.WriteLine($"{lt.TaalCode}  {lt.Taal.NaamNL}");
    Pauze();
}

void StadToevoegen()
{
    if (!LandGekozen())
        return;
    Console.WriteLine();
    Console.WriteLine("+-------------------------------------+");
    Console.WriteLine("|  V O E G   E E N   S T A D   T O E  |");
    Console.WriteLine("+-------------------------------------+");
    bool doorgaan = true;
    while (doorgaan)
    {
        ToonStedenLijst();
        string naam = LeesInput("Geef de naam van een nieuwe stad");
        if (string.IsNullOrEmpty(naam))
        {
            ToonFout("Geef een naam in");
            doorgaan = false;
            continue;
        }
        bool bestaatAl = context.Steden.Any(s => s.ISOLandCode == gekozenLand!.ISOLandCode && s.Naam.ToLower() == naam.ToLower());
        if (bestaatAl)
        {
            ToonFout($"'{naam}' bestaat al voor {gekozenLand!.Naam}");
            continue;
        }
        context.Steden.Add(new Stad
        {
            Naam = naam,
            ISOLandCode = gekozenLand!.ISOLandCode
        });
        context.SaveChanges();
    }
}

void StadVerwijderen()
{
    if (!LandGekozen())
        return;
    Console.WriteLine();
    Console.WriteLine("+---------------------------------------+");
    Console.WriteLine("|  V E R W I J D E R   E E N   S T A D  |");
    Console.WriteLine("+---------------------------------------+");
    bool doorgaan = true;
    while (doorgaan)
    {
        var steden = context.Steden.Where(s => s.ISOLandCode == gekozenLand!.ISOLandCode).OrderBy(s => s.Naam).ToList();
        if (!steden.Any())
        {
            Console.WriteLine("\n(geen steden om te verwijderen)");
            Pauze();
            return;
        }
        Console.WriteLine("\nKies de stad:");
        for (int i = 0; i < steden.Count; i++)
            Console.WriteLine($"{steden[i].StadId:D4}  {steden[i].Naam}");
        string input = LeesInput("Geef het volgnummer uit de lijst (<Enter> = stoppen)");
        if (string.IsNullOrEmpty(input))
        {
            doorgaan = false;
        }
        if (!int.TryParse(input, out int stadId))
        {
            ToonFout("Geef een geldig nummer in");
        }
        var teVerwijderen = steden.FirstOrDefault(s => s.StadId == stadId);
        if (teVerwijderen == null)
        {
            ToonFout($"Geen stad gevonden met nummer {stadId}");
        }
        else
        {
            context.Steden.Remove(teVerwijderen);
            context.SaveChanges();
            Console.WriteLine($"\nVerwijderen van stad {teVerwijderen.Naam}");
        }
    }
    Pauze();
}

void ToonStedenLijst()
{
    var steden = context.Steden.Where(s => s.ISOLandCode == gekozenLand!.ISOLandCode).OrderBy(s => s.Naam).ToList();
    Console.WriteLine();
    Console.WriteLine("----------------\nLijst van Steden\n----------------");
    if (!steden.Any())
        Console.WriteLine("(nog geen steden)");
    else
        foreach (var s in steden)
            Console.WriteLine(s.Naam);
    Console.WriteLine();
}