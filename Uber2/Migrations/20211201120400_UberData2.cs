using Microsoft.EntityFrameworkCore.Migrations;

namespace Uber2.Migrations
{
    public partial class UberData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isLogged",
                table: "Drivers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isLogged",
                table: "Customers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isLogged",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "isLogged",
                table: "Customers");
        }
    }
}
