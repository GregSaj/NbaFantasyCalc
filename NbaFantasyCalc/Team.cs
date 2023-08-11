using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NbaFantasyCalc
{
    public class Team
    {
        public string Name { get; set; }
        public Player p1 { get; set; }
        public Player p2 { get; set; }
        public Player p3 { get; set; }
        public Player p4 { get; set; }
        public Player p5 { get; set; }
        public Player p6Bench { get; set; }
        public Player p7Bench { get; set; }
        public Player p8Bench { get; set; }

        public Team(Player p1, Player p2, Player p3, Player p4, Player p5, Player p6Bench, Player p7Bench, Player p8Bench)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
            this.p5 = p5;
            this.p6Bench = p6Bench;
            this.p7Bench = p7Bench;
            this.p8Bench = p8Bench;
        }

        public decimal TeamPoints() //działa
        {
            PointsCalculator pointsCalculator = new PointsCalculator();
            return pointsCalculator.TeamPoints(this);
        }








    }
}
