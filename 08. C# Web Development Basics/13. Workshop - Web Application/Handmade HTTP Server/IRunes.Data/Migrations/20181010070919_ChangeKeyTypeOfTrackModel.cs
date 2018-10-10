using Microsoft.EntityFrameworkCore.Migrations;

namespace IRunes.Data.Migrations
{
    public partial class ChangeKeyTypeOfTrackModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Albums_AlbumId1",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_AlbumId1",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "AlbumId1",
                table: "Tracks");

            migrationBuilder.AlterColumn<string>(
                name: "AlbumId",
                table: "Tracks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_AlbumId",
                table: "Tracks",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Albums_AlbumId",
                table: "Tracks",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Albums_AlbumId",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_AlbumId",
                table: "Tracks");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Tracks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlbumId1",
                table: "Tracks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_AlbumId1",
                table: "Tracks",
                column: "AlbumId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Albums_AlbumId1",
                table: "Tracks",
                column: "AlbumId1",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}