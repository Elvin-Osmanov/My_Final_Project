using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restabook.Data.Migrations
{
    public partial class SeveralModelsCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfilePhoto",
                table: "Testimonials",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Chefs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    FullName = table.Column<string>(maxLength: 100, nullable: false),
                    Country = table.Column<string>(maxLength: 70, nullable: false),
                    Desc = table.Column<string>(maxLength: 250, nullable: false),
                    FacebookUrl = table.Column<string>(maxLength: 150, nullable: false),
                    InstagramUrl = table.Column<string>(maxLength: 150, nullable: false),
                    VkUrl = table.Column<string>(maxLength: 150, nullable: false),
                    TwitterUrl = table.Column<string>(maxLength: 150, nullable: false),
                    Photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chefs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CouponName = table.Column<string>(maxLength: 10, nullable: true),
                    CouponDiscount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 150, nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false),
                    Desc = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Desc = table.Column<string>(maxLength: 200, nullable: true),
                    Icon = table.Column<string>(maxLength: 100, nullable: false),
                    BackgroundPhoto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    HeaderLogo = table.Column<string>(nullable: true),
                    FooterLogo = table.Column<string>(nullable: true),
                    FooterDesc = table.Column<string>(maxLength: 200, nullable: true),
                    VideoRedirectUrl = table.Column<string>(maxLength: 150, nullable: false),
                    FacebookUrl = table.Column<string>(maxLength: 100, nullable: true),
                    TwitterUrl = table.Column<string>(maxLength: 100, nullable: true),
                    VimeoUrl = table.Column<string>(maxLength: 100, nullable: true),
                    PinterestUrl = table.Column<string>(maxLength: 100, nullable: true),
                    StartDay1 = table.Column<string>(maxLength: 150, nullable: false),
                    StartTime1 = table.Column<string>(maxLength: 150, nullable: false),
                    OverDay1 = table.Column<string>(maxLength: 150, nullable: false),
                    OverTime1 = table.Column<string>(maxLength: 150, nullable: false),
                    StartDay2 = table.Column<string>(maxLength: 150, nullable: false),
                    StartTime2 = table.Column<string>(maxLength: 150, nullable: false),
                    OverDay2 = table.Column<string>(maxLength: 150, nullable: false),
                    OverTime2 = table.Column<string>(maxLength: 150, nullable: false),
                    Address = table.Column<string>(maxLength: 150, nullable: false),
                    ServicePhone = table.Column<string>(maxLength: 150, nullable: false),
                    SupportEmail = table.Column<string>(maxLength: 150, nullable: false),
                    SupportPhone = table.Column<string>(maxLength: 150, nullable: false),
                    AboutStory = table.Column<string>(maxLength: 5000, nullable: false),
                    AboutPhoto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chefs");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePhoto",
                table: "Testimonials",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
