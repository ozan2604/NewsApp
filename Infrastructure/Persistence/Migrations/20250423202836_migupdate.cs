using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "AiLogs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AiLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedAt",
                table: "AiLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AiLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AiLogCategory",
                columns: table => new
                {
                    AiLogsListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AiLogCategory", x => new { x.AiLogsListId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_AiLogCategory_AiLogs_AiLogsListId",
                        column: x => x.AiLogsListId,
                        principalTable: "AiLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AiLogCategory_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AiLogTag",
                columns: table => new
                {
                    AiLogsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AiLogTag", x => new { x.AiLogsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_AiLogTag_AiLogs_AiLogsId",
                        column: x => x.AiLogsId,
                        principalTable: "AiLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AiLogTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AiLogs_AuthorId",
                table: "AiLogs",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AiLogCategory_CategoriesId",
                table: "AiLogCategory",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_AiLogTag_TagsId",
                table: "AiLogTag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AiLogs_AppUsers_AuthorId",
                table: "AiLogs",
                column: "AuthorId",
                principalTable: "AppUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AiLogs_AppUsers_AuthorId",
                table: "AiLogs");

            migrationBuilder.DropTable(
                name: "AiLogCategory");

            migrationBuilder.DropTable(
                name: "AiLogTag");

            migrationBuilder.DropIndex(
                name: "IX_AiLogs_AuthorId",
                table: "AiLogs");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "AiLogs");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AiLogs");

            migrationBuilder.DropColumn(
                name: "PublishedAt",
                table: "AiLogs");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AiLogs");
        }
    }
}
