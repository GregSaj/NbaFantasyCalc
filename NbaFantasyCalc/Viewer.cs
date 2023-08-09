using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbaFantasyCalc
{
    public class Viewer
    {
        public static void PlayersViewer(List<Player> players)
        {
            foreach (var item in players)
            {
                Console.WriteLine($"Rk: {item.Rk,-3} Name: {item.Name,-30} Pts: {item.PTS,-3} Rebound: {item.TRB,-3} Assists: {item.AST,-3} FG: {item.FG,-3} FGA: {item.FGA,-3} FT: {item.FT,-2} FTA: {item.FTA,-2} 3P: {item.num3P,-3} 3PA: {item.num3PA,-3} Steals: {item.STL} Blocks: {item.BLK} TO: {item.TOV} Date: {item.Date.ToString("dd-MM-yyyy")}");
            }
        }

        public static void SinglePlayerViewer(Player player)
        {
            Console.WriteLine($"Rk: {player.Rk,-3} Name: {player.Name,-30} Pts: {player.PTS,-3} Rebound: {player.TRB,-3} Assists: {player.AST,-3} FG: {player.FG,-3} FGA: {player.FGA,-3} FT: {player.FT,-2} FTA: {player.FTA,-2} 3P: {player.num3P,-3} 3PA: {player.num3PA,-3} Steals: {player.STL} Blocks: {player.BLK} TO: {player.TOV} Date: {player.Date.ToString("dd-MM-yyyy")}");
        }
    }
}
