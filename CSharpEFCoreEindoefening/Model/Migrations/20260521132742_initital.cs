using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class initital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Landen",
                columns: table => new
                {
                    ISOLandCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    NISLandCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Naam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AantalInwoners = table.Column<int>(type: "int", nullable: false),
                    Oppervlakte = table.Column<float>(type: "real", nullable: false),
                    Aangepast = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landen", x => x.ISOLandCode);
                });

            migrationBuilder.CreateTable(
                name: "Talen",
                columns: table => new
                {
                    ISOTaalCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    NaamNL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NaamTaal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talen", x => x.ISOTaalCode);
                });

            migrationBuilder.CreateTable(
                name: "Steden",
                columns: table => new
                {
                    StadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ISOLandCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Aangepast = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steden", x => x.StadId);
                    table.ForeignKey(
                        name: "FK_Steden_Landen_ISOLandCode",
                        column: x => x.ISOLandCode,
                        principalTable: "Landen",
                        principalColumn: "ISOLandCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LandenTalen",
                columns: table => new
                {
                    LandCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    TaalCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandenTalen", x => new { x.LandCode, x.TaalCode });
                    table.ForeignKey(
                        name: "FK_LandenTalen_Landen_LandCode",
                        column: x => x.LandCode,
                        principalTable: "Landen",
                        principalColumn: "ISOLandCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LandenTalen_Talen_TaalCode",
                        column: x => x.TaalCode,
                        principalTable: "Talen",
                        principalColumn: "ISOTaalCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Landen_Naam",
                table: "Landen",
                column: "Naam",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Landen_NISLandCode",
                table: "Landen",
                column: "NISLandCode",
                unique: true,
                filter: "[NISLandCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LandenTalen_TaalCode",
                table: "LandenTalen",
                column: "TaalCode");

            migrationBuilder.CreateIndex(
                name: "IX_Steden_ISOLandCode",
                table: "Steden",
                column: "ISOLandCode");

            migrationBuilder.CreateIndex(
                name: "IX_Steden_Naam",
                table: "Steden",
                column: "Naam",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Talen_NaamNL",
                table: "Talen",
                column: "NaamNL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Talen_NaamTaal",
                table: "Talen",
                column: "NaamTaal",
                unique: true,
                filter: "[NaamTaal] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LandenTalen");

            migrationBuilder.DropTable(
                name: "Steden");

            migrationBuilder.DropTable(
                name: "Talen");

            migrationBuilder.DropTable(
                name: "Landen");
        }
    }
}
