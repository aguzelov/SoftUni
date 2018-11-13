using Microsoft.EntityFrameworkCore.Migrations;

namespace Panda.Data.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_AspNetUsers_RecipientId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_AspNetUsers_RecipientId",
                table: "Receipts");

            migrationBuilder.RenameColumn(
                name: "RecipientId",
                table: "Receipts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_RecipientId",
                table: "Receipts",
                newName: "IX_Receipts_UserId");

            migrationBuilder.RenameColumn(
                name: "RecipientId",
                table: "Packages",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_RecipientId",
                table: "Packages",
                newName: "IX_Packages_UserId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Fee",
                table: "Receipts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_AspNetUsers_UserId",
                table: "Packages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_AspNetUsers_UserId",
                table: "Receipts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_AspNetUsers_UserId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_AspNetUsers_UserId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Receipts",
                newName: "RecipientId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_UserId",
                table: "Receipts",
                newName: "IX_Receipts_RecipientId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Packages",
                newName: "RecipientId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_UserId",
                table: "Packages",
                newName: "IX_Packages_RecipientId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Fee",
                table: "Receipts",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_AspNetUsers_RecipientId",
                table: "Packages",
                column: "RecipientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_AspNetUsers_RecipientId",
                table: "Receipts",
                column: "RecipientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}