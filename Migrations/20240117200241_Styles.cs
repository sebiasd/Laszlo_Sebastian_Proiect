using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laszlo_Sebastian_Proiect.Migrations
{
    public partial class Styles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StyleID",
                table: "TattooArtist",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StyleID",
                table: "Tattoo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Style",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Style", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TattooArtist_StyleID",
                table: "TattooArtist",
                column: "StyleID");

            migrationBuilder.CreateIndex(
                name: "IX_Tattoo_StyleID",
                table: "Tattoo",
                column: "StyleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tattoo_Style_StyleID",
                table: "Tattoo",
                column: "StyleID",
                principalTable: "Style",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TattooArtist_Style_StyleID",
                table: "TattooArtist",
                column: "StyleID",
                principalTable: "Style",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tattoo_Style_StyleID",
                table: "Tattoo");

            migrationBuilder.DropForeignKey(
                name: "FK_TattooArtist_Style_StyleID",
                table: "TattooArtist");

            migrationBuilder.DropTable(
                name: "Style");

            migrationBuilder.DropIndex(
                name: "IX_TattooArtist_StyleID",
                table: "TattooArtist");

            migrationBuilder.DropIndex(
                name: "IX_Tattoo_StyleID",
                table: "Tattoo");

            migrationBuilder.DropColumn(
                name: "StyleID",
                table: "TattooArtist");

            migrationBuilder.DropColumn(
                name: "StyleID",
                table: "Tattoo");
        }
    }
}
