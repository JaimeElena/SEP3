using Microsoft.EntityFrameworkCore.Migrations;

namespace Uber2.Migrations
{
    public partial class UberData4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFree",
                table: "Drivers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    customerLocationid = table.Column<int>(type: "INTEGER", nullable: true),
                    destinationid = table.Column<int>(type: "INTEGER", nullable: true),
                    customerid = table.Column<int>(type: "INTEGER", nullable: true),
                    driverid = table.Column<int>(type: "INTEGER", nullable: true),
                    status = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_customerid",
                        column: x => x.customerid,
                        principalTable: "Customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Drivers_driverid",
                        column: x => x.driverid,
                        principalTable: "Drivers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Location_customerLocationid",
                        column: x => x.customerLocationid,
                        principalTable: "Location",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Location_destinationid",
                        column: x => x.destinationid,
                        principalTable: "Location",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropColumn(
                name: "isFree",
                table: "Drivers");
        }
    }
}
