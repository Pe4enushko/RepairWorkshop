using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairWorkshopEmployee.Migrations
{
    /// <inheritdoc />
    public partial class foreign_keys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTechType",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTechType",
                table: "Orders");
        }
    }
}
