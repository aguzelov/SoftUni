using Microsoft.EntityFrameworkCore.Migrations;

namespace SIS.Data.Migrations
{
    public partial class EditUserOrderRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Users_UserId",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_UserId",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderProducts");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "OrderProducts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_UserId",
                table: "OrderProducts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Users_UserId",
                table: "OrderProducts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}