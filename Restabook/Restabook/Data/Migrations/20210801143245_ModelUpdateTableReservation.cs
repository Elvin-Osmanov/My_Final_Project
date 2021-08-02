using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restabook.Data.Migrations
{
    public partial class ModelUpdateTableReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Reservations",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Reservations",
                maxLength: 110,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Reservations",
                maxLength: 110,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Reservations",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Reservations",
                maxLength: 110,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservationTime",
                table: "Reservations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_AppUserId",
                table: "Reservations",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_AppUserId",
                table: "Reservations",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_AppUserId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_AppUserId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationTime",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations",
                column: "TableId",
                unique: true);
        }
    }
}
