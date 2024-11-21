using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoryBook.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRemovee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoryGenerated_UserStoryPreferences_UserStoryId",
                table: "StoryGenerated");

            migrationBuilder.DropTable(
                name: "UserStoryPreferences");

            migrationBuilder.RenameColumn(
                name: "UserStoryId",
                table: "StoryGenerated",
                newName: "UserSelectPrefId");

            migrationBuilder.RenameIndex(
                name: "IX_StoryGenerated_UserStoryId",
                table: "StoryGenerated",
                newName: "IX_StoryGenerated_UserSelectPrefId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoryGenerated_UserSelectPreferences_UserSelectPrefId",
                table: "StoryGenerated",
                column: "UserSelectPrefId",
                principalTable: "UserSelectPreferences",
                principalColumn: "UserSelectPrefId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoryGenerated_UserSelectPreferences_UserSelectPrefId",
                table: "StoryGenerated");

            migrationBuilder.RenameColumn(
                name: "UserSelectPrefId",
                table: "StoryGenerated",
                newName: "UserStoryId");

            migrationBuilder.RenameIndex(
                name: "IX_StoryGenerated_UserSelectPrefId",
                table: "StoryGenerated",
                newName: "IX_StoryGenerated_UserStoryId");

            migrationBuilder.CreateTable(
                name: "UserStoryPreferences",
                columns: table => new
                {
                    UserStoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserSelectPrefId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStoryPreferences", x => x.UserStoryId);
                    table.ForeignKey(
                        name: "FK_UserStoryPreferences_UserGroups_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroups",
                        principalColumn: "UserGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStoryPreferences_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStoryPreferences_UserSelectPreferences_UserSelectPrefId",
                        column: x => x.UserSelectPrefId,
                        principalTable: "UserSelectPreferences",
                        principalColumn: "UserSelectPrefId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserStoryPreferences_UserGroupId",
                table: "UserStoryPreferences",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStoryPreferences_UserId",
                table: "UserStoryPreferences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStoryPreferences_UserSelectPrefId",
                table: "UserStoryPreferences",
                column: "UserSelectPrefId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoryGenerated_UserStoryPreferences_UserStoryId",
                table: "StoryGenerated",
                column: "UserStoryId",
                principalTable: "UserStoryPreferences",
                principalColumn: "UserStoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
