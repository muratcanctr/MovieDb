using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDb.Migrations
{
    public partial class _123cs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActorMedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActorContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActorThumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMedia", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "881107fe-f1e0-44f4-849e-671380d8ff2c", "AQAAAAEAACcQAAAAEDHyp0ku1y0Wgkf+ZqrodTKY/zdIX6AiW817MP9Kmv4LMnZRmK0MNHNIq9nUS/WMGQ==", "93930e59-d9a9-4e23-b0ac-989fa12569f4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMedia");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6fb181c-3a6b-40db-9a1c-a9b7897e951f", "AQAAAAEAACcQAAAAEBL2wthYlE8c6KXijzAx1k0us37Du9WSoSkjytPHwPOpFn70XUrxAdBBrIpQ895QOg==", "796bb14f-d99b-4295-98e0-360004481607" });
        }
    }
}
