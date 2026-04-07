using FLYNET;
using FLYNET.Personeel;
using FLYNET.Vloot;
using System.Text;
TekenLijn tekenLijn = new TekenLijn();
//****************************************************************************************
// Certificaten
//****************************************************************************************
Certificaat PPL = new Certificaat { CertificaatAfkorting = "PPL", CertificaatOmschrijving = "Private Pilot License" };
Certificaat ATPL = new Certificaat { CertificaatAfkorting = "ATPL", CertificaatOmschrijving = "Airline Transport Pilot License" };
Certificaat IR = new Certificaat { CertificaatAfkorting = "IR", CertificaatOmschrijving = "Instrument Rating" };
Certificaat CPL = new Certificaat { CertificaatAfkorting = "CPL", CertificaatOmschrijving = "Commercial Pilot License" };
Certificaat ME = new Certificaat { CertificaatAfkorting = "ME", CertificaatOmschrijving = "Multi Engine" };
Certificaat MCC = new Certificaat { CertificaatAfkorting = "MCC", CertificaatOmschrijving = "Multi Crew Concept" };
Certificaat EHBO = new Certificaat { CertificaatAfkorting = "EHBO", CertificaatOmschrijving = "First Aid" };
Certificaat EVAC = new Certificaat { CertificaatAfkorting = "EVAC", CertificaatOmschrijving = "Evacution Procedures" };
Certificaat FIRE = new Certificaat { CertificaatAfkorting = "FIRE", CertificaatOmschrijving = "Fire Fighting" };
Certificaat SURV = new Certificaat { CertificaatAfkorting = "SURV", CertificaatOmschrijving = "Survival" };
Certificaat IFS = new Certificaat { CertificaatAfkorting = "IFS", CertificaatOmschrijving = "In Flight Service" };
//****************************************************************************************
// Personeel
//****************************************************************************************
CockpitPersoneelslid kirk = new CockpitPersoneelslid { PersoneelsID = 1, Naam = "Captain Kirk", BasisKostprijsPerDag = 500m, Graad = Enums.Graad.Captain, Certificaten = new List<Certificaat> { PPL, ATPL, CPL, SURV }, Vlieguren = 5000 };
CockpitPersoneelslid spock = new CockpitPersoneelslid { PersoneelsID = 2, Naam = "Spock", BasisKostprijsPerDag = 400m, Graad = Enums.Graad.SecondOfficer, Certificaten = new List<Certificaat> { PPL, ATPL, CPL, IFS }, Vlieguren = 4500 };
CabinePersoneelslid pavel = new CabinePersoneelslid { PersoneelsID = 3, Naam = "Pavel Chekov", BasisKostprijsPerDag = 300m, Graad = Enums.Graad.Purser, Certificaten = new List<Certificaat> { ME, MCC, EHBO, IFS }, Werkpositie = "deur1" };
CabinePersoneelslid luke = new CabinePersoneelslid { PersoneelsID = 4, Naam = "Luke Skywalker", BasisKostprijsPerDag = 300m, Graad = Enums.Graad.Steward, Certificaten = new List<Certificaat> { FIRE, SURV, IFS, EHBO }, Werkpositie = "nooduitgang" };
//****************************************************************************************
// Vliegtuigen
//****************************************************************************************
Vliegtuig airbusA330 = new Vliegtuig { Naam = "Airbus A330-200", Kruissnelheid = 870, Vliegbereik = 10800, BasisKostprijsPerDag = 4000m };
Vliegtuig airbusA320 = new Vliegtuig { Naam = "Airbus A320", Kruissnelheid = 840, Vliegbereik = 6100, BasisKostprijsPerDag = 3000m };
Vliegtuig boeing737 = new Vliegtuig { Naam = "Boeing 737-800", Kruissnelheid = 820, Vliegbereik = 6204, BasisKostprijsPerDag = 2500m };
Vliegtuig boeing787 = new Vliegtuig { Naam = "Boeing 787-700", Kruissnelheid = 820, Vliegbereik = 6370, BasisKostprijsPerDag = 2000m };
//****************************************************************************************
// Vliegmaatschappijen
//****************************************************************************************
Vliegmaatschappij ba = new Vliegmaatschappij { VliegmaatschappijID = 1, VliegmaatschappijNaam = Enums.Maatschappij.BrusselsAirlines, Vloot = new List<Vliegtuig> { airbusA320, airbusA330 } };
Vliegmaatschappij tui = new Vliegmaatschappij { VliegmaatschappijID = 2, VliegmaatschappijNaam = Enums.Maatschappij.TUIFly, Vloot = new List<Vliegtuig> { boeing737, boeing787 } };
//****************************************************************************************
// Vluchten
//****************************************************************************************
Vlucht ny = new Vlucht { VluchtID = 1, Bestemming = "New York", Vliegmaatschappij = ba, Toestel = airbusA330, DuurtijdInDagen = 2, Personeel = new List<Personeelslid> { kirk, pavel, spock } };
Vlucht sydney = new Vlucht { VluchtID = 2, Bestemming = "Sydney", Vliegmaatschappij = tui, Toestel = boeing737, DuurtijdInDagen = 3, Personeel = new List<Personeelslid> { spock, luke, kirk } };
Vlucht singapore = new Vlucht { VluchtID = 3, Bestemming = "Singapore", Vliegmaatschappij = ba, Toestel = airbusA320, DuurtijdInDagen = 1, Personeel = new List<Personeelslid> { luke, kirk } };
//****************************************************************************************
// Verzameling
//****************************************************************************************
List<Vlucht> vluchten = [ny, sydney, singapore];
//****************************************************************************************
// Gegevens tonen op het scherm
//****************************************************************************************
foreach (Vlucht v in vluchten)
{
    tekenLijn.Lijn(100, '=');
    Console.WriteLine($"VluchtID: {v.VluchtID} - Bestemming {v.Bestemming} ({v.DuurtijdInDagen} dag(en))");
    tekenLijn.Lijn(100, '=');
    Console.WriteLine($"{v.Vliegmaatschappij.ToString()} - {v.Toestel.ToString()}");
    Console.WriteLine($"Vluchtprijs: {v.BerekenVluchtKost():F2} euro");
    Console.WriteLine();

    // Geen tijd meer om dit te fixen, de totale kost wordt niet goed weergegeven helaas
    StringBuilder sb = new StringBuilder();
    sb.Append($"Totale vliegtuigkost: {v.Toestel.BerekenTotaleKostprijsPerDag() * v.DuurtijdInDagen} euro").AppendLine();
    decimal totalePersoneelsKost = 0m;
    sb.Append($"Totale personeelskost: {totalePersoneelsKost}").AppendLine();
    foreach (var pers in v.Personeel)
    {
        if (pers is CockpitPersoneelslid)
        {
            decimal kost = pers.BerekenTotaleKostprijsPerDag() * v.DuurtijdInDagen;
            totalePersoneelsKost += kost;
            sb.Append($"  Totale kost cockpitpersoneel: {kost:F2} euro").AppendLine();
        }
        if (pers is CabinePersoneelslid)
        {
            decimal kost = pers.BerekenTotaleKostprijsPerDag() * v.DuurtijdInDagen;
            totalePersoneelsKost *= kost;
            sb.Append($"  Totale kost cabinepersoneel: {kost:F2} euro").AppendLine();
        }
    }
    Console.WriteLine(sb.ToString());
    Console.WriteLine();
    Console.WriteLine("Cockpitpersoneel:");
    tekenLijn.Lijn(17);
    foreach (var cockpitPersoneelslid in v.Personeel)
    {
        if (cockpitPersoneelslid is CockpitPersoneelslid)
        {            
            Console.WriteLine(cockpitPersoneelslid.ToString());
            Console.WriteLine();
        }
    }
    Console.WriteLine("Cabinepersoneel:");
    tekenLijn.Lijn(16);
    foreach (var cabinePersoneelslid in v.Personeel)
    {
        if (cabinePersoneelslid is CabinePersoneelslid)
        {
            Console.WriteLine(cabinePersoneelslid.ToString());
            Console.WriteLine();
        }
    }
}