using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class CardOntable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Cards_CardInTableId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "CardInTableId",
                table: "Games",
                newName: "CardOnTableId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_CardInTableId",
                table: "Games",
                newName: "IX_Games_CardOnTableId");

            migrationBuilder.AddColumn<int>(
                name: "DeckId",
                table: "Challenges",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_DeckId",
                table: "Challenges",
                column: "DeckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenges_Decks_DeckId",
                table: "Challenges",
                column: "DeckId",
                principalTable: "Decks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Cards_CardOnTableId",
                table: "Games",
                column: "CardOnTableId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challenges_Decks_DeckId",
                table: "Challenges");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Cards_CardOnTableId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Challenges_DeckId",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "DeckId",
                table: "Challenges");

            migrationBuilder.RenameColumn(
                name: "CardOnTableId",
                table: "Games",
                newName: "CardInTableId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_CardOnTableId",
                table: "Games",
                newName: "IX_Games_CardInTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Cards_CardInTableId",
                table: "Games",
                column: "CardInTableId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
