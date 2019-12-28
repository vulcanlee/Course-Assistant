using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assistant.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCode = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Salt = table.Column<Guid>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    Roles = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    OrderCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionTitle = table.Column<string>(nullable: false),
                    QuestionDescription = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true),
                    HasAnswer = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Closed = table.Column<DateTime>(nullable: true),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionAnswers_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseCourseUser",
                columns: table => new
                {
                    CourseUserId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCourseUser", x => new { x.CourseUserId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_CourseCourseUser_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseCourseUser_CourseUsers_CourseUserId",
                        column: x => x.CourseUserId,
                        principalTable: "CourseUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseCourseUser_CourseId",
                table: "CourseCourseUser",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_CourseId",
                table: "QuestionAnswers",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseCourseUser");

            migrationBuilder.DropTable(
                name: "QuestionAnswers");

            migrationBuilder.DropTable(
                name: "CourseUsers");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
