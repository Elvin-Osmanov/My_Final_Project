using Microsoft.EntityFrameworkCore.Migrations;

namespace Restabook.Data.Migrations
{
    public partial class SeveralModelsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PinterestUrl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "VimeoUrl",
                table: "Settings");

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "Settings",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VkUrl",
                table: "Settings",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "VkUrl",
                table: "Settings");

            migrationBuilder.AddColumn<string>(
                name: "PinterestUrl",
                table: "Settings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VimeoUrl",
                table: "Settings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
