using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class ondelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Docenten_Landen_LandCode",
                table: "Docenten");

            migrationBuilder.AlterColumn<string>(
                name: "LandCode",
                table: "Docenten",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Docenten_Landen_LandCode",
                table: "Docenten",
                column: "LandCode",
                principalTable: "Landen",
                principalColumn: "LandCode",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Docenten_Landen_LandCode",
                table: "Docenten");

            migrationBuilder.AlterColumn<string>(
                name: "LandCode",
                table: "Docenten",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Docenten_Landen_LandCode",
                table: "Docenten",
                column: "LandCode",
                principalTable: "Landen",
                principalColumn: "LandCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
