using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDb.Migrations
{
    public partial class ActorTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Actors",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Movies",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe557a8a-4aec-44d9-8cb9-e9395a256882", "AQAAAAEAACcQAAAAEATPCk06coGs6ry6DI+RXkOda5+yrmFZisIVmJC/WZnncs8FFLmRQE/kU4oAAzj0Ow==", "34bf2e57-3c58-4acb-9776-2123c4b8edb8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actors",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Movies",
                table: "Actors");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "810426a6-6134-4b12-a113-57e1cf4e9d73", "AQAAAAEAACcQAAAAECEoO/QQNKIbAkQnECGbVUQkkzEg6OHMv9mqo+X4FsCWlsI25MBVVX30kFoRCFOLCw==", "5bf735f7-9afc-4dd1-98b8-08ecac310423" });
        }
    }
}
