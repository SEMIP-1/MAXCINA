using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAXCINA.Migrations
{
    /// <inheritdoc />
    public partial class addtrafictoMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Traffic",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Traffic",
                table: "Movies");
        }
    }
}
