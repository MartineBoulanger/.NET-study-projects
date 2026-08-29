using ATP.Models;
using Microsoft.EntityFrameworkCore;

namespace ATP.API.Models
{
    public class ATPDbContext:DbContext
    {
        public ATPDbContext(DbContextOptions<ATPDbContext> options) : base(options) { }
        public DbSet<Player> Players { get; set; }

        // Lijst van alle spelers voor de database - gekopieerd uit de players.txt file die bij de opdracht zit
        // Niet vergeten om 'dotnet ef database update' uit te voeren om de database te kunnen gebruiken
        private readonly List<Player> players = [
                new Player { PlayerId = 1, Name = "Jannik Sinner", Points = 11920, CountryCode = "ITA", WeeksNumberOne = 19, FirstOnOne = new DateOnly(2024, 6, 10) },
                new Player { PlayerId = 2, Name = "Carlos Alcaraz", Points = 7120, CountryCode = "ESP", WeeksNumberOne = 36, FirstOnOne = new DateOnly(2022, 9, 12) },
                new Player { PlayerId = 3, Name = "Alexander Zverev", Points = 6795, CountryCode = "GER", WeeksNumberOne = 0, FirstOnOne = null },
                new Player { PlayerId = 4, Name = "Novak Djokovic", Points = 6210, CountryCode = "SRB", WeeksNumberOne = 428, FirstOnOne = new DateOnly(2011, 7, 4) },
                new Player { PlayerId = 5, Name = "Daniil Medvedev", Points = 5530, CountryCode = "RUS", WeeksNumberOne = 16, FirstOnOne = new DateOnly(2022, 2, 28) },
                new Player { PlayerId = 6, Name = "Taylor Fritz", Points = 4415, CountryCode = "USA", WeeksNumberOne = 0, FirstOnOne = null },
                new Player { PlayerId = 7, Name = "Andrey Rublev", Points = 4110, CountryCode = "RUS", WeeksNumberOne = 0, FirstOnOne = null },
                new Player { PlayerId = 8, Name = "Casper Ruud", Points = 3885, CountryCode = "NOR", WeeksNumberOne = 0, FirstOnOne = null },
                new Player { PlayerId = 9, Name = "Alex de Minaur", Points = 3610, CountryCode = "AUS", WeeksNumberOne = 0, FirstOnOne = null },
                new Player { PlayerId = 10, Name = "Grigor Dimitrov", Points = 3580, CountryCode = "BUL", WeeksNumberOne = 0, FirstOnOne = null },
                new Player { PlayerId = 11, Name = "Stefanos Tsitsipas", Points = 3445, CountryCode = "GRE", WeeksNumberOne = 0, FirstOnOne = null },
                new Player { PlayerId = 12, Name = "Hubert Hurkacz", Points = 3060, CountryCode = "POL", WeeksNumberOne = 0, FirstOnOne = null },
                new Player { PlayerId = 13, Name = "Tommy Paul", Points = 3055, CountryCode = "USA", WeeksNumberOne = 0, FirstOnOne = null },
                new Player { PlayerId = 14, Name = "Holger Rune", Points = 2985, CountryCode = "DEN", WeeksNumberOne = 0, FirstOnOne = null },
                new Player { PlayerId = 15, Name = "Frances Tiafoe", Points = 2600, CountryCode = "USA", WeeksNumberOne = 0, FirstOnOne = null },
                new Player { PlayerId = 16, Name = "Ugo Humbert", Points = 2515, CountryCode = "FRA", WeeksNumberOne = 0, FirstOnOne = null },
                new Player { PlayerId = 17, Name = "Ben Shelton", Points = 2500, CountryCode = "USA", WeeksNumberOne = 0, FirstOnOne = null },
                new Player { PlayerId = 18, Name = "Lorenzo Musetti", Points = 2425, CountryCode = "USA", WeeksNumberOne = 0, FirstOnOne = null },
                new Player { PlayerId = 19, Name = "Jack Draper", Points = 2320, CountryCode = "GBR", WeeksNumberOne = 0, FirstOnOne = null },
                new Player { PlayerId = 20, Name = "Roger Federer", Points = 0, CountryCode = "SUI", WeeksNumberOne = 310, FirstOnOne = new DateOnly(2004, 2, 2) },
                new Player { PlayerId = 21, Name = "Pete Sampras", Points = 0, CountryCode = "USA", WeeksNumberOne = 286, FirstOnOne = new DateOnly(1993, 4, 12) },
                new Player { PlayerId = 22, Name = "Ivan Lendl", Points = 0, CountryCode = "TCH", WeeksNumberOne = 270, FirstOnOne = new DateOnly(1983, 2, 28) },
                new Player { PlayerId = 23, Name = "Jimmy Connors", Points = 0, CountryCode = "USA", WeeksNumberOne = 268, FirstOnOne = new DateOnly(1974, 7, 29) },
                new Player { PlayerId = 24, Name = "Rafael Nadal", Points = 0, CountryCode = "ESP", WeeksNumberOne = 209, FirstOnOne = new DateOnly(2008, 8, 18) },
                new Player { PlayerId = 25, Name = "John McEnroe", Points = 0, CountryCode = "USA", WeeksNumberOne = 170, FirstOnOne = new DateOnly(1980, 3, 3) },
                new Player { PlayerId = 26, Name = "Bjorn Borg", Points = 0, CountryCode = "SWE", WeeksNumberOne = 109, FirstOnOne = new DateOnly(1977, 8, 23) },
                new Player { PlayerId = 27, Name = "Andre Agassi", Points = 0, CountryCode = "USA", WeeksNumberOne = 101, FirstOnOne = new DateOnly(1995,4,10) },
                new Player { PlayerId = 28, Name = "Lleyton Hewitt", Points = 0, CountryCode = "AUS", WeeksNumberOne = 80, FirstOnOne = new DateOnly(2001,11,19) },
                new Player { PlayerId = 29, Name = "Stefan Edberg", Points = 0, CountryCode = "SWE", WeeksNumberOne = 72, FirstOnOne = new DateOnly(1990,8,13) },
                new Player { PlayerId = 30, Name = "Jim Courier", Points = 0, CountryCode = "USA", WeeksNumberOne = 58, FirstOnOne = new DateOnly(1992,2,10) },
                new Player { PlayerId = 31, Name = "Gustavo Kuerten", Points = 0, CountryCode = "BRA", WeeksNumberOne = 43, FirstOnOne = new DateOnly(2000,12,4) },
                new Player { PlayerId = 32, Name = "Andy Murray", Points = 0, CountryCode = "GBR", WeeksNumberOne = 41, FirstOnOne = new DateOnly(2016,11,7) },
                new Player { PlayerId = 33, Name = "Ilie Nastase", Points = 0, CountryCode = "ROU", WeeksNumberOne = 40, FirstOnOne = new DateOnly(1973,8,23) },
                new Player { PlayerId = 34, Name = "Mats Wilander", Points = 0, CountryCode = "SWE", WeeksNumberOne = 20, FirstOnOne = new DateOnly(1988,9,12) },
                new Player { PlayerId = 35, Name = "Andy Roddick", Points = 0, CountryCode = "USA", WeeksNumberOne = 13, FirstOnOne = new DateOnly(2003,11,3) },
                new Player { PlayerId = 36, Name = "Boris Becker", Points = 0, CountryCode = "GER", WeeksNumberOne = 12, FirstOnOne = new DateOnly(1991,1,28) },
                new Player { PlayerId = 37, Name = "Marat Safin", Points = 0, CountryCode = "RUS", WeeksNumberOne = 9, FirstOnOne = new DateOnly(2000,11,20) },
                new Player { PlayerId = 38, Name = "John Newcombe", Points = 0, CountryCode = "AUS", WeeksNumberOne = 8, FirstOnOne = new DateOnly(1974,6,3) },
                new Player { PlayerId = 39, Name = "Juan Carlos Ferrero", Points = 0, CountryCode = "ESP", WeeksNumberOne = 8, FirstOnOne = new DateOnly(2003,9,8) },
                new Player { PlayerId = 40, Name = "Thomas Muster", Points = 0, CountryCode = "AUT", WeeksNumberOne = 6, FirstOnOne = new DateOnly(1996,2,12) },
                new Player { PlayerId = 41, Name = "Marcelo Rios", Points = 0, CountryCode = "CHI", WeeksNumberOne = 6, FirstOnOne = new DateOnly(1998,3,30) },
                new Player { PlayerId = 42, Name = "Yevgeny Kafelnikov", Points = 0, CountryCode = "RUS", WeeksNumberOne = 6, FirstOnOne = new DateOnly(1999,5,3) },
                new Player { PlayerId = 43, Name = "Carlos Moya", Points = 0, CountryCode = "ESP", WeeksNumberOne = 2, FirstOnOne = new DateOnly(1999,3,15) },
                new Player { PlayerId = 44, Name = "Patrick Rafter", Points = 0, CountryCode = "AUS", WeeksNumberOne = 1, FirstOnOne = new DateOnly(1999,7,26) }
            ];

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var player in players)
            {
                modelBuilder.Entity<Player>().HasData(player);
            }
        }
    }
}
