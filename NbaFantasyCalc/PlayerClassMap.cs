using CsvHelper.Configuration;
using NbaFantasyCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbaFantasyCalc
{
    public class PlayerClassMap : ClassMap<Player>
    {
        public PlayerClassMap()
        {
            Map(m => m.Rk).Name("Rk");
            Map(m => m.Name).Name("Player");
            Map(m => m.Tm).Name("Tm");        
            Map(m => m.Opp).Name("Opp");       
            Map(m => m.MP).Name("MP");
            Map(m => m.FG).Name("FG");
            Map(m => m.FGA).Name("FGA");
            Map(m => m.FGper).Name("FG%");
            Map(m => m.num3P).Name("3P");
            Map(m => m.num3PA).Name("3PA");
            Map(m => m.num3Pper).Name("3P%");
            Map(m => m.FT).Name("FT");
            Map(m => m.FTA).Name("FTA");
            Map(m => m.FTper).Name("FT%");
            Map(m => m.ORB).Name("ORB");
            Map(m => m.DRB).Name("DRB");
            Map(m => m.TRB).Name("TRB");
            Map(m => m.AST).Name("AST");
            Map(m => m.STL).Name("STL");
            Map(m => m.BLK).Name("BLK");
            Map(m => m.TOV).Name("TOV");
            Map(m => m.PF).Name("PF");
            Map(m => m.PTS).Name("PTS");        
            Map(m => m.GmSc).Name("GmSc");
            Map(m => m.Player_additional).Name("Player-additional");
        }
    }
}
