using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoryBook.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePref : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSelectPreferences_Images_ImageId",
                table: "UserSelectPreferences");

            migrationBuilder.DropIndex(
                name: "IX_UserSelectPreferences_ImageId",
                table: "UserSelectPreferences");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "UserSelectPreferences");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "UserSelectPreferences",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSelectPreferences_ImageId",
                table: "UserSelectPreferences",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSelectPreferences_Images_ImageId",
                table: "UserSelectPreferences",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "ImageId");
        }
    }
}
