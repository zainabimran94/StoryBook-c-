using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoryBook.Migrations
{
    /// <inheritdoc />
    public partial class updatePython : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoryBook",
                table: "StoriesGenerated");

            migrationBuilder.DropColumn(
                name: "StoryGenTitle",
                table: "StoriesGenerated");

            migrationBuilder.DropColumn(
                name: "StoryImageUrl",
                table: "StoriesGenerated");

            migrationBuilder.AddColumn<Guid>(
                name: "PythonDataId",
                table: "StoriesGenerated",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PythonData",
                columns: table => new
                {
                    PythonDataId = table.Column<Guid>(type: "uuid", nullable: false),
                    StoryGenTitle = table.Column<string>(type: "text", nullable: false),
                    StoryBook = table.Column<string>(type: "text", nullable: false),
                    StoryImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PythonData", x => x.PythonDataId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoriesGenerated_PythonDataId",
                table: "StoriesGenerated",
                column: "PythonDataId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StoriesGenerated_PythonData_PythonDataId",
                table: "StoriesGenerated",
                column: "PythonDataId",
                principalTable: "PythonData",
                principalColumn: "PythonDataId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoriesGenerated_PythonData_PythonDataId",
                table: "StoriesGenerated");

            migrationBuilder.DropTable(
                name: "PythonData");

            migrationBuilder.DropIndex(
                name: "IX_StoriesGenerated_PythonDataId",
                table: "StoriesGenerated");

            migrationBuilder.DropColumn(
                name: "PythonDataId",
                table: "StoriesGenerated");

            migrationBuilder.AddColumn<string>(
                name: "StoryBook",
                table: "StoriesGenerated",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StoryGenTitle",
                table: "StoriesGenerated",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StoryImageUrl",
                table: "StoriesGenerated",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
