﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class CardsList2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            for (int v = 14; v < 15; v++)
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
