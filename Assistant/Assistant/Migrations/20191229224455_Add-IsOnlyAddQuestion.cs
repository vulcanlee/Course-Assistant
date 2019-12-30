using Microsoft.EntityFrameworkCore.Migrations;

namespace Assistant.Migrations
{
    public partial class AddIsOnlyAddQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOnlyAddQuestion",
                table: "CourseUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOnlyAddQuestion",
                table: "CourseUsers");
        }
    }
}
