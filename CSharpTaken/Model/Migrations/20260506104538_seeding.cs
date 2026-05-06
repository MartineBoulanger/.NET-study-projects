using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Klanten",
                columns: new[] { "KlantNr", "KlantNr1", "Voornaam" },
                values: new object[,]
                {
                    { 1, null, "Marge" },
                    { 2, null, "Homer" },
                    { 3, null, "Lisa" },
                    { 4, null, "Maggie" },
                    { 5, null, "Bart" }
                });

            migrationBuilder.InsertData(
                table: "Rekeningen",
                columns: new[] { "RekeningNr", "KlantNr", "Saldo", "Soort" },
                values: new object[,]
                {
                    { "BE12-4567-8900-0212", 1, 1000m, "Z" },
                    { "BE23-4567-8901-6954", 1, 1000m, "S" },
                    { "BE34-5678-9012-1214", 2, 1000m, "S" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Klanten",
                keyColumn: "KlantNr",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Klanten",
                keyColumn: "KlantNr",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Klanten",
                keyColumn: "KlantNr",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rekeningen",
                keyColumn: "RekeningNr",
                keyValue: "BE12-4567-8900-0212");

            migrationBuilder.DeleteData(
                table: "Rekeningen",
                keyColumn: "RekeningNr",
                keyValue: "BE23-4567-8901-6954");

            migrationBuilder.DeleteData(
                table: "Rekeningen",
                keyColumn: "RekeningNr",
                keyValue: "BE34-5678-9012-1214");

            migrationBuilder.DeleteData(
                table: "Klanten",
                keyColumn: "KlantNr",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Klanten",
                keyColumn: "KlantNr",
                keyValue: 2);
        }
    }
}
