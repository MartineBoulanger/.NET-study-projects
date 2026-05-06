using System;
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
                table: "Campussen",
                columns: new[] { "CampusId", "Gemeente", "Huisnummer", "CampusNaam", "Postcode", "Straat" },
                values: new object[,]
                {
                    { 1, "Antwerpen", "22", "Andros", "2018", "Somersstraat" },
                    { 2, "Dendermonde", "17", "Delos", "9200", "Oude Vest" },
                    { 3, "Genk", "37", "Gavdos", "3600", "Europalaan" },
                    { 4, "Heverlee", "2", "Hydra", "3001", "Interleuvenlaan" },
                    { 5, "Wevelgem", "10", "Ikaria", "8560", "Vlamingstraat" },
                    { 6, "Oostende", "4", "Oinouses", "8400", "Akkerstraat" }
                });

            migrationBuilder.InsertData(
                table: "Landen",
                columns: new[] { "LandCode", "Naam" },
                values: new object[,]
                {
                    { "BE", "België" },
                    { "DE", "Duitsland" },
                    { "FR", "Frankrijk" },
                    { "IT", "Italië" },
                    { "LU", "Luxemburg" },
                    { "NL", "Nederland" }
                });

            migrationBuilder.InsertData(
                table: "Docenten",
                columns: new[] { "DocentId", "CampusId", "Familienaam", "Geboortedatum", "Geslacht", "HeeftRijbewijs", "InDienst", "LandCode", "Voornaam", "Maandwedde" },
                values: new object[,]
                {
                    { 1, 4, "Abbeloos", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BE", "Willy", 1400m },
                    { 2, 2, "Abelshausen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, true, new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "BE", "Joseph", 1800m },
                    { 3, 3, "Achten", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, new DateTime(2019, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "BE", "Joseph", 1300m },
                    { 4, 1, "Adam", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new DateTime(2019, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "BE", "Francois", 1700m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campussen",
                keyColumn: "CampusId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Campussen",
                keyColumn: "CampusId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Docenten",
                keyColumn: "DocentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Docenten",
                keyColumn: "DocentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Docenten",
                keyColumn: "DocentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Docenten",
                keyColumn: "DocentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "LandCode",
                keyValue: "DE");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "LandCode",
                keyValue: "FR");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "LandCode",
                keyValue: "IT");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "LandCode",
                keyValue: "LU");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "LandCode",
                keyValue: "NL");

            migrationBuilder.DeleteData(
                table: "Campussen",
                keyColumn: "CampusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Campussen",
                keyColumn: "CampusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Campussen",
                keyColumn: "CampusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Campussen",
                keyColumn: "CampusId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "LandCode",
                keyValue: "BE");
        }
    }
}
