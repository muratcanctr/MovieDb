using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDb.Migrations
{
    public partial class movieReview4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MovieReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fb72b41-3e12-4a2f-8482-2469273fad9c", "AQAAAAEAACcQAAAAEL3PFpL5Rvlrew+cTLIp+GljUc7nqzQC+HTvUQ88wYdmsD+7wQOdhKx7MXtutnmPjQ==", "837525ba-a387-451b-918a-5a9cf62fef5d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MovieReviews");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53124ef9-eeaf-49bc-a8ac-45a176765114", "AQAAAAEAACcQAAAAEL8rofMoAfW6ub4DpP8CL/9ab81RZK/qhN5SviZtQ+kfCkSCv1pP8lIvnWfFN1gmxA==", "94c9ffde-8ffb-440d-82f0-bf003203407f" });
        }
    }
}
