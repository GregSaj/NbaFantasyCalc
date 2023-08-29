using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NbaFantasyCalc.Migrations
{
    /// <inheritdoc />
    public partial class newOne4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlayerName",
                table: "Scores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerName",
                table: "Scores");
        }
    }
}
