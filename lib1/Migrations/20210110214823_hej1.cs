using Microsoft.EntityFrameworkCore.Migrations;

namespace lib1.Migrations
{
    public partial class hej1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phonenumber",
                table: "Members",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Phonenumber",
                table: "Members",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
