using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDb.Migrations
{
    public partial class ActorTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Banner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlotKeywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "810426a6-6134-4b12-a113-57e1cf4e9d73", "AQAAAAEAACcQAAAAECEoO/QQNKIbAkQnECGbVUQkkzEg6OHMv9mqo+X4FsCWlsI25MBVVX30kFoRCFOLCw==", "5bf735f7-9afc-4dd1-98b8-08ecac310423" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2294c261-2bd0-4bbb-9868-230db7308887", "AQAAAAEAACcQAAAAEAflYWL8uA6NFeOilaNyYsdxZoO/hcrFr6UMYoyYBR2A5LFXciRiSJU3IoitsblUtg==", "9de930f9-652c-46eb-a506-c989e68c5e4c" });
        }
    }
}
