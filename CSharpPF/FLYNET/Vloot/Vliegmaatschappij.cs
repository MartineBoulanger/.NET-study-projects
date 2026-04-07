namespace FLYNET.Vloot
{
    public class Vliegmaatschappij
    {
        public required int VliegmaatschappijID { get; init; }
        public required Enums.Maatschappij VliegmaatschappijNaam { get; set; }
        public required List<Vliegtuig> Vloot { get; set; }
        public override string ToString() => $"Vliegmaatschappij: {VliegmaatschappijNaam}";
    }
}
