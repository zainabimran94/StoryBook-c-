using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoryBook.Migrations
{
    /// <inheritdoc />
    public partial class UpdateuserSelectPref : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoriesGenerated_UserProfiles_UserId",
                table: "StoriesGenerated");

            migrationBuilder.DropForeignKey(
                name: "FK_StoriesGenerated_UserStoryPreferences_UserStoryId",
                table: "StoriesGenerated");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStoryPreferences_KidPreferences_KidPreferencesId",
                table: "UserStoryPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStoryPreferences_ToddlerPreferences_ToddlerPreferencesId",
                table: "UserStoryPreferences");

            migrationBuilder.DropTable(
                name: "KidPreferences");

            migrationBuilder.DropTable(
                name: "ToddlerImageSelection");

            migrationBuilder.DropTable(
                name: "ToddlerPreferences");

            migrationBuilder.DropIndex(
                name: "IX_UserStoryPreferences_KidPreferencesId",
                table: "UserStoryPreferences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoriesGenerated",
                table: "StoriesGenerated");

            migrationBuilder.DropColumn(
                name: "KidPreferencesId",
                table: "UserStoryPreferences");

            migrationBuilder.RenameTable(
                name: "StoriesGenerated",
                newName: "StoryGenerated");

            migrationBuilder.RenameColumn(
                name: "ToddlerPreferencesId",
                table: "UserStoryPreferences",
                newName: "UserSelectPreferencesUserSelectPrefId");

            migrationBuilder.RenameIndex(
                name: "IX_UserStoryPreferences_ToddlerPreferencesId",
                table: "UserStoryPreferences",
                newName: "IX_UserStoryPreferences_UserSelectPreferencesUserSelectPrefId");

            migrationBuilder.RenameIndex(
                name: "IX_StoriesGenerated_UserStoryId",
                table: "StoryGenerated",
                newName: "IX_StoryGenerated_UserStoryId");

            migrationBuilder.RenameIndex(
                name: "IX_StoriesGenerated_UserId",
                table: "StoryGenerated",
                newName: "IX_StoryGenerated_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserSelectPrefId",
                table: "UserStoryPreferences",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoryGenerated",
                table: "StoryGenerated",
                column: "StoryGeneratedId");

            migrationBuilder.CreateTable(
                name: "UserSelectPreferences",
                columns: table => new
                {
                    UserSelectPrefId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    StoryDesc = table.Column<string>(type: "text", nullable: true),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSelectPreferences", x => x.UserSelectPrefId);
                    table.ForeignKey(
                        name: "FK_UserSelectPreferences_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId");
                    table.ForeignKey(
                        name: "FK_UserSelectPreferences_UserGroups_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroups",
                        principalColumn: "UserGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserStoryPreferences_UserSelectPrefId",
                table: "UserStoryPreferences",
                column: "UserSelectPrefId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSelectPreferences_ImageId",
                table: "UserSelectPreferences",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSelectPreferences_UserGroupId",
                table: "UserSelectPreferences",
                column: "UserGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoryGenerated_UserProfiles_UserId",
                table: "StoryGenerated",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoryGenerated_UserStoryPreferences_UserStoryId",
                table: "StoryGenerated",
                column: "UserStoryId",
                principalTable: "UserStoryPreferences",
                principalColumn: "UserStoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStoryPreferences_UserSelectPreferences_UserSelectPrefId",
                table: "UserStoryPreferences",
                column: "UserSelectPrefId",
                principalTable: "UserSelectPreferences",
                principalColumn: "UserSelectPrefId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStoryPreferences_UserSelectPreferences_UserSelectPrefer~",
                table: "UserStoryPreferences",
                column: "UserSelectPreferencesUserSelectPrefId",
                principalTable: "UserSelectPreferences",
                principalColumn: "UserSelectPrefId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoryGenerated_UserProfiles_UserId",
                table: "StoryGenerated");

            migrationBuilder.DropForeignKey(
                name: "FK_StoryGenerated_UserStoryPreferences_UserStoryId",
                table: "StoryGenerated");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStoryPreferences_UserSelectPreferences_UserSelectPrefId",
                table: "UserStoryPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStoryPreferences_UserSelectPreferences_UserSelectPrefer~",
                table: "UserStoryPreferences");

            migrationBuilder.DropTable(
                name: "UserSelectPreferences");

            migrationBuilder.DropIndex(
                name: "IX_UserStoryPreferences_UserSelectPrefId",
                table: "UserStoryPreferences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoryGenerated",
                table: "StoryGenerated");

            migrationBuilder.DropColumn(
                name: "UserSelectPrefId",
                table: "UserStoryPreferences");

            migrationBuilder.RenameTable(
                name: "StoryGenerated",
                newName: "StoriesGenerated");

            migrationBuilder.RenameColumn(
                name: "UserSelectPreferencesUserSelectPrefId",
                table: "UserStoryPreferences",
                newName: "ToddlerPreferencesId");

            migrationBuilder.RenameIndex(
                name: "IX_UserStoryPreferences_UserSelectPreferencesUserSelectPrefId",
                table: "UserStoryPreferences",
                newName: "IX_UserStoryPreferences_ToddlerPreferencesId");

            migrationBuilder.RenameIndex(
                name: "IX_StoryGenerated_UserStoryId",
                table: "StoriesGenerated",
                newName: "IX_StoriesGenerated_UserStoryId");

            migrationBuilder.RenameIndex(
                name: "IX_StoryGenerated_UserId",
                table: "StoriesGenerated",
                newName: "IX_StoriesGenerated_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "KidPreferencesId",
                table: "UserStoryPreferences",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoriesGenerated",
                table: "StoriesGenerated",
                column: "StoryGeneratedId");

            migrationBuilder.CreateTable(
                name: "KidPreferences",
                columns: table => new
                {
                    KidsPrefId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    StoryDesc = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KidPreferences", x => x.KidsPrefId);
                    table.ForeignKey(
                        name: "FK_KidPreferences_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToddlerPreferences",
                columns: table => new
                {
                    ToddlerPrefId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageDesc = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToddlerPreferences", x => x.ToddlerPrefId);
                    table.ForeignKey(
                        name: "FK_ToddlerPreferences_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_UserStoryPreferences_KidPreferencesId",
                table: "UserStoryPreferences",
                column: "KidPreferencesId");

            migrationBuilder.CreateIndex(
                name: "IX_KidPreferences_UserId",
                table: "KidPreferences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ToddlerImageSelection_ImageId",
                table: "ToddlerImageSelection",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ToddlerPreferences_UserId",
                table: "ToddlerPreferences",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoriesGenerated_UserProfiles_UserId",
                table: "StoriesGenerated",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoriesGenerated_UserStoryPreferences_UserStoryId",
                table: "StoriesGenerated",
                column: "UserStoryId",
                principalTable: "UserStoryPreferences",
                principalColumn: "UserStoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStoryPreferences_KidPreferences_KidPreferencesId",
                table: "UserStoryPreferences",
                column: "KidPreferencesId",
                principalTable: "KidPreferences",
                principalColumn: "KidsPrefId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStoryPreferences_ToddlerPreferences_ToddlerPreferencesId",
                table: "UserStoryPreferences",
                column: "ToddlerPreferencesId",
                principalTable: "ToddlerPreferences",
                principalColumn: "ToddlerPrefId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
