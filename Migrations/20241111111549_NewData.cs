using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoryBook.Migrations
{
    /// <inheritdoc />
    public partial class NewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_Images_ImagesImageId",
                table: "UserPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_UserGroups_UserGroupId",
                table: "UserPreferences");

            migrationBuilder.DropIndex(
                name: "IX_UserPreferences_ImagesImageId",
                table: "UserPreferences");

            migrationBuilder.DropIndex(
                name: "IX_UserPreferences_UserGroupId",
                table: "UserPreferences");

            migrationBuilder.DropColumn(
                name: "ImagesImageId",
                table: "UserPreferences");

            migrationBuilder.DropColumn(
                name: "UserGroupId",
                table: "UserPreferences");

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "UserPreferences",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ThemeName",
                table: "UserPreferences",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "UserPreferences");

            migrationBuilder.DropColumn(
                name: "ThemeName",
                table: "UserPreferences");

            migrationBuilder.AddColumn<Guid>(
                name: "ImagesImageId",
                table: "UserPreferences",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserGroupId",
                table: "UserPreferences",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_ImagesImageId",
                table: "UserPreferences",
                column: "ImagesImageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_UserGroupId",
                table: "UserPreferences",
                column: "UserGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_Images_ImagesImageId",
                table: "UserPreferences",
                column: "ImagesImageId",
                principalTable: "Images",
                principalColumn: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_UserGroups_UserGroupId",
                table: "UserPreferences",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "UserGroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
