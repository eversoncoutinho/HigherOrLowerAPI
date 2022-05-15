using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class CardsList3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //script to create the deck with 52 card in database. jokey=11, queen=12, king=13 and ace=14
            for (int v = 2; v < 15; v++)
            {
                for (int n = 0; n <= 3; n++)
                {
                    migrationBuilder.Sql($"Insert into Cards(Value,Nipe) Values('{v}','{n}')");
                }
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
