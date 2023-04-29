using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDb.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1936edd-3708-470e-ba93-439e96a970ae", "AQAAAAEAACcQAAAAEFGRtz6EWKZFMB/ExnJK1qXuMERXP8SlnLvSwMwPG4xQ5BHDRTNZYyonp/GH0qtqSA==", "ace61e65-16ce-4726-8714-6b172ce3d610" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24650615-8d54-4d88-808d-04d270dc86ac", "AQAAAAEAACcQAAAAEJ9bQ/5GAxsWDx/xbuMJn5hsNjUNiMvaFS6k1Nz9UdWJxVEQyb/ngB15NN24LarXng==", "0a7224fb-e0f3-4e07-9a52-7caaea4894a4" });
        }
    }
}
