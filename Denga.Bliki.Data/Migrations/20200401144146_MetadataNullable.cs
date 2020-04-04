using Microsoft.EntityFrameworkCore.Migrations;

namespace Denga.Bliki.Data.Migrations
{
    public partial class MetadataNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlikiPageMetaDatas_BlikiPageContents_LatestVersionId",
                table: "BlikiPageMetaDatas");

            migrationBuilder.AlterColumn<int>(
                name: "LatestVersionId",
                table: "BlikiPageMetaDatas",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BlikiPageMetaDatas_BlikiPageContents_LatestVersionId",
                table: "BlikiPageMetaDatas",
                column: "LatestVersionId",
                principalTable: "BlikiPageContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlikiPageMetaDatas_BlikiPageContents_LatestVersionId",
                table: "BlikiPageMetaDatas");

            migrationBuilder.AlterColumn<int>(
                name: "LatestVersionId",
                table: "BlikiPageMetaDatas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlikiPageMetaDatas_BlikiPageContents_LatestVersionId",
                table: "BlikiPageMetaDatas",
                column: "LatestVersionId",
                principalTable: "BlikiPageContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
