using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNETCoreWebApplicationMVCTemplate.Migrations
{
    public partial class AlterStudentsSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "lisa@yahoo.com", "Lisa Simpson" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Address", "Branch", "Email", "Gender", "Name", "Section" },
                values: new object[] { 2, null, 1, "homer@yahoo.com", 0, "Homer Simpson", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "bart@yahoo.com", "Bart Simpson" });
        }
    }
}
