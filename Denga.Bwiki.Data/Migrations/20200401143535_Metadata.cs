using Microsoft.EntityFrameworkCore.Migrations;

namespace Denga.Bwiki.Data.Migrations
{
    public partial class Metadata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlikiPages");

            migrationBuilder.CreateTable(
                name: "BlikiPageMetaDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlTitle = table.Column<string>(nullable: true),
                    LatestVersionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlikiPageMetaDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlikiPageContents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlikiPageMetaDataId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UrlTitle = table.Column<string>(nullable: true),
                    HtmlContent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlikiPageContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlikiPageContents_BlikiPageMetaDatas_BlikiPageMetaDataId",
                        column: x => x.BlikiPageMetaDataId,
                        principalTable: "BlikiPageMetaDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlikiPageContents_BlikiPageMetaDataId",
                table: "BlikiPageContents",
                column: "BlikiPageMetaDataId");

            migrationBuilder.CreateIndex(
                name: "IX_BlikiPageMetaDatas_LatestVersionId",
                table: "BlikiPageMetaDatas",
                column: "LatestVersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlikiPageMetaDatas_BlikiPageContents_LatestVersionId",
                table: "BlikiPageMetaDatas",
                column: "LatestVersionId",
                principalTable: "BlikiPageContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlikiPageContents_BlikiPageMetaDatas_BlikiPageMetaDataId",
                table: "BlikiPageContents");

            migrationBuilder.DropTable(
                name: "BlikiPageMetaDatas");

            migrationBuilder.DropTable(
                name: "BlikiPageContents");

            migrationBuilder.CreateTable(
                name: "BlikiPages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HtmlContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlikiPages", x => x.Id);
                });
        }
    }
}