using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NbaFantasyCalc.Migrations
{
    /// <inheritdoc />
    public partial class newOne2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Players_BasketballPlayerId",
                table: "Scores");

            migrationBuilder.RenameColumn(
                name: "BasketballPlayerId",
                table: "Scores",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_BasketballPlayerId",
                table: "Scores",
                newName: "IX_Scores_PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Players_PlayerId",
                table: "Scores",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Players_PlayerId",
                table: "Scores");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Scores",
                newName: "BasketballPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_PlayerId",
                table: "Scores",
                newName: "IX_Scores_BasketballPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Players_BasketballPlayerId",
                table: "Scores",
                column: "BasketballPlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
