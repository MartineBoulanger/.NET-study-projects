using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class seeding_change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Campussen",
                keyColumn: "CampusId",
                keyValue: 2,
                columns: new[] { "Gemeente", "Huisnummer", "Postcode", "Straat" },
                values: new object[] { "Wondelgem", "50", "9032", "Industrieweg" });

            migrationBuilder.InsertData(
                table: "Landen",
                columns: new[] { "LandCode", "Naam" },
                values: new object[] { "GB", "Groot-Brittannië" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "LandCode",
                keyValue: "GB");

            migrationBuilder.UpdateData(
                table: "Campussen",
                keyColumn: "CampusId",
                keyValue: 2,
                columns: new[] { "Gemeente", "Huisnummer", "Postcode", "Straat" },
                values: new object[] { "Dendermonde", "17", "9200", "Oude Vest" });
        }
    }
}
