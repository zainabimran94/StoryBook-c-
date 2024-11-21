using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoryBook.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToddlerPreferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_ToddlerPreferences_ToddlerPreferencesToddlerPrefId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ToddlerPreferencesToddlerPrefId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ToddlerPreferencesToddlerPrefId",
                table: "Images");

            migrationBuilder.CreateTable(
                name: "ToddlerImageSelection",
                columns: table => new
                {
                    ToddlerPrefId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToddlerImageSelection", x => new { x.ToddlerPrefId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_ToddlerImageSelection_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToddlerImageSelection_ToddlerPreferences_ToddlerPrefId",
                        column: x => x.ToddlerPrefId,
                        principalTable: "ToddlerPreferences",
                        principalColumn: "ToddlerPrefId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToddlerImageSelection_ImageId",
                table: "ToddlerImageSelection",
                column: "ImageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToddlerImageSelection");

            migrationBuilder.AddColumn<Guid>(
                name: "ToddlerPreferencesToddlerPrefId",
                table: "Images",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ToddlerPreferencesToddlerPrefId",
                table: "Images",
                column: "ToddlerPreferencesToddlerPrefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_ToddlerPreferences_ToddlerPreferencesToddlerPrefId",
                table: "Images",
                column: "ToddlerPreferencesToddlerPrefId",
                principalTable: "ToddlerPreferences",
                principalColumn: "ToddlerPrefId");
        }
    }
}
