using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDb.Migrations
{
    public partial class movieReview3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "MovieReviews",
                newName: "MovieRating");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53124ef9-eeaf-49bc-a8ac-45a176765114", "AQAAAAEAACcQAAAAEL8rofMoAfW6ub4DpP8CL/9ab81RZK/qhN5SviZtQ+kfCkSCv1pP8lIvnWfFN1gmxA==", "94c9ffde-8ffb-440d-82f0-bf003203407f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovieRating",
                table: "MovieReviews",
                newName: "Rating");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6b4f0af-4751-4c13-9d90-158f69fdee5f", "AQAAAAEAACcQAAAAENtXK9VHekN/PvYECPUuQsoGOsQnyOhgZLn8V+EzmF/J7urDUjLhk8BJD7vyMgcUlA==", "4af7a88f-aaf8-4115-9cbd-03bf6df0e67c" });
        }
    }
}
