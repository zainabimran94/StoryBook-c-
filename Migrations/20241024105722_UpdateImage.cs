using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoryBook.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserStoryPreferences_UserSelectPreferences_UserSelectPrefer~",
                table: "UserStoryPreferences");

            migrationBuilder.DropIndex(
                name: "IX_UserStoryPreferences_UserSelectPreferencesUserSelectPrefId",
                table: "UserStoryPreferences");

            migrationBuilder.DropColumn(
                name: "UserSelectPreferencesUserSelectPrefId",
                table: "UserStoryPreferences");

            migrationBuilder.AddColumn<string>(
                name: "ImageDesc",
                table: "UserSelectPreferences",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageDesc",
                table: "UserSelectPreferences");

            migrationBuilder.AddColumn<Guid>(
                name: "UserSelectPreferencesUserSelectPrefId",
                table: "UserStoryPreferences",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserStoryPreferences_UserSelectPreferencesUserSelectPrefId",
                table: "UserStoryPreferences",
                column: "UserSelectPreferencesUserSelectPrefId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserStoryPreferences_UserSelectPreferences_UserSelectPrefer~",
                table: "UserStoryPreferences",
                column: "UserSelectPreferencesUserSelectPrefId",
                principalTable: "UserSelectPreferences",
                principalColumn: "UserSelectPrefId");
        }
    }
}
