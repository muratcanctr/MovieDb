using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDb.Migrations
{
    public partial class movieReview2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6b4f0af-4751-4c13-9d90-158f69fdee5f", "AQAAAAEAACcQAAAAENtXK9VHekN/PvYECPUuQsoGOsQnyOhgZLn8V+EzmF/J7urDUjLhk8BJD7vyMgcUlA==", "4af7a88f-aaf8-4115-9cbd-03bf6df0e67c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc52702b-1dbb-40e8-b1e7-95f237b29faa", "AQAAAAEAACcQAAAAENMJetliEEuLNT/iN6lmMq71gJ8FWp8N5F//fkflJi6WFzFKVoPYzDA+C5eHcKWGcQ==", "d1e2b0a0-7737-47c0-abcb-be50d3a2abdf" });
        }
    }
}
