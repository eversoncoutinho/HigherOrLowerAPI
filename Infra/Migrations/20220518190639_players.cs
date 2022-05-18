using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class players : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_PlayerId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Games",
                newName: "TurnPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_PlayerId",
                table: "Games",
                newName: "IX_Games_TurnPlayerId");

            migrationBuilder.AddColumn<int>(
                name: "NextPlayerId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_NextPlayerId",
                table: "Games",
                column: "NextPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_NextPlayerId",
                table: "Games",
                column: "NextPlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_TurnPlayerId",
                table: "Games",
                column: "TurnPlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_NextPlayerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_TurnPlayerId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_NextPlayerId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "NextPlayerId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "TurnPlayerId",
                table: "Games",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_TurnPlayerId",
                table: "Games",
                newName: "IX_Games_PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_PlayerId",
                table: "Games",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
