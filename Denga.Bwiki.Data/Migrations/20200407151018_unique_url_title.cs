using Microsoft.EntityFrameworkCore.Migrations;

namespace Denga.Bwiki.Data.Migrations
{
    public partial class unique_url_title : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UrlTitle",
                table: "BlikiPageMetaDatas",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlikiPageMetaDatas_UrlTitle",
                table: "BlikiPageMetaDatas",
                column: "UrlTitle",
                unique: true,
                filter: "[UrlTitle] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BlikiPageMetaDatas_UrlTitle",
                table: "BlikiPageMetaDatas");

            migrationBuilder.AlterColumn<string>(
                name: "UrlTitle",
                table: "BlikiPageMetaDatas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
