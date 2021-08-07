using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restabook.Data.Migrations
{
    public partial class CheckoutAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 120, nullable: false),
                    Email = table.Column<string>(maxLength: 120, nullable: false),
                    Phone = table.Column<string>(maxLength: 120, nullable: false),
                    City = table.Column<string>(maxLength: 60, nullable: false),
                    Country = table.Column<string>(maxLength: 60, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: false),
                    CardName = table.Column<string>(maxLength: 120, nullable: false),
                    CardNumber = table.Column<string>(nullable: false),
                    MM = table.Column<string>(nullable: false),
                    YY = table.Column<string>(nullable: false),
                    CVV = table.Column<string>(nullable: false),
                    AdditionalNotes = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkouts_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_AppUserId",
                table: "Checkouts",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkouts");
        }
    }
}
