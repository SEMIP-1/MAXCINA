using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAXCINA.Migrations
{
    /// <inheritdoc />
    public partial class SeedCatagoriesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories VALUES ('Action'), ('Comedy'), ('Drama'), ('Documentary'), ('Cartoon'), ('Horror')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("turncate table Categories");
        }
    }
}
