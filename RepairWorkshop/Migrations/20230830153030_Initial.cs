using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairWorkshopEmployee.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id_employee = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    phone = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    address = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    fullname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id_employee);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    id_price = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.id_price);
                });

            migrationBuilder.CreateTable(
                name: "TechOwners",
                columns: table => new
                {
                    id_owner = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fullname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechOwners", x => x.id_owner);
                });

            migrationBuilder.CreateTable(
                name: "TechTypes",
                columns: table => new
                {
                    id_type = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 10, nullable: false),
                    manufacturer = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechTypes", x => x.id_type);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id_order = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_type = table.Column<int>(type: "INTEGER", nullable: false),
                    id_owner = table.Column<int>(type: "INTEGER", nullable: false),
                    id_employee = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    deadline = table.Column<DateTime>(type: "date", nullable: false),
                    malfunction_description = table.Column<string>(type: "TEXT", maxLength: 400, nullable: false),
                    description_by_owner = table.Column<string>(type: "TEXT", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id_order);
                    table.ForeignKey(
                        name: "FK_Orders_Employees",
                        column: x => x.id_employee,
                        principalTable: "Employees",
                        principalColumn: "id_employee");
                    table.ForeignKey(
                        name: "FK_Orders_TechOwners",
                        column: x => x.id_owner,
                        principalTable: "TechOwners",
                        principalColumn: "id_owner");
                    table.ForeignKey(
                        name: "FK_Orders_TechTypes",
                        column: x => x.id_type,
                        principalTable: "TechTypes",
                        principalColumn: "id_type");
                });

            migrationBuilder.CreateTable(
                name: "Receips",
                columns: table => new
                {
                    id_receip = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_order = table.Column<int>(type: "INTEGER", nullable: true),
                    id_price = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receips", x => x.id_receip);
                    table.ForeignKey(
                        name: "FK_Receips_Orders",
                        column: x => x.id_order,
                        principalTable: "Orders",
                        principalColumn: "id_order");
                    table.ForeignKey(
                        name: "FK_Receips_Prices",
                        column: x => x.id_price,
                        principalTable: "Prices",
                        principalColumn: "id_price");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_id_employee",
                table: "Orders",
                column: "id_employee");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_id_owner",
                table: "Orders",
                column: "id_owner");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_id_type",
                table: "Orders",
                column: "id_type");

            migrationBuilder.CreateIndex(
                name: "IX_Receips_id_order",
                table: "Receips",
                column: "id_order");

            migrationBuilder.CreateIndex(
                name: "IX_Receips_id_price",
                table: "Receips",
                column: "id_price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receips");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "TechOwners");

            migrationBuilder.DropTable(
                name: "TechTypes");
        }
    }
}
