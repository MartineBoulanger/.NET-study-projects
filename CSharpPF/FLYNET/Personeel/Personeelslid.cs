namespace FLYNET.Personeel
{
    public abstract class Personeelslid:IKost
    {
        public required int PersoneelsID { get; init; }
        public required string Naam { get; set; }
        public required decimal BasisKostprijsPerDag { get; set => field = value < 0m ? throw new Exception("Basiskostprijs per dag moet hoger zijn dan 0") : value; }
        public virtual decimal BerekenTotaleKostprijsPerDag() => BasisKostprijsPerDag; // virtual gemaakt ivm subclasses CockpitPersoneelslid & CabinePersoneelslid
        public override string ToString() => $"{PersoneelsID:D3} - {Naam} (basiskostprijs per dag: {BasisKostprijsPerDag:F2} euro)";
    }
}
