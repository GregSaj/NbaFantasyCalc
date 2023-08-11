using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbaFantasyCalc
{
    public class Score
    {
        public int Rk { get; set; }
        public Player BasketballPlayer { get; set; }
        public string Tm { get; set; }
        public string Opp { get; set; }
        public string MP { get; set; }
        public int FG { get; set; }
        public int FGA { get; set; }
        public double FGper { get; set; }
        public int num3P { get; set; }
        public int num3PA { get; set; }
        public double num3Pper { get; set; }
        public int FT { get; set; }
        public int FTA { get; set; }
        public double FTper { get; set; }
        public int ORB { get; set; }
        public int DRB { get; set; }
        public int TRB { get; set; }
        public int AST { get; set; }
        public int STL { get; set; }
        public int BLK { get; set; }
        public int TOV { get; set; }
        public int PF { get; set; }
        public int PTS { get; set; }
        public double GmSc { get; set; }
        public string Player_additional { get; set; }
        public DateTime Date { get; set; }

        public Score(Player player)
        {
            this.BasketballPlayer = player;
        }
        public Score()
        {
            
        }
       



    }
}