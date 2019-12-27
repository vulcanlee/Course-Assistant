using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assistant.Migrations
{
    public partial class QuestionAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "CourseUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OrderCode",
                table: "CourseUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Courses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "CourseUsers");

            migrationBuilder.DropColumn(
                name: "OrderCode",
                table: "CourseUsers");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Courses");
        }
    }
}
