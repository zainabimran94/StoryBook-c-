using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoryBook.Migrations
{
    /// <inheritdoc />
    public partial class AddUserProfilePythonDataRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoriesGenerated");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "PythonData",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PythonData_UserId",
                table: "PythonData",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PythonData_UserProfiles_UserId",
                table: "PythonData",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PythonData_UserProfiles_UserId",
                table: "PythonData");

            migrationBuilder.DropIndex(
                name: "IX_PythonData_UserId",
                table: "PythonData");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PythonData");

            migrationBuilder.CreateTable(
                name: "StoriesGenerated",
                columns: table => new
                {
                    StoryGeneratedId = table.Column<Guid>(type: "uuid", nullable: false),
                    PythonDataId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoriesGenerated", x => x.StoryGeneratedId);
                    table.ForeignKey(
                        name: "FK_StoriesGenerated_PythonData_PythonDataId",
                        column: x => x.PythonDataId,
                        principalTable: "PythonData",
                        principalColumn: "PythonDataId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoriesGenerated_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoriesGenerated_PythonDataId",
                table: "StoriesGenerated",
                column: "PythonDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoriesGenerated_UserId",
                table: "StoriesGenerated",
                column: "UserId");
        }
    }
}
