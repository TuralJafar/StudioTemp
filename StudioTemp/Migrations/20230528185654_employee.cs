using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioTemp.Migrations
{
    /// <inheritdoc />
    public partial class employee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkEdin",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LinkEdin",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "Employees");
        }
    }
}
