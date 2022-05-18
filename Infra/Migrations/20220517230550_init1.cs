using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Challenges_ChallengeId",
                table: "Games");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Challenges_ChallengeId",
                table: "Games",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Challenges_ChallengeId",
                table: "Games");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Challenges_ChallengeId",
                table: "Games",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
