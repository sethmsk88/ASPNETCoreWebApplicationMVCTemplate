using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNETCoreWebApplicationMVCTemplate.Migrations
{
    public partial class SeedStudentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Address", "Branch", "Email", "Gender", "Name", "Section" },
                values: new object[] { 1, null, 1, "bart@yahoo.com", 0, "Bart Simpson", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);
        }
    }
}
