using Microsoft.EntityFrameworkCore.Migrations;

namespace Denga.Bliki.Data.Migrations
{
    public partial class RemovedURlTitleFromContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlTitle",
                table: "BlikiPageContents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlTitle",
                table: "BlikiPageContents",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
