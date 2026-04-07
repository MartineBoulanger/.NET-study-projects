namespace FLYNET.Vloot
{
    public class Vliegtuig:IKost
    {
        public required string Naam { get; set; }
        public required int Kruissnelheid { get; set; }
        public required int Vliegbereik { get; set; }
        public required decimal BasisKostprijsPerDag {  get; set => field = value < 0m ? throw new Exception("Basiskostprijs per dag moet hoger zijn dan 0") : value; }
        public decimal BerekenTotaleKostprijsPerDag() => BasisKostprijsPerDag;
        public override string ToString() => $"Toestel: {Naam} (basiskostprijs per dag: {BasisKostprijsPerDag:F2} euro)";
    }
}
