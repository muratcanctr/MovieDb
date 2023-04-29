using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDb.Migrations
{
    public partial class ActorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContentId",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2294c261-2bd0-4bbb-9868-230db7308887", "AQAAAAEAACcQAAAAEAflYWL8uA6NFeOilaNyYsdxZoO/hcrFr6UMYoyYBR2A5LFXciRiSJU3IoitsblUtg==", "9de930f9-652c-46eb-a506-c989e68c5e4c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentId",
                table: "Movies");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eea001b7-f927-4447-89dd-43186ef715c5", "AQAAAAEAACcQAAAAEF1z4PrD04W+sPdHdEhz4xwG0SL9XEnVNZOcxcoyPjGQEI/5d6JfjVMvgml4sLPuVA==", "5e56aba8-05be-4204-a766-730130f2fa62" });
        }
    }
}
