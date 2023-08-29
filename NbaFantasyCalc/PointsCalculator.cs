using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbaFantasyCalc.Entities;

namespace NbaFantasyCalc
{
    public class PointsCalculator
    {
        public const int points = 1;
        public const int threes = 1;
        public const double rebounds = 1.2;
        public const double asists = 1.5;
        public const int steals = 2;
        public const int blocks = 2;
        public const int TO = -2;
        public const double fga = -0.45;
        public const double fg = 1;
        public const double fta = -0.75;
        public const double ft = 1;
        public const double benchPointsRate = 0.5;

        public static int PointsCalc(Player player)
        {
            return points * player.Scores.Sum(x => x.PTS);
        }

        public static int ThreesCalc(Player player)
        {
            return threes * player.Scores.Sum(x => x.num3P);
        }

        public static double ReboundsCalc(Player player)
        {
            return rebounds * (player.Scores.Sum(x => x.TRB));
        }

        public static double AsistsCalc(Player player)
        {
            return asists * (player.Scores.Sum(x => x.AST));
        }

        public static int StealsCalc(Player player)
        {
            return steals * (player.Scores.Sum(x => x.STL));
        }

        public static int BlocksCalc(Player player)
        {
            return blocks * (player.Scores.Sum(x => x.BLK));
        }

        public static int TOCalc(Player player)
        {
            return TO * (player.Scores.Sum(x => x.TOV));
        }

        public static double FieldGoalCalc(Player player)
        {
            return (fg * (player.Scores.Sum(x=>x.FG))) + (fga * (player.Scores.Sum(x => x.FGA)));
        }
        public static double FreeThrowCalc(Player player)
        {
            return (fg * (player.Scores.Sum(x => x.FT))) + (fga * (player.Scores.Sum(x => x.FTA)));
        }

        public static decimal StartingPlayerPoints(Player player)
        {
            decimal totalPoints = Convert.ToDecimal(player.Scores.Sum(score =>
                points * score.PTS +
                threes * score.num3P +
                rebounds * score.TRB +
                asists * score.AST +
                steals * score.STL +
                blocks * score.BLK +
                TO * score.TOV +
                (fg * score.FG + fga * score.FGA) +
                (ft * score.FT + fta * score.FTA)
            ));

            return totalPoints;
        }

        public static decimal BenchPlayerPoints (Player player)
        {
            int points = PointsCalc(player);
            int threes = ThreesCalc(player);
            double rebounds = ReboundsCalc(player);
            double assists = AsistsCalc(player);
            int steals = StealsCalc(player);
            int blocks = BlocksCalc(player);
            int turnovers = TOCalc(player);
            double fieldGoals = FieldGoalCalc(player);
            double freeThrows = FreeThrowCalc(player);

            decimal totalPoints = Convert.ToDecimal((points + threes + rebounds + assists + steals + blocks + turnovers + fieldGoals + freeThrows) * benchPointsRate);
            return totalPoints;
        }

        public decimal TeamPoints(Team team)
        {
            Player[] starting5 = new Player[5] { team.p1, team.p2, team.p3, team.p4, team.p5 };
            Player[] bench = new Player[3] { team.p6Bench, team.p7Bench, team.p8Bench };          
            

            decimal points = 0;

            foreach (var player in starting5)
            {
                points = points + StartingPlayerPoints(player);
            }

            foreach (var player in bench)
            {
                points = points + BenchPlayerPoints(player);
            }

            return points;
        }

    }

}