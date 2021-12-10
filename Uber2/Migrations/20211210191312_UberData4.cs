using Microsoft.EntityFrameworkCore.Migrations;

namespace Uber2.Migrations
{
    public partial class UberData4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "birthday",
                table: "Drivers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "firstname",
                table: "Drivers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isFree",
                table: "Drivers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "numberPlate",
                table: "Drivers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "secondname",
                table: "Drivers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sex",
                table: "Drivers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    customerStreetName = table.Column<string>(type: "TEXT", nullable: true),
                    destinationStreetName = table.Column<string>(type: "TEXT", nullable: true),
                    customer = table.Column<string>(type: "TEXT", nullable: true),
                    driver = table.Column<string>(type: "TEXT", nullable: true),
                    status = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropColumn(
                name: "birthday",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "firstname",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "isFree",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "numberPlate",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "secondname",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "sex",
                table: "Drivers");
        }
    }
}
