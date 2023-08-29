using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NbaFantasyCalc.Migrations
{
    /// <inheritdoc />
    public partial class newOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rk = table.Column<int>(type: "int", nullable: false),
                    BasketballPlayerId = table.Column<int>(type: "int", nullable: false),
                    Tm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FG = table.Column<int>(type: "int", nullable: false),
                    FGA = table.Column<int>(type: "int", nullable: false),
                    FGper = table.Column<double>(type: "float", nullable: false),
                    num3P = table.Column<int>(type: "int", nullable: false),
                    num3PA = table.Column<int>(type: "int", nullable: false),
                    num3Pper = table.Column<double>(type: "float", nullable: false),
                    FT = table.Column<int>(type: "int", nullable: false),
                    FTA = table.Column<int>(type: "int", nullable: false),
                    FTper = table.Column<double>(type: "float", nullable: false),
                    ORB = table.Column<int>(type: "int", nullable: false),
                    DRB = table.Column<int>(type: "int", nullable: false),
                    TRB = table.Column<int>(type: "int", nullable: false),
                    AST = table.Column<int>(type: "int", nullable: false),
                    STL = table.Column<int>(type: "int", nullable: false),
                    BLK = table.Column<int>(type: "int", nullable: false),
                    TOV = table.Column<int>(type: "int", nullable: false),
                    PF = table.Column<int>(type: "int", nullable: false),
                    PTS = table.Column<int>(type: "int", nullable: false),
                    GmSc = table.Column<double>(type: "float", nullable: false),
                    Player_additional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scores_Players_BasketballPlayerId",
                        column: x => x.BasketballPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scores_BasketballPlayerId",
                table: "Scores",
                column: "BasketballPlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
