using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class game2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "result",
                table: "Games",
                newName: "Result");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Result",
                table: "Games",
                newName: "result");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
