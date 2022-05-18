using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class winner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WinnerId",
                table: "Challenges",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_WinnerId",
                table: "Challenges",
                column: "WinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenges_Players_WinnerId",
                table: "Challenges",
                column: "WinnerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challenges_Players_WinnerId",
                table: "Challenges");

            migrationBuilder.DropIndex(
                name: "IX_Challenges_WinnerId",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "Challenges");
        }
    }
}
