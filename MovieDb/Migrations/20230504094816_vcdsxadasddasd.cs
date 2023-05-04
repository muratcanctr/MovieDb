using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDb.Migrations
{
    public partial class vcdsxadasddasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MovieName",
                table: "MovieMedia",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "MovieThumbnail",
                table: "MovieMedia",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05ce6780-7dd7-46dc-8d29-71515af0d59d", "AQAAAAEAACcQAAAAEANOsoEx7V4xRioxMEB6MNkpvOnnXq6zR8WAeSBJF3yUbrqAQHpxCgKGOBG+oViHNg==", "7f50e4ea-1f27-48ad-9f58-a4945a3448a5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieThumbnail",
                table: "MovieMedia");

            migrationBuilder.AlterColumn<string>(
                name: "MovieName",
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
                values: new object[] { "05e94eaa-d1be-4ea8-8e1c-4428bf764b05", "AQAAAAEAACcQAAAAEJb293a/06rrrqzRCPq8vsvA1bLCywF9W9jj6ei/nUnzp/VHl3jqLF0E/m2hm0YwdQ==", "f60dcffd-f855-4480-b94d-5223ab617978" });
        }
    }
}
