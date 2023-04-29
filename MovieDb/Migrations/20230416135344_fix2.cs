using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDb.Migrations
{
    public partial class fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd09d6f5-5476-4e49-9de3-9b4de6198fbd", "AQAAAAEAACcQAAAAEDdYruSt5o2dxk7+EyBPtWdabr2VSr9jXY//XtZ1keI1TFjguUuTjQ+Y7cvTIBVPzA==", "a8edd20e-5cd5-4b11-9485-5f6d09956e97" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1936edd-3708-470e-ba93-439e96a970ae", "AQAAAAEAACcQAAAAEFGRtz6EWKZFMB/ExnJK1qXuMERXP8SlnLvSwMwPG4xQ5BHDRTNZYyonp/GH0qtqSA==", "ace61e65-16ce-4726-8714-6b172ce3d610" });
        }
    }
}
