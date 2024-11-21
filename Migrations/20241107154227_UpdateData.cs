using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoryBook.Migrations
{
    /// <inheritdoc />
    public partial class UpdateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoriesGenerated_UserSelectPreferences_UserSelectPrefId",
                table: "StoriesGenerated");

            migrationBuilder.DropTable(
                name: "UserSelectPreferences");

            migrationBuilder.DropIndex(
                name: "IX_StoriesGenerated_UserSelectPrefId",
                table: "StoriesGenerated");

            migrationBuilder.DropColumn(
                name: "UserSelectPrefId",
                table: "StoriesGenerated");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserSelectPrefId",
                table: "StoriesGenerated",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UserSelectPreferences",
                columns: table => new
                {
                    UserSelectPrefId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageDesc = table.Column<string>(type: "text", nullable: true),
                    StoryDesc = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSelectPreferences", x => x.UserSelectPrefId);
                    table.ForeignKey(
                        name: "FK_UserSelectPreferences_UserGroups_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroups",
                        principalColumn: "UserGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoriesGenerated_UserSelectPrefId",
                table: "StoriesGenerated",
                column: "UserSelectPrefId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSelectPreferences_UserGroupId",
                table: "UserSelectPreferences",
                column: "UserGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoriesGenerated_UserSelectPreferences_UserSelectPrefId",
                table: "StoriesGenerated",
                column: "UserSelectPrefId",
                principalTable: "UserSelectPreferences",
                principalColumn: "UserSelectPrefId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
