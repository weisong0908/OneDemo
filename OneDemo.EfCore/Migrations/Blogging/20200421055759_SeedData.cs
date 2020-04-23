using Microsoft.EntityFrameworkCore.Migrations;

namespace OneDemo.EfCore.Migrations.Blogging
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "personal blog" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "work blog" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "BlogId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "personal post 1" },
                    { 2, 1, "personal post 2" },
                    { 3, 1, "personal post 3" },
                    { 4, 2, "work post 1" },
                    { 5, 2, "work post 2" },
                    { 6, 2, "work post 3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
