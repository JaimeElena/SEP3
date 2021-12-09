using Microsoft.EntityFrameworkCore.Migrations;

namespace Uber2.Migrations
{
    public partial class UberData5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_customerid",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Drivers_driverid",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Location_customerLocationid",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Location_destinationid",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Orders_customerid",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_customerLocationid",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_destinationid",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_driverid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "customerLocationid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "customerid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "destinationid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "driverid",
                table: "Orders");

            migrationBuilder.AddColumn<double>(
                name: "clat",
                table: "Orders",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "clng",
                table: "Orders",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "customer",
                table: "Orders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "dlat",
                table: "Orders",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "dlng",
                table: "Orders",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "driver",
                table: "Orders",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clat",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "clng",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "customer",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "dlat",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "dlng",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "driver",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "customerLocationid",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "customerid",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "destinationid",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "driverid",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    lat = table.Column<double>(type: "REAL", nullable: false),
                    lng = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customerid",
                table: "Orders",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customerLocationid",
                table: "Orders",
                column: "customerLocationid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_destinationid",
                table: "Orders",
                column: "destinationid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_driverid",
                table: "Orders",
                column: "driverid");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_customerid",
                table: "Orders",
                column: "customerid",
                principalTable: "Customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Drivers_driverid",
                table: "Orders",
                column: "driverid",
                principalTable: "Drivers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Location_customerLocationid",
                table: "Orders",
                column: "customerLocationid",
                principalTable: "Location",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Location_destinationid",
                table: "Orders",
                column: "destinationid",
                principalTable: "Location",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
