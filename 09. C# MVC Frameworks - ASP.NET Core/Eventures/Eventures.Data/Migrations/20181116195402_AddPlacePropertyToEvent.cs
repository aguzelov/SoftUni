using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventures.Data.Migrations
{
    public partial class AddPlacePropertyToEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Place",
                table: "Events");
        }
    }
}