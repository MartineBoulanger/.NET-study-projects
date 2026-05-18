using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class artikels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtikelGroepen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtikelGroepen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artikels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtikelGroepId = table.Column<int>(type: "int", nullable: false),
                    ArtikelType = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Houdbaarheid = table.Column<int>(type: "int", nullable: true),
                    Garantie = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artikels_ArtikelGroepen_ArtikelGroepId",
                        column: x => x.ArtikelGroepId,
                        principalTable: "ArtikelGroepen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artikels_ArtikelGroepId",
                table: "Artikels",
                column: "ArtikelGroepId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artikels");

            migrationBuilder.DropTable(
                name: "ArtikelGroepen");
        }
    }
}
