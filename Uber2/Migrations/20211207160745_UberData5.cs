using Microsoft.EntityFrameworkCore.Migrations;

namespace Uber2.Migrations
{
    public partial class UberData5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAccepted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "isCompleted",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Orders",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "isAccepted",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isCompleted",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
