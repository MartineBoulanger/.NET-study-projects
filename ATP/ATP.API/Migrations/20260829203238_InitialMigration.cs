using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ATP.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    WeeksNumberOne = table.Column<int>(type: "int", nullable: false),
                    FirstOnOne = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "CountryCode", "FirstOnOne", "Name", "Points", "WeeksNumberOne" },
                values: new object[,]
                {
                    { 1, "ITA", new DateOnly(2024, 6, 10), "Jannik Sinner", 11920, 19 },
                    { 2, "ESP", new DateOnly(2022, 9, 12), "Carlos Alcaraz", 7120, 36 },
                    { 3, "GER", null, "Alexander Zverev", 6795, 0 },
                    { 4, "SRB", new DateOnly(2011, 7, 4), "Novak Djokovic", 6210, 428 },
                    { 5, "RUS", new DateOnly(2022, 2, 28), "Daniil Medvedev", 5530, 16 },
                    { 6, "USA", null, "Taylor Fritz", 4415, 0 },
                    { 7, "RUS", null, "Andrey Rublev", 4110, 0 },
                    { 8, "NOR", null, "Casper Ruud", 3885, 0 },
                    { 9, "AUS", null, "Alex de Minaur", 3610, 0 },
                    { 10, "BUL", null, "Grigor Dimitrov", 3580, 0 },
                    { 11, "GRE", null, "Stefanos Tsitsipas", 3445, 0 },
                    { 12, "POL", null, "Hubert Hurkacz", 3060, 0 },
                    { 13, "USA", null, "Tommy Paul", 3055, 0 },
                    { 14, "DEN", null, "Holger Rune", 2985, 0 },
                    { 15, "USA", null, "Frances Tiafoe", 2600, 0 },
                    { 16, "FRA", null, "Ugo Humbert", 2515, 0 },
                    { 17, "USA", null, "Ben Shelton", 2500, 0 },
                    { 18, "USA", null, "Lorenzo Musetti", 2425, 0 },
                    { 19, "GBR", null, "Jack Draper", 2320, 0 },
                    { 20, "SUI", new DateOnly(2004, 2, 2), "Roger Federer", 0, 310 },
                    { 21, "USA", new DateOnly(1993, 4, 12), "Pete Sampras", 0, 286 },
                    { 22, "TCH", new DateOnly(1983, 2, 28), "Ivan Lendl", 0, 270 },
                    { 23, "USA", new DateOnly(1974, 7, 29), "Jimmy Connors", 0, 268 },
                    { 24, "ESP", new DateOnly(2008, 8, 18), "Rafael Nadal", 0, 209 },
                    { 25, "USA", new DateOnly(1980, 3, 3), "John McEnroe", 0, 170 },
                    { 26, "SWE", new DateOnly(1977, 8, 23), "Bjorn Borg", 0, 109 },
                    { 27, "USA", new DateOnly(1995, 4, 10), "Andre Agassi", 0, 101 },
                    { 28, "AUS", new DateOnly(2001, 11, 19), "Lleyton Hewitt", 0, 80 },
                    { 29, "SWE", new DateOnly(1990, 8, 13), "Stefan Edberg", 0, 72 },
                    { 30, "USA", new DateOnly(1992, 2, 10), "Jim Courier", 0, 58 },
                    { 31, "BRA", new DateOnly(2000, 12, 4), "Gustavo Kuerten", 0, 43 },
                    { 32, "GBR", new DateOnly(2016, 11, 7), "Andy Murray", 0, 41 },
                    { 33, "ROU", new DateOnly(1973, 8, 23), "Ilie Nastase", 0, 40 },
                    { 34, "SWE", new DateOnly(1988, 9, 12), "Mats Wilander", 0, 20 },
                    { 35, "USA", new DateOnly(2003, 11, 3), "Andy Roddick", 0, 13 },
                    { 36, "GER", new DateOnly(1991, 1, 28), "Boris Becker", 0, 12 },
                    { 37, "RUS", new DateOnly(2000, 11, 20), "Marat Safin", 0, 9 },
                    { 38, "AUS", new DateOnly(1974, 6, 3), "John Newcombe", 0, 8 },
                    { 39, "ESP", new DateOnly(2003, 9, 8), "Juan Carlos Ferrero", 0, 8 },
                    { 40, "AUT", new DateOnly(1996, 2, 12), "Thomas Muster", 0, 6 },
                    { 41, "CHI", new DateOnly(1998, 3, 30), "Marcelo Rios", 0, 6 },
                    { 42, "RUS", new DateOnly(1999, 5, 3), "Yevgeny Kafelnikov", 0, 6 },
                    { 43, "ESP", new DateOnly(1999, 3, 15), "Carlos Moya", 0, 2 },
                    { 44, "AUS", new DateOnly(1999, 7, 26), "Patrick Rafter", 0, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
