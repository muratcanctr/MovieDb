using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDb.Migrations
{
    public partial class vcdsxadasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "MovieMedia",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "MovieName",
                table: "MovieMedia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05e94eaa-d1be-4ea8-8e1c-4428bf764b05", "AQAAAAEAACcQAAAAEJb293a/06rrrqzRCPq8vsvA1bLCywF9W9jj6ei/nUnzp/VHl3jqLF0E/m2hm0YwdQ==", "f60dcffd-f855-4480-b94d-5223ab617978" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieName",
                table: "MovieMedia");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "MovieMedia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "226f789a-3d33-4b72-babc-53aaa262e261", "AQAAAAEAACcQAAAAEPpHSdY7oZfz8C4TZDBjr36GOf+UQHfo9h7Tj88TLMEovLmLdeGn+18SAo1Z+yEpVg==", "b844eea4-a1d9-4443-8bba-b02ec4f7fb90" });
        }
    }
}
