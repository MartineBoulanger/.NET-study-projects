using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class fixed_klanten_tabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klanten_Klanten_KlantNr1",
                table: "Klanten");

            migrationBuilder.DropIndex(
                name: "IX_Klanten_KlantNr1",
                table: "Klanten");

            migrationBuilder.DropColumn(
                name: "KlantNr1",
                table: "Klanten");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KlantNr1",
                table: "Klanten",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Klanten",
                keyColumn: "KlantNr",
                keyValue: 1,
                column: "KlantNr1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Klanten",
                keyColumn: "KlantNr",
                keyValue: 2,
                column: "KlantNr1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Klanten",
                keyColumn: "KlantNr",
                keyValue: 3,
                column: "KlantNr1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Klanten",
                keyColumn: "KlantNr",
                keyValue: 4,
                column: "KlantNr1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Klanten",
                keyColumn: "KlantNr",
                keyValue: 5,
                column: "KlantNr1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Klanten_KlantNr1",
                table: "Klanten",
                column: "KlantNr1");

            migrationBuilder.AddForeignKey(
                name: "FK_Klanten_Klanten_KlantNr1",
                table: "Klanten",
                column: "KlantNr1",
                principalTable: "Klanten",
                principalColumn: "KlantNr");
        }
    }
}
