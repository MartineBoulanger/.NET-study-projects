namespace CSharpPFCursus
{
    public abstract class Werknemer
    {
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
         public Werknemer(string naam = "onbekend", DateTime? inDienst = null, Geslacht geslacht = Geslacht.X)
        {
            this.Naam = naam;
            this.InDienst = inDienst ?? DateTime.Today;
            this.Geslacht = geslacht;
        }

        public abstract decimal Premie { get; }

        private string naam;
        public string Naam
        {
            get => naam;
            // set { if (value != string.Empty) naam = value; }
            // init { if (value != string.Empty) naam = value; }
            init => naam = !string.IsNullOrWhiteSpace(value) ? value : "onbekende naam";
        }

        public DateTime InDienst { get; set; }
        
        //private Geslacht geslacht;
        public Geslacht Geslacht
        {
            get;
            set;
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

        private static DateOnly personeelsfeest;
        public static DateOnly Personeelsfeest
        {
            set => personeelsfeest = value;
            get => personeelsfeest;
        }

        // static constructor die dus niet aangepast kan worden.
        static Werknemer()
        {
            Personeelsfeest = new DateOnly(DateTime.Today.Year, 2, 1);
            while (Personeelsfeest.DayOfWeek != DayOfWeek.Friday) Personeelsfeest = Personeelsfeest.AddDays(1);
        }

        private Afdeling afdeling;
        public Afdeling Afdeling
        {
            get => afdeling;
            set => afdeling = value;
        }

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

        //public override bool Equals(object? obj)
        //{
        //    if (obj is Werknemer)
        //    {
        //        Werknemer andereWerknemer = (Werknemer)obj;
        //        return this.Naam == andereWerknemer.Naam;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public override int GetHashCode() 
        //{
        //    return Naam.GetHashCode();
        //}
    }
}
