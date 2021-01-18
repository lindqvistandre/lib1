using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lib1.Migrations
{
    public partial class hejsan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RentDue",
                table: "Rentals",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentDue",
                table: "Rentals");
        }
    }
}
