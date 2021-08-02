using Microsoft.EntityFrameworkCore.Migrations;

namespace Restabook.Data.Migrations
{
    public partial class PdfPropToSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookPdfUrl",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookPdfUrl",
                table: "Settings");
        }
    }
}
