using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseEnv.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "CourseInstances",
                columns: table => new
                {
                    CourseInstanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInstances", x => x.CourseInstanceId);
                    table.ForeignKey(
                        name: "FK_CourseInstances_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseCode", "Duration", "Title" },
                values: new object[,]
                {
                    { 1, "CNETIN", "5", "Programming C#" },
                    { 2, "ECMASWN", "2", "ECMAscript – What’s new" },
                    { 3, "QSQLS", "5", "Querying SQL Server" },
                    { 4, "JPA", "2", "Java Persistence API" },
                    { 5, "SPAVUE", "3", "Building a SPA with Vuejs" },
                    { 6, "ASPMVC", "5", "ASP.NET MVC" }
                });

            migrationBuilder.InsertData(
                table: "CourseInstances",
                columns: new[] { "CourseInstanceId", "CourseId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2018, 1, 8, 0, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2018, 1, 26, 0, 8, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2018, 1, 8, 0, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2018, 1, 10, 0, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2018, 1, 31, 0, 8, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, new DateTime(2018, 1, 8, 0, 9, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstances_CourseId",
                table: "CourseInstances",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseInstances");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
