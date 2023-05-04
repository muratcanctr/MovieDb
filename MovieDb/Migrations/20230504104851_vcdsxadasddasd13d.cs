using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDb.Migrations
{
    public partial class vcdsxadasddasd13d : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genres",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40b6a8ed-61f6-45ea-8975-dededb868011", "AQAAAAEAACcQAAAAEGQ89v8QLZKtTUPG1rTHKKUnk27eMqkERaL5/yy70G6zW2JGZ4HBwBvWY+DUTbDN4Q==", "7239396d-8982-4380-9b02-921e7648a362" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genres",
                table: "Movies");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05ce6780-7dd7-46dc-8d29-71515af0d59d", "AQAAAAEAACcQAAAAEANOsoEx7V4xRioxMEB6MNkpvOnnXq6zR8WAeSBJF3yUbrqAQHpxCgKGOBG+oViHNg==", "7f50e4ea-1f27-48ad-9f58-a4945a3448a5" });
        }
    }
}
