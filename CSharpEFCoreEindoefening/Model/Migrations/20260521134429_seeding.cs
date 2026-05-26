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
                table: "Landen",
                columns: new[] { "ISOLandCode", "AantalInwoners", "NISLandCode", "Naam", "Oppervlakte" },
                values: new object[,]
                {
                    { "AT", 8754413, "105", "Oostenrijk", 83871f },
                    { "BE", 11500000, "150", "België", 30689f },
                    { "CH", 8236303, "127", "Zwitserland", 41285f },
                    { "DE", 80594017, "103", "Duitsland", 357022f },
                    { "DK", 5605948, "108", "Denemarken", 43094f },
                    { "ES", 48958159, "109", "Spanje", 505992f },
                    { "FR", 62814233, "111", "Frankrijk", 674843f },
                    { "GB", 64769452, "112", "Verenigd Koninkrijk", 242495f },
                    { "IT", 62137802, "128", "Italië", 300000f },
                    { "LU", 594130, "113", "Luxemburg", 2586f },
                    { "NL", 17424978, "129", "Nederland", 41873f },
                    { "NO", 5367580, "121", "Noorwegen", 385207f },
                    { "PL", 38476269, "139", "Polen", 311888f },
                    { "PT", 10839541, "123", "Portugal", 92212f },
                    { "SE", 9960487, "126", "Zweden", 450295f },
                    { "UA", 43922939, "380", "Oekraïne", 603500f },
                    { "US", 326625791, "402", "Verenigde Staten", 9826675f }
                });

            migrationBuilder.InsertData(
                table: "Talen",
                columns: new[] { "ISOTaalCode", "NaamNL", "NaamTaal" },
                values: new object[,]
                {
                    { "bg", "Bulgaars", "български" },
                    { "cs", "Tsjechisch", "čeština" },
                    { "da", "Deens", "dansk" },
                    { "de", "Duits", "Deutsch" },
                    { "el", "Grieks", "ελληνικά" },
                    { "en", "Engels", "English" },
                    { "es", "Spaans", "español" },
                    { "et", "Ests", "eesti keel" },
                    { "fi", "Fins", "suomi" },
                    { "fr", "Frans", "français" },
                    { "ga", "Iers", "Gaeilge" },
                    { "hu", "Hongaars", "magyar" },
                    { "it", "Italiaans", "italiano" },
                    { "lt", "Litouws", "lietuvių kalba" },
                    { "lv", "Lets", "latviešu valoda" },
                    { "mt", "Maltees", "malti" },
                    { "nl", "Nederlands", "Nederlands" },
                    { "pl", "Pools", "polski" },
                    { "pt", "Portugees", "português" },
                    { "ro", "Roemeens", "română" },
                    { "sk", "Slovaaks", "slovenčina" },
                    { "sl", "Sloveens", "slovenščina" },
                    { "sv", "Zweeds", "svenska" },
                    { "uk", "Oekraïens", "Soerzjyk" }
                });

            migrationBuilder.InsertData(
                table: "LandenTalen",
                columns: new[] { "LandCode", "TaalCode" },
                values: new object[,]
                {
                    { "BE", "de" },
                    { "BE", "fr" },
                    { "BE", "nl" },
                    { "DE", "de" },
                    { "FR", "fr" },
                    { "LU", "de" },
                    { "LU", "fr" },
                    { "NL", "nl" }
                });

            migrationBuilder.InsertData(
                table: "Steden",
                columns: new[] { "StadId", "ISOLandCode", "Naam" },
                values: new object[,]
                {
                    { 1, "BE", "Brussel" },
                    { 2, "BE", "Antwerpen" },
                    { 3, "BE", "Luik" },
                    { 4, "NL", "Amsterdam" },
                    { 5, "NL", "Den Haag" },
                    { 6, "NL", "Rotterdam" },
                    { 7, "DE", "Berlijn" },
                    { 8, "DE", "Hamburg" },
                    { 9, "DE", "München" },
                    { 10, "LU", "Luxemburg" },
                    { 11, "FR", "Parijs" },
                    { 12, "FR", "Marseille" },
                    { 13, "FR", "Lyon" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "ISOLandCode",
                keyValue: "AT");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "ISOLandCode",
                keyValue: "CH");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "ISOLandCode",
                keyValue: "DK");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "ISOLandCode",
                keyValue: "ES");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "ISOLandCode",
                keyValue: "GB");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "ISOLandCode",
                keyValue: "IT");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "ISOLandCode",
                keyValue: "NO");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "ISOLandCode",
                keyValue: "PL");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "ISOLandCode",
                keyValue: "PT");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "ISOLandCode",
                keyValue: "SE");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "ISOLandCode",
                keyValue: "UA");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "ISOLandCode",
                keyValue: "US");

            migrationBuilder.DeleteData(
                table: "LandenTalen",
                keyColumns: new[] { "LandCode", "TaalCode" },
                keyValues: new object[] { "BE", "de" });

            migrationBuilder.DeleteData(
                table: "LandenTalen",
                keyColumns: new[] { "LandCode", "TaalCode" },
                keyValues: new object[] { "BE", "fr" });

            migrationBuilder.DeleteData(
                table: "LandenTalen",
                keyColumns: new[] { "LandCode", "TaalCode" },
                keyValues: new object[] { "BE", "nl" });

            migrationBuilder.DeleteData(
                table: "LandenTalen",
                keyColumns: new[] { "LandCode", "TaalCode" },
                keyValues: new object[] { "DE", "de" });

            migrationBuilder.DeleteData(
                table: "LandenTalen",
                keyColumns: new[] { "LandCode", "TaalCode" },
                keyValues: new object[] { "FR", "fr" });

            migrationBuilder.DeleteData(
                table: "LandenTalen",
                keyColumns: new[] { "LandCode", "TaalCode" },
                keyValues: new object[] { "LU", "de" });

            migrationBuilder.DeleteData(
                table: "LandenTalen",
                keyColumns: new[] { "LandCode", "TaalCode" },
                keyValues: new object[] { "LU", "fr" });

            migrationBuilder.DeleteData(
                table: "LandenTalen",
                keyColumns: new[] { "LandCode", "TaalCode" },
                keyValues: new object[] { "NL", "nl" });

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "bg");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "cs");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "da");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "el");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "en");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "es");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "et");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "fi");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "ga");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "hu");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "it");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "lt");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "lv");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "mt");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "pl");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "pt");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "ro");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "sk");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "sl");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "sv");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "uk");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "ISOLandCode",
                keyValue: "BE");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "ISOLandCode",
                keyValue: "DE");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "ISOLandCode",
                keyValue: "FR");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "ISOLandCode",
                keyValue: "LU");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "ISOLandCode",
                keyValue: "NL");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "de");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "fr");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "ISOTaalCode",
                keyValue: "nl");
        }
    }
}
