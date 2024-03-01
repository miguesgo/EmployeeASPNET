using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateTest.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Employees",
                newName: "LastNameP");

            migrationBuilder.AddColumn<string>(
                name: "LastNameM",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastNameM",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "LastNameP",
                table: "Employees",
                newName: "LastName");
        }
    }
}
