using Microsoft.EntityFrameworkCore.Migrations;

namespace OneDemo.EfCore.Migrations.People
{
    public partial class AddPeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Person 1" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Person 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
