using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseEnv.Infrastructure.Migrations
{
    public partial class ChangedSeedValuesToCorrectDateFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CourseInstances",
                keyColumn: "CourseInstanceId",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2018, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CourseInstances",
                keyColumn: "CourseInstanceId",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2018, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CourseInstances",
                keyColumn: "CourseInstanceId",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2018, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CourseInstances",
                keyColumn: "CourseInstanceId",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2018, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CourseInstances",
                keyColumn: "CourseInstanceId",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2018, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CourseInstances",
                keyColumn: "CourseInstanceId",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2018, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CourseInstances",
                keyColumn: "CourseInstanceId",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2018, 1, 8, 0, 10, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CourseInstances",
                keyColumn: "CourseInstanceId",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2018, 1, 26, 0, 8, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CourseInstances",
                keyColumn: "CourseInstanceId",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2018, 1, 8, 0, 10, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CourseInstances",
                keyColumn: "CourseInstanceId",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2018, 1, 10, 0, 10, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CourseInstances",
                keyColumn: "CourseInstanceId",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2018, 1, 31, 0, 8, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CourseInstances",
                keyColumn: "CourseInstanceId",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2018, 1, 8, 0, 9, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
