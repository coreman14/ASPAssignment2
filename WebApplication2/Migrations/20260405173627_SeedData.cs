using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "ID", "Email", "Name", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "admin@lms.local", "Admin", "admin123", "Admin" },
                    { 2, "d@wwwss.local", "Dave", "admin123", "d3po" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "Author", "IBSN", "IsAvailable", "Title" },
                values: new object[,]
                {
                    { 1, "Robert C. Martin", "9780132350884", true, "Clean Code" },
                    { 2, "Martin Fowler", "9780201485677", true, "Refactoring" }
                });

            migrationBuilder.InsertData(
                table: "Readers",
                columns: new[] { "ID", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "alice@lms.com", "Alice Johnson" },
                    { 2, "bob@cws.com", "Bob Smith" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
