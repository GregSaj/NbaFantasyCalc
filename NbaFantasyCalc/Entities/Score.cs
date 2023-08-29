using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbaFantasyCalc.Entities
{
    public class Score
    {

        public int Id { get; set; }
        public int Rk { get; set; }        
        public Player Player { get; set; }
        //public int PlayerId { get; set; }
        public string PlayerName 
        {
            get { return Player.Name; }
            set { Player.Name = value; }

        } 
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
            Player = player;
        }    
    }
}