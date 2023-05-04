using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDb.Migrations
{
    public partial class vcdsxadasddasd13dasdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteMoviesDaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    movieContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteMoviesDaos", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e23a169-28a5-4b5e-aa20-45aca1d172f1", "AQAAAAEAACcQAAAAEOkIPgW3lJIF1poyj2XLJou4KVRHCvHjKsop13DQ9A2IqJQuIB4SdMf3EYSeWgpCXw==", "e8b24c1f-d928-4622-9023-d4e6387960d6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteMoviesDaos");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02ecdf79-874c-48f2-a852-9a5ae80a5d5e", "AQAAAAEAACcQAAAAEEmQLOUzmU0w+t9VxOuNB7XcNvy92S0Dm9eFt5PaLs+oK+d4v9fYaNO30lH0c+vJKA==", "785bc9b5-c4ac-4ad4-ae7f-6fa68733f75b" });
        }
    }
}
