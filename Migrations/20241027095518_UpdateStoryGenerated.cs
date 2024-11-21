using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoryBook.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStoryGenerated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StoryImageUrl",
                table: "StoriesGenerated",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StoryImageUrl",
                table: "StoriesGenerated",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
