using Microsoft.EntityFrameworkCore.Migrations;

namespace Restabook.Data.Migrations
{
    public partial class SettingShippingAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ShippingCost",
                table: "Settings",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingCost",
                table: "Settings");
        }
    }
}
