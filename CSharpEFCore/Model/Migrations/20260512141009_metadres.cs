using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class metadres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GemeenteThuis",
                table: "Docenten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GemeenteVerblijf",
                table: "Docenten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HuisnummerThuis",
                table: "Docenten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HuisnummerVerblijf",
                table: "Docenten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostcodeThuis",
                table: "Docenten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostcodeVerblijf",
                table: "Docenten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StraatThuis",
                table: "Docenten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StraatVerblijf",
                table: "Docenten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Straat",
                table: "Campussen",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Postcode",
                table: "Campussen",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Huisnummer",
                table: "Campussen",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Gemeente",
                table: "Campussen",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GemeenteThuis",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "GemeenteVerblijf",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "HuisnummerThuis",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "HuisnummerVerblijf",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "PostcodeThuis",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "PostcodeVerblijf",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "StraatThuis",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "StraatVerblijf",
                table: "Docenten");

            migrationBuilder.AlterColumn<string>(
                name: "Straat",
                table: "Campussen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Postcode",
                table: "Campussen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Huisnummer",
                table: "Campussen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gemeente",
                table: "Campussen",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Campussen",
                keyColumn: "CampusId",
                keyValue: 1,
                columns: new[] { "Gemeente", "Huisnummer", "Postcode", "Straat" },
                values: new object[] { "Antwerpen", "22", "2018", "Somersstraat" });

            migrationBuilder.UpdateData(
                table: "Campussen",
                keyColumn: "CampusId",
                keyValue: 2,
                columns: new[] { "Gemeente", "Huisnummer", "Postcode", "Straat" },
                values: new object[] { "Wondelgem", "50", "9032", "Industrieweg" });

            migrationBuilder.UpdateData(
                table: "Campussen",
                keyColumn: "CampusId",
                keyValue: 3,
                columns: new[] { "Gemeente", "Huisnummer", "Postcode", "Straat" },
                values: new object[] { "Genk", "37", "3600", "Europalaan" });

            migrationBuilder.UpdateData(
                table: "Campussen",
                keyColumn: "CampusId",
                keyValue: 4,
                columns: new[] { "Gemeente", "Huisnummer", "Postcode", "Straat" },
                values: new object[] { "Heverlee", "2", "3001", "Interleuvenlaan" });

            migrationBuilder.UpdateData(
                table: "Campussen",
                keyColumn: "CampusId",
                keyValue: 5,
                columns: new[] { "Gemeente", "Huisnummer", "Postcode", "Straat" },
                values: new object[] { "Wevelgem", "10", "8560", "Vlamingstraat" });

            migrationBuilder.UpdateData(
                table: "Campussen",
                keyColumn: "CampusId",
                keyValue: 6,
                columns: new[] { "Gemeente", "Huisnummer", "Postcode", "Straat" },
                values: new object[] { "Oostende", "4", "8400", "Akkerstraat" });
        }
    }
}
