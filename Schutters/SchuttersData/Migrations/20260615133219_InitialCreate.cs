using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchuttersData.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Stamnummer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Gemeente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Stamnummer);
                });

            migrationBuilder.CreateTable(
                name: "Leden",
                columns: table => new
                {
                    Lidnummer = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Geslacht = table.Column<int>(type: "int", maxLength: 1, nullable: true),
                    Niveau = table.Column<int>(type: "int", maxLength: 1, nullable: true),
                    Club = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leden", x => x.Lidnummer);
                    table.ForeignKey(
                        name: "FK_Leden_Clubs_Club",
                        column: x => x.Club,
                        principalTable: "Clubs",
                        principalColumn: "Stamnummer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leden_Club",
                table: "Leden",
                column: "Club");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leden");

            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}
