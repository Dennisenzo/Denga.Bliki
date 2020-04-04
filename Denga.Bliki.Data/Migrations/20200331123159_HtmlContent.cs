using Microsoft.EntityFrameworkCore.Migrations;

namespace Denga.Bliki.Data.Migrations
{
    public partial class HtmlContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HtmlContent",
                table: "BlikiPages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HtmlContent",
                table: "BlikiPages");
        }
    }
}
