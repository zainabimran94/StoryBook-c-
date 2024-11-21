using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoryBook.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoryGenerated_UserProfiles_UserId",
                table: "StoryGenerated");

            migrationBuilder.DropForeignKey(
                name: "FK_StoryGenerated_UserSelectPreferences_UserSelectPrefId",
                table: "StoryGenerated");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoryGenerated",
                table: "StoryGenerated");

            migrationBuilder.RenameTable(
                name: "StoryGenerated",
                newName: "StoriesGenerated");

            migrationBuilder.RenameIndex(
                name: "IX_StoryGenerated_UserSelectPrefId",
                table: "StoriesGenerated",
                newName: "IX_StoriesGenerated_UserSelectPrefId");

            migrationBuilder.RenameIndex(
                name: "IX_StoryGenerated_UserId",
                table: "StoriesGenerated",
                newName: "IX_StoriesGenerated_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoriesGenerated",
                table: "StoriesGenerated",
                column: "StoryGeneratedId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoriesGenerated_UserProfiles_UserId",
                table: "StoriesGenerated",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoriesGenerated_UserSelectPreferences_UserSelectPrefId",
                table: "StoriesGenerated",
                column: "UserSelectPrefId",
                principalTable: "UserSelectPreferences",
                principalColumn: "UserSelectPrefId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoriesGenerated_UserProfiles_UserId",
                table: "StoriesGenerated");

            migrationBuilder.DropForeignKey(
                name: "FK_StoriesGenerated_UserSelectPreferences_UserSelectPrefId",
                table: "StoriesGenerated");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoriesGenerated",
                table: "StoriesGenerated");

            migrationBuilder.RenameTable(
                name: "StoriesGenerated",
                newName: "StoryGenerated");

            migrationBuilder.RenameIndex(
                name: "IX_StoriesGenerated_UserSelectPrefId",
                table: "StoryGenerated",
                newName: "IX_StoryGenerated_UserSelectPrefId");

            migrationBuilder.RenameIndex(
                name: "IX_StoriesGenerated_UserId",
                table: "StoryGenerated",
                newName: "IX_StoryGenerated_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoryGenerated",
                table: "StoryGenerated",
                column: "StoryGeneratedId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoryGenerated_UserProfiles_UserId",
                table: "StoryGenerated",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoryGenerated_UserSelectPreferences_UserSelectPrefId",
                table: "StoryGenerated",
                column: "UserSelectPrefId",
                principalTable: "UserSelectPreferences",
                principalColumn: "UserSelectPrefId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
