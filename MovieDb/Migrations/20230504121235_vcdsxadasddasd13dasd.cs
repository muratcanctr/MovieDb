using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDb.Migrations
{
    public partial class vcdsxadasddasd13dasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02ecdf79-874c-48f2-a852-9a5ae80a5d5e", "AQAAAAEAACcQAAAAEEmQLOUzmU0w+t9VxOuNB7XcNvy92S0Dm9eFt5PaLs+oK+d4v9fYaNO30lH0c+vJKA==", "785bc9b5-c4ac-4ad4-ae7f-6fa68733f75b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40b6a8ed-61f6-45ea-8975-dededb868011", "AQAAAAEAACcQAAAAEGQ89v8QLZKtTUPG1rTHKKUnk27eMqkERaL5/yy70G6zW2JGZ4HBwBvWY+DUTbDN4Q==", "7239396d-8982-4380-9b02-921e7648a362" });
        }
    }
}
