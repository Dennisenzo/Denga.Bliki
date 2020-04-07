using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Denga.Bliki.Data.Migrations
{
    public partial class datetimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "BlikiPageMetaDatas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "BlikiPageContents",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BlikiPageMetaDatas");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BlikiPageContents");
        }
    }
}
