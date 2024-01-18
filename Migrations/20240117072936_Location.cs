using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laszlo_Sebastian_Proiect.Migrations
{
    public partial class Location : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Tattoo");

            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "Tattoo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tattoo_LocationID",
                table: "Tattoo",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tattoo_Location_LocationID",
                table: "Tattoo",
                column: "LocationID",
                principalTable: "Location",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tattoo_Location_LocationID",
                table: "Tattoo");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Tattoo_LocationID",
                table: "Tattoo");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Tattoo");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Tattoo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
