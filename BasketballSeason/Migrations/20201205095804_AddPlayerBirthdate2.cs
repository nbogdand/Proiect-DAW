using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketballSeason.Migrations
{
    public partial class AddPlayerBirthdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "User");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "Player",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Player");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
