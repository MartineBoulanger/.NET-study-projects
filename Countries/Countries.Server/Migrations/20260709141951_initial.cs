using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Countries.Server.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capital = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryLanguage",
                columns: table => new
                {
                    CountriesId = table.Column<int>(type: "int", nullable: false),
                    LanguagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryLanguage", x => new { x.CountriesId, x.LanguagesId });
                    table.ForeignKey(
                        name: "FK_CountryLanguage_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryLanguage_Languages_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Capital", "Name", "Population" },
                values: new object[,]
                {
                    { 11, "Brussel", "België", 11409L },
                    { 12, "Amsterdam", "Nederland", 17017L },
                    { 13, "Londen", "Verenigd Koninkrijk", 65014L },
                    { 14, "Dublin", "Ierland", 4952L },
                    { 15, "Parijs", "Frankrijk", 66836L },
                    { 16, "Madrid", "Spanje", 48563L },
                    { 17, "Lissabon", "Portugal", 10834L },
                    { 18, "Rome", "Italië", 62008L },
                    { 19, "Bern", "Zwitserland", 8287L },
                    { 20, "Berlijn", "Duitsland", 80723L }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Nederlands" },
                    { 2, "Frans" },
                    { 3, "Engels" },
                    { 4, "Duits" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryLanguage_LanguagesId",
                table: "CountryLanguage",
                column: "LanguagesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryLanguage");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
