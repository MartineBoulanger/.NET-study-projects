
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
    string prompt = gekozenLand == null ? "\tGeef uw keuze (KX)*" : "    Geef uw keuze (KWSATVX)*";
    string keuze = LeesInput(prompt).ToUpper();
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
ToonBerichtMetKleur("\n    Tot ziens!", ConsoleColor.Blue);

void ToonHoofdMenu()
{
    Console.Clear();
    string landInfo = gekozenLand != null ? gekozenLand.Naam : "Geen land gekozen";
    Console.WriteLine($"    Info:  Land: {landInfo}");
    Console.WriteLine();
    Console.WriteLine("\t+---------------------+");
    Console.WriteLine("\t|  H O O F D M E N U  |");
    Console.WriteLine("\t+---------------------+");
    Console.WriteLine("\t|  <K>ies een land    |");
    Console.WriteLine("\t+---------------------+");
    Console.WriteLine(gekozenLand == null ? "\t|  Wijzig land        |" : "\t|  <W>ijzig land      |");
    Console.WriteLine(gekozenLand == null ? "\t|  Lijst Steden       |" : "\t|  Lijst <S>teden     |");
    Console.WriteLine(gekozenLand == null ? "\t|  Lijst Talen        |" : "\t|  Lijst T<a>len      |");
    Console.WriteLine(gekozenLand == null ? "\t|  Stad Toevoegen     |" : "\t|  Stad <T>oevoegen   |");
    Console.WriteLine(gekozenLand == null ? "\t|  Stad Verwijderen   |" : "\t|  Stad <V>erwijderen |");
    Console.WriteLine("\t+---------------------+");
    Console.WriteLine("\t|  E<x>it toepassing  |");
    Console.WriteLine("\t+---------------------+");
    Console.WriteLine();
}

// ═══════════════════════════════════════
// help functies
// ═══════════════════════════════════════
string LeesInput(string prompt)
{
    Console.Write($"{prompt} : ");
    return Console.ReadLine() ?? "";
}

void ToonBerichtMetKleur(string bericht, ConsoleColor kleur)
{
    Console.ForegroundColor = kleur;
    Console.WriteLine(bericht);
    Console.ResetColor();
}

void ToonFout(string bericht)
{
    ToonBerichtMetKleur($"\n{bericht}", ConsoleColor.Red);
    Pauze();
}

void Pauze()
{
    ToonBerichtMetKleur("\nDruk een toets om verder te gaan", ConsoleColor.Blue);
    Console.ReadKey();
}

void ToonStedenLijst()
{
    var steden = context.Steden.Where(s => s.ISOLandCode == gekozenLand!.ISOLandCode).OrderBy(s => s.Naam).ToList();
    Console.WriteLine("\n----------------\nLijst van Steden\n----------------");
    if (!steden.Any())
        ToonFout("Geen steden gevonden");
    else
        foreach (var s in steden)
            Console.WriteLine(s.Naam);
}

void ToonLandGegevens()
{
    Console.WriteLine($"\nGegevens land {gekozenLand!.Naam} :");
    Console.WriteLine($"\tAantal inwoners:  {gekozenLand.AantalInwoners,15:N0}");
    Console.WriteLine($"\t    Oppervlakte:      {gekozenLand.Oppervlakte,11:F2}");
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

// ═══════════════════════════════════════
// functies voor de menu-opties
// ═══════════════════════════════════════
void KiesLand()
{
    ToonBerichtMetKleur("\n\t+-----------------------------+\n\t|  K I E S   E E N   L A N D  |\n\t+-----------------------------+", ConsoleColor.Blue);
    var landen = context.Landen.OrderBy(l => l.Naam).ToList();
    Console.WriteLine("\n----------------\nLijst van Landen\n----------------");
    foreach (var land in landen)
    {
        Console.WriteLine(
            $"{land.ISOLandCode,-4} {land.Naam,-25} {land.AantalInwoners,15:N0} {land.Oppervlakte,15:F2}"
        );
    }
    string code = LeesInput("\nGeef een landcode in").ToUpper();
    if (string.IsNullOrEmpty(code))
    {
        ToonFout("Geef een landcode in");
        return;
    }
    var gekozen = context.Landen.FirstOrDefault(l => l.ISOLandCode == code);
    if (gekozen == null)
    {
        ToonFout($"Landcode '{code}' niet gevonden");
        return;
    }
    gekozenLand = gekozen;
    ToonBerichtMetKleur($"\nLand '{gekozenLand.Naam}' gekozen", ConsoleColor.Green);
    Pauze();
}

void WijzigLand()
{
    if (!LandGekozen())
        return;
    ToonBerichtMetKleur("\n\t+-----------------------------------------------------------------+\n\t|  W I J Z I G   D E   G E G E V E N S   V A N   E E N   L A N D  |\n\t+-----------------------------------------------------------------+", ConsoleColor.Blue);
    ToonLandGegevens();
    string inputInwoners = LeesInput("\nWijzig aantal inwoners (<Enter> = niet wijzigen)");
    if (!string.IsNullOrEmpty(inputInwoners))
    {
        if (int.TryParse(inputInwoners, out int nieuweInwoners) && nieuweInwoners > 0)
            gekozenLand!.AantalInwoners = nieuweInwoners;
        else
            ToonFout("Ongeldig getal voor aantal inwoners");
    }
    string inputOppervlakte = LeesInput("Wijzig aantal oppervlakte (<Enter> = niet wijzigen)");
    if (!string.IsNullOrEmpty(inputOppervlakte))
    {
        if (float.TryParse(inputOppervlakte, out float nieuweOppervlakte) && nieuweOppervlakte > 0)
            gekozenLand!.Oppervlakte = nieuweOppervlakte;
        else
            ToonFout("Ongeldige waarde voor oppervlakte");
    }
    context.SaveChanges();
    ToonLandGegevens();
    Pauze();
}

void LijstSteden()
{
    if (!LandGekozen())
        return;
    ToonBerichtMetKleur("\n\t+-----------------------------------+\n\t|  L I J S T   V A N   S T E D E N  |\n\t+-----------------------------------+", ConsoleColor.Blue);
    ToonStedenLijst();
    Pauze();
}

void LijstTalen()
{
    if (!LandGekozen())
        return;
    ToonBerichtMetKleur("\n\t+---------------------------------+\n\t|  L I J S T   V A N   T A L E N  |\n\t+---------------------------------+", ConsoleColor.Blue);
    var talen = context.LandenTalen.Where(l => l.LandCode == gekozenLand!.ISOLandCode).Include(l => l.Taal).OrderBy(l => l.Taal!.NaamNL).ToList();
    Console.WriteLine("\n---------------\nLijst van Talen\n---------------");
    if (!talen.Any())
        ToonFout("Geen talen gevonden");
    else
        foreach (var t in talen)
            Console.WriteLine($"{t.TaalCode}  {t.Taal!.NaamNL}");
    Pauze();
}

void StadToevoegen()
{
    if (!LandGekozen())
        return;
    ToonBerichtMetKleur("\n\t+-------------------------------------+\n\t|  V O E G   E E N   S T A D   T O E  |\n\t+-------------------------------------+", ConsoleColor.Blue);
    bool doorgaan = true;
    while (doorgaan)
    {
        ToonStedenLijst();
        string naam = LeesInput("\nGeef de naam van een nieuwe stad (<Enter> = stoppen)");
        if (string.IsNullOrEmpty(naam))
        {
            doorgaan = false;
            return;
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
    ToonBerichtMetKleur("\n\t+---------------------------------------+\n\t|  V E R W I J D E R   E E N   S T A D  |\n\t+---------------------------------------+", ConsoleColor.Blue);
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
            return;
        }
        if (!int.TryParse(input, out int stadId))
        {
            ToonFout("Geef een geldig nummer in");
            continue;
        }
        var teVerwijderen = steden.FirstOrDefault(s => s.StadId == stadId);
        if (teVerwijderen != null)
        {
            context.Steden.Remove(teVerwijderen);
            context.SaveChanges();
            ToonBerichtMetKleur($"\nVerwijderen van stad {teVerwijderen.Naam}", ConsoleColor.Green);
        }
    }
    Pauze();
}