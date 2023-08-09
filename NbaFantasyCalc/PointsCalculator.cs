using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public const int turnover = -2;
        public const double fga = -0.45;
        public const double fg = 1;
        public const double fta = -0.75;
        public const double ft = 1;
        public const double benchPointsRate = 0.5;

        public int PointsCalc(Player player)
        {
            return points * player.PTS;
        }

        public int ThreesCalc(Player player)
        {
            return threes * player.num3P;
        }

        public double ReboundsCalc(Player player)
        {
            return rebounds * player.TRB;
        }

        public double AsistsCalc(Player player)
        {
            return asists * player.AST;
        }

        public int StealsCalc(Player player)
        {
            return steals * player.STL;
        }

        public int BlocksCalc(Player player)
        {
            return blocks * player.BLK;
        }

        public int TOCalc(Player player)
        {
            return turnover * player.TOV;
        }

        public double FieldGoalCalc(Player player)
        {
            return (fg * player.FG) + (fga * player.FGA);
        }
        public double FreeThrowCalc(Player player)
        {
            return (ft * player.FT) + (fta * player.FTA);
        }

        public decimal PlayerFromStarting5PointsTotal(Player player)
        {
            return Convert.ToDecimal(PointsCalc(player) + ThreesCalc(player) + ReboundsCalc(player) + AsistsCalc(player) + StealsCalc(player) + BlocksCalc(player) + TOCalc(player) + FieldGoalCalc(player) + FreeThrowCalc(player));
        }

        public decimal PlayerFromBenchPointsTotal(Player player)
        {
            return Convert.ToDecimal((PointsCalc(player) + ThreesCalc(player) + ReboundsCalc(player) + AsistsCalc(player) + StealsCalc(player) + BlocksCalc(player) + TOCalc(player) + FieldGoalCalc(player) + FreeThrowCalc(player)) * 0.5);
        }

        public decimal TeamPoints(Team team)
        {
            Player[] starting5 = new Player[5] { team.p1, team.p2, team.p3, team.p4, team.p5 };
            Player[] bench = new Player[3] { team.p6Bench, team.p7Bench, team.p8Bench };          
            

            decimal points = 0;

            foreach (var player in starting5)
            {
                points = points + PlayerFromStarting5PointsTotal(player);
            }

            foreach (var player in bench)
            {
                points = points + PlayerFromBenchPointsTotal(player);
            }

            return points;
        }

    }

}