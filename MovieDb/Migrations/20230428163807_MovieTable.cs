using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDb.Migrations
{
    public partial class MovieTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Banner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlotKeywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MMPARating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RunTime = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eea001b7-f927-4447-89dd-43186ef715c5", "AQAAAAEAACcQAAAAEF1z4PrD04W+sPdHdEhz4xwG0SL9XEnVNZOcxcoyPjGQEI/5d6JfjVMvgml4sLPuVA==", "5e56aba8-05be-4204-a766-730130f2fa62" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd09d6f5-5476-4e49-9de3-9b4de6198fbd", "AQAAAAEAACcQAAAAEDdYruSt5o2dxk7+EyBPtWdabr2VSr9jXY//XtZ1keI1TFjguUuTjQ+Y7cvTIBVPzA==", "a8edd20e-5cd5-4b11-9485-5f6d09956e97" });
        }
    }
}
