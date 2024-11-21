using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoryBook.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserStoryPreferences_UserAgeGroups_UserAgeId",
                table: "UserStoryPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStoryPreferences_UserThemeGroups_UserThemeId",
                table: "UserStoryPreferences");

            migrationBuilder.DropTable(
                name: "UserAgeGroups");

            migrationBuilder.DropTable(
                name: "UserThemeGroups");

            migrationBuilder.DropIndex(
                name: "IX_UserStoryPreferences_UserAgeId",
                table: "UserStoryPreferences");

            migrationBuilder.DropColumn(
                name: "UserAgeId",
                table: "UserStoryPreferences");

            migrationBuilder.RenameColumn(
                name: "UserThemeId",
                table: "UserStoryPreferences",
                newName: "UserGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_UserStoryPreferences_UserThemeId",
                table: "UserStoryPreferences",
                newName: "IX_UserStoryPreferences_UserGroupId");

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AgeGroupId = table.Column<int>(type: "integer", nullable: false),
                    ThemeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.UserGroupId);
                    table.ForeignKey(
                        name: "FK_UserGroups_AgeGroups_AgeGroupId",
                        column: x => x.AgeGroupId,
                        principalTable: "AgeGroups",
                        principalColumn: "AgeGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroups_Themes_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Themes",
                        principalColumn: "ThemeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroups_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_AgeGroupId",
                table: "UserGroups",
                column: "AgeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_ThemeId",
                table: "UserGroups",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_UserId",
                table: "UserGroups",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStoryPreferences_UserGroups_UserGroupId",
                table: "UserStoryPreferences",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "UserGroupId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserStoryPreferences_UserGroups_UserGroupId",
                table: "UserStoryPreferences");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.RenameColumn(
                name: "UserGroupId",
                table: "UserStoryPreferences",
                newName: "UserThemeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserStoryPreferences_UserGroupId",
                table: "UserStoryPreferences",
                newName: "IX_UserStoryPreferences_UserThemeId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserAgeId",
                table: "UserStoryPreferences",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UserAgeGroups",
                columns: table => new
                {
                    UserAgeId = table.Column<Guid>(type: "uuid", nullable: false),
                    AgeGroupId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAgeGroups", x => x.UserAgeId);
                    table.ForeignKey(
                        name: "FK_UserAgeGroups_AgeGroups_AgeGroupId",
                        column: x => x.AgeGroupId,
                        principalTable: "AgeGroups",
                        principalColumn: "AgeGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAgeGroups_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserThemeGroups",
                columns: table => new
                {
                    UserThemeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ThemeId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserThemeGroups", x => x.UserThemeId);
                    table.ForeignKey(
                        name: "FK_UserThemeGroups_Themes_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Themes",
                        principalColumn: "ThemeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserThemeGroups_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserStoryPreferences_UserAgeId",
                table: "UserStoryPreferences",
                column: "UserAgeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAgeGroups_AgeGroupId",
                table: "UserAgeGroups",
                column: "AgeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAgeGroups_UserId",
                table: "UserAgeGroups",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserThemeGroups_ThemeId",
                table: "UserThemeGroups",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserThemeGroups_UserId",
                table: "UserThemeGroups",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStoryPreferences_UserAgeGroups_UserAgeId",
                table: "UserStoryPreferences",
                column: "UserAgeId",
                principalTable: "UserAgeGroups",
                principalColumn: "UserAgeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStoryPreferences_UserThemeGroups_UserThemeId",
                table: "UserStoryPreferences",
                column: "UserThemeId",
                principalTable: "UserThemeGroups",
                principalColumn: "UserThemeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
