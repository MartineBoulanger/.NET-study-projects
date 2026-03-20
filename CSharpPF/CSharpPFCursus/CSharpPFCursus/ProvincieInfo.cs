namespace CSharpPFCursus
{
  public class ProvincieInfo
  {
    public int ProvincieGrootte(string provincieNaam)
    {
      // zorg dat het pad naar de txt file correct is op de laptop
      // met try finally
      //StreamReader lezer = new StreamReader(@"C:\Users\marti\source\repos\DOTNET\provincies.txt");
      //try
      //{
      //  string? regel;
      //  while ((regel = lezer.ReadLine()) != null)
      //  {
      //    int dubbelPuntPos = regel.IndexOf(':');
      //    string provincie = regel.Substring(0, dubbelPuntPos);
      //    if (provincie == provincieNaam)
      //      return int.Parse(regel.Substring(dubbelPuntPos + 1));
      //  }
      //}
      //finally
      //{
      //  lezer.Close();
      //}
      //throw new Exception("Onbestaande provincie: " + provincieNaam);

      // met using - dan is de code nog korter en using zorgt ervoor dat het object gesloten wordt, dan hoef je zelf niet de Close() method op te roepen
      using (StreamReader lezer = new StreamReader(@"C:\Users\marti\source\repos\DOTNET\provincies.txt"))
      {
        string? regel;
        while ((regel = lezer.ReadLine()) != null)
        {
          int dubbelPuntPos = regel.IndexOf(':');
          string provincie = regel.Substring(0, dubbelPuntPos);
          if (provincie == provincieNaam)
            return int.Parse(regel.Substring(dubbelPuntPos + 1));
        }
      }
      throw new Exception("Onbestaande provincie: " + provincieNaam);
    }
  }
}
