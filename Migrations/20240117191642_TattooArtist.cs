using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laszlo_Sebastian_Proiect.Migrations
{
    public partial class TattooArtist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TattooArtist",
                table: "Tattoo");

            migrationBuilder.AddColumn<int>(
                name: "TattooArtistID",
                table: "Tattoo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TattooArtist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TattooArtist", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TattooArtist_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tattoo_TattooArtistID",
                table: "Tattoo",
                column: "TattooArtistID");

            migrationBuilder.CreateIndex(
                name: "IX_TattooArtist_LocationID",
                table: "TattooArtist",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tattoo_TattooArtist_TattooArtistID",
                table: "Tattoo",
                column: "TattooArtistID",
                principalTable: "TattooArtist",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tattoo_TattooArtist_TattooArtistID",
                table: "Tattoo");

            migrationBuilder.DropTable(
                name: "TattooArtist");

            migrationBuilder.DropIndex(
                name: "IX_Tattoo_TattooArtistID",
                table: "Tattoo");

            migrationBuilder.DropColumn(
                name: "TattooArtistID",
                table: "Tattoo");

            migrationBuilder.AddColumn<string>(
                name: "TattooArtist",
                table: "Tattoo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
