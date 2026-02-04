using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GigHub.Migrations
{
    /// <inheritdoc />
    public partial class AddIsCanceledToGig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "Gigs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Gigs");
        }
    }
}
