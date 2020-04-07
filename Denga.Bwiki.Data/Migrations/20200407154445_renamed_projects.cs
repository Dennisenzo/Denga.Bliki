using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Denga.Bwiki.Data.Migrations
{
    public partial class renamed_projects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlikiPageContents_BlikiPageMetaDatas_BlikiPageMetaDataId",
                table: "BlikiPageContents");

            migrationBuilder.DropTable(
                name: "BlikiPageMetaDatas");

            migrationBuilder.DropTable(
                name: "BlikiPageContents");

            migrationBuilder.CreateTable(
                name: "PageMetaDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LatestVersionId = table.Column<int>(nullable: true),
                    UrlTitle = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageMetaDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PageContents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageMetaDataId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    HtmlContent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageContents_PageMetaDatas_PageMetaDataId",
                        column: x => x.PageMetaDataId,
                        principalTable: "PageMetaDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PageContents_PageMetaDataId",
                table: "PageContents",
                column: "PageMetaDataId");

            migrationBuilder.CreateIndex(
                name: "IX_PageMetaDatas_LatestVersionId",
                table: "PageMetaDatas",
                column: "LatestVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_PageMetaDatas_UrlTitle",
                table: "PageMetaDatas",
                column: "UrlTitle",
                unique: true,
                filter: "[UrlTitle] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PageMetaDatas_PageContents_LatestVersionId",
                table: "PageMetaDatas",
                column: "LatestVersionId",
                principalTable: "PageContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageContents_PageMetaDatas_PageMetaDataId",
                table: "PageContents");

            migrationBuilder.DropTable(
                name: "PageMetaDatas");

            migrationBuilder.DropTable(
                name: "PageContents");

            migrationBuilder.CreateTable(
                name: "BlikiPageMetaDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LatestVersionId = table.Column<int>(type: "int", nullable: true),
                    UrlTitle = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlikiPageMetaDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlikiPageContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlikiPageMetaDataId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HtmlContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlikiPageContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlikiPageContents_BlikiPageMetaDatas_BlikiPageMetaDataId",
                        column: x => x.BlikiPageMetaDataId,
                        principalTable: "BlikiPageMetaDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlikiPageContents_BlikiPageMetaDataId",
                table: "BlikiPageContents",
                column: "BlikiPageMetaDataId");

            migrationBuilder.CreateIndex(
                name: "IX_BlikiPageMetaDatas_LatestVersionId",
                table: "BlikiPageMetaDatas",
                column: "LatestVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_BlikiPageMetaDatas_UrlTitle",
                table: "BlikiPageMetaDatas",
                column: "UrlTitle",
                unique: true,
                filter: "[UrlTitle] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BlikiPageMetaDatas_BlikiPageContents_LatestVersionId",
                table: "BlikiPageMetaDatas",
                column: "LatestVersionId",
                principalTable: "BlikiPageContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
