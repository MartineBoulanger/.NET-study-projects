using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class personeelsleden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersoneelsLeden",
                columns: table => new
                {
                    PersoneelsNr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ManagerNr = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersoneelsLeden", x => x.PersoneelsNr);
                    table.ForeignKey(
                        name: "FK_PersoneelsLeden_PersoneelsLeden_ManagerNr",
                        column: x => x.ManagerNr,
                        principalTable: "PersoneelsLeden",
                        principalColumn: "PersoneelsNr");
                });

            migrationBuilder.InsertData(
                table: "PersoneelsLeden",
                columns: new[] { "PersoneelsNr", "ManagerNr", "Voornaam" },
                values: new object[,]
                {
                    { 1, null, "Diane" },
                    { 2, 1, "Mary" },
                    { 3, 1, "Jeff" },
                    { 4, 2, "William" },
                    { 5, 2, "Gerard" },
                    { 6, 2, "Anthony" },
                    { 19, 2, "Mami" },
                    { 7, 6, "Leslie" },
                    { 8, 6, "July" },
                    { 9, 6, "Steve" },
                    { 10, 6, "Foon Yue" },
                    { 11, 6, "George" },
                    { 12, 5, "Loui" },
                    { 13, 5, "Pamela" },
                    { 14, 5, "Larry" },
                    { 15, 5, "Barry" },
                    { 16, 4, "Andy" },
                    { 17, 4, "Peter" },
                    { 18, 4, "Tom" },
                    { 20, 19, "Yoshimi" },
                    { 21, 5, "Martin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersoneelsLeden_ManagerNr",
                table: "PersoneelsLeden",
                column: "ManagerNr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersoneelsLeden");
        }
    }
}
