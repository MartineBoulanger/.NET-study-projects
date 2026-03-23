using System.Text;

namespace Firma.Personeel
{
    // all delegates hier
    public delegate string WerknemersLijst(Werknemer[] werknemers);

    // Alle constructors en interface methods/properties hier
    public abstract partial class Werknemer:IKost
    {
        // constructor met optionele parameters
        public Werknemer(string naam = "onbekend", DateTime? inDienst = null, Geslacht geslacht = Geslacht.X)
        {
            this.Naam = naam;
            this.InDienst = inDienst ?? DateTime.Today;
            this.Geslacht = geslacht;
        }

        // static constructor die dus niet aangepast kan worden.
        static Werknemer()
        {
            Personeelsfeest = new DateOnly(DateTime.Today.Year, 2, 1);
            while (Personeelsfeest.DayOfWeek != DayOfWeek.Friday) Personeelsfeest = Personeelsfeest.AddDays(1);
        }

        // interface methods en properties declaraties hier
        public bool Menselijk => true;
        // public bool Menselijk { get => true; }
        // public bool Menselijk { get { return true; } }

        public abstract decimal BerekenKostprijs();
    }
    
    // alle properties hier
    public abstract partial class Werknemer
    {
        public abstract decimal Premie { get; }

        private string naam;
        public string Naam
        {
            get => naam;
            // set { if (value != string.Empty) naam = value; }
            // init { if (value != string.Empty) naam = value; }
            init => naam = !string.IsNullOrWhiteSpace(value) ? value : "onbekende naam";
        }

        private decimal salaris;
        public decimal Salaris
        {
            get
            {
                return salaris;
            }
            private set
            {
                if (value >= 0m) salaris = value;
            }
        }

        public bool VerjaarAncien
        {
            get
            {
                return InDienst.Month == DateTime.Today.Month && InDienst.Day == DateTime.Today.Day;
            }
        }
    }

    // alle properties met types van andere clases hier
    public abstract partial class Werknemer
    {
        public DateTime InDienst { get; set; }
        public WerkRegime Regime { get; set; }

        //private Geslacht geslacht;
        public Geslacht Geslacht
        {
            get;
            set;
        }

        private static DateOnly personeelsfeest;
        public static DateOnly Personeelsfeest
        {
            set => personeelsfeest = value;
            get => personeelsfeest;
        }

        private Afdeling afdeling;
        public Afdeling Afdeling
        {
            get => afdeling;
            set => afdeling = value;
        }
    }

    // alle methods hier
    public abstract partial class Werknemer
    {
        public virtual string GetInfo()
        {
            return $"Naam: {Naam}\nGeslacht: {Geslacht}\nIn dienst: {InDienst}\nPersoneelsfeest: {Personeelsfeest}\n{(Afdeling is not null ? Afdeling.ToString() : "Onbekende afdeling")}";
            // of Afdeling?.ToString() ?? "Onbekende afdeling"
        }

        public override string ToString()
        {
            return $"{Naam} {Geslacht}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Werknemer werknemer &&
                   Naam == werknemer.Naam;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Naam);
        }

        // methods om de delegate mee uit te voeren
        public static string UitgebreideWerknemersLijst(Werknemer[] werknemers)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Uitgebreide werknemerslijst:");
            foreach (Werknemer werknemer in werknemers)
            {
                sb.AppendLine(werknemer.GetInfo()).AppendLine();
            }
            return sb.ToString();
        }

        public static string KorteWerknemersLijst(Werknemer[] werknemers)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Verkorte werknemerslijst");
            foreach (Werknemer werknemer in werknemers)
            {
                sb.AppendLine(werknemer.ToString());
            }
            return sb.ToString();
        }
    }

    // alle nested classes hier
    public abstract partial class Werknemer
    {
        public class WerkRegime
        {
            public enum RegimeType { Voltijds, Viervijfde, Halftijds }

            public required RegimeType Type { get; set; }

            public int AantalVakantiedagen
            {
                get
                {
                    return Type switch
                    {
                        RegimeType.Voltijds => 25,
                        RegimeType.Viervijfde => 20,
                        RegimeType.Halftijds => 12,
                        _ => 0
                    };
                }
            }

            public override string ToString() => Type.ToString();
        }
    }
    
    // een constructor zonder parameters die zelf standaard default waardes meegeeft aan de properties.
    //public Werknemer(): this("Onbekend", DateTime.Today, Geslacht.Man) { }
    // een constructor met parameters waarbij de developer via het programma waardes kan meegeven aan de parameters.
    // public Werknemer(string naam = "onbekend", DateTime? inDienst = null, Geslacht geslacht = Geslacht.X, Afdeling? afdeling = null)
    // {
    //     this.Naam = naam;
    //     this.InDienst = inDienst ?? DateTime.Today;
    //     this.Geslacht = geslacht;
    //     this.Afdeling = afdeling ?? new Afdeling
    //     {
    //         Naam = "Onbekend",
    //         Verdieping = 10,
    //     }; // omdat de andere parameters optioneel zijn, heb ik deze ook optioneel gemaakt
    // }
}
