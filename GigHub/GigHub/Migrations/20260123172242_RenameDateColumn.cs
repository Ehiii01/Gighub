using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GigHub.Migrations
{
    /// <inheritdoc />
    public partial class RenameDateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Notifications",
                newName: "DateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Notifications",
                newName: "Date");
        }
    }
}
