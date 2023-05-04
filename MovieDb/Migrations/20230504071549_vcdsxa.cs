using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDb.Migrations
{
    public partial class vcdsxa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieMedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediaType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieMedia", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "226f789a-3d33-4b72-babc-53aaa262e261", "AQAAAAEAACcQAAAAEPpHSdY7oZfz8C4TZDBjr36GOf+UQHfo9h7Tj88TLMEovLmLdeGn+18SAo1Z+yEpVg==", "b844eea4-a1d9-4443-8bba-b02ec4f7fb90" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieMedia");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2bda1d71-719f-4caa-a1d3-b302d3333be4", "AQAAAAEAACcQAAAAEBshjY1wEhPIJwwnP1MTTIrbkM2Ig90jDkuCzjke8ptKJ0Q1GMgam/doxmSSoY5REw==", "e3772587-4fc6-4086-aaa6-c5c09914a80c" });
        }
    }
}
