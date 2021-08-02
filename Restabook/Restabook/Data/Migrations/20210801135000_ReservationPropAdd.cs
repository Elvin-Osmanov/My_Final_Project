using Microsoft.EntityFrameworkCore.Migrations;

namespace Restabook.Data.Migrations
{
    public partial class ReservationPropAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Reservations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "CustomerName",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
