using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GigHub.Migrations
{
    /// <inheritdoc />
    public partial class PopulateGenresTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                    table: "Genres",
                    columns: new[] { "Id", "Name" },
                    values: new object[,]
                    {
                        { "1", "Jazz" },
                        { "2", "Blues" },
                        { "3", "Rock" },
                        { "4", "Country" },
                    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "Genres", keyColumn: "Id", keyValue: 1);


            migrationBuilder.DeleteData(table: "Genres", keyColumn: "Id", keyValue: 2);

            migrationBuilder.DeleteData(table: "Genres", keyColumn: "Id", keyValue: 3);


            migrationBuilder.DeleteData(table: "Genres", keyColumn: "Id", keyValue: 4);
        }
    }
}
