using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDb.Migrations
{
    public partial class vcds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2bda1d71-719f-4caa-a1d3-b302d3333be4", "AQAAAAEAACcQAAAAEBshjY1wEhPIJwwnP1MTTIrbkM2Ig90jDkuCzjke8ptKJ0Q1GMgam/doxmSSoY5REw==", "e3772587-4fc6-4086-aaa6-c5c09914a80c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fb72b41-3e12-4a2f-8482-2469273fad9c", "AQAAAAEAACcQAAAAEL3PFpL5Rvlrew+cTLIp+GljUc7nqzQC+HTvUQ88wYdmsD+7wQOdhKx7MXtutnmPjQ==", "837525ba-a387-451b-918a-5a9cf62fef5d" });
        }
    }
}
