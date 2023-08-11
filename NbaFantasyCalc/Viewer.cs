using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbaFantasyCalc
{
    public class Viewer
    {
        public static void ScoresViewer(List<Score> scores)
        {
            foreach (var item in scores)
            {
                Console.WriteLine($"Rk: {item.Rk,-3} Name: {item.BasketballPlayer.Name,-30} Pts: {item.PTS,-3} Rebound: {item.TRB,-3} Assists: {item.AST,-3} FG: {item.FG,-3} FGA: {item.FGA,-3} FT: {item.FT,-2} FTA: {item.FTA,-2} 3P: {item.num3P,-3} 3PA: {item.num3PA,-3} Steals: {item.STL} Blocks: {item.BLK} TO: {item.TOV} Date: {item.Date.ToString("dd-MM-yyyy")}");
            }
        }

        public static void SingleDayScoresViewer(Score score)
        {
            Console.WriteLine($"Rk: {score.Rk,-3} Name: {score.BasketballPlayer.Name,-30} Pts: {score.PTS,-3} Rebound: {score.TRB,-3} Assists: {score.AST,-3} FG: {score.FG,-3} FGA: {score.FGA,-3} FT: {score.FT,-2} FTA: {score.FTA,-2} 3P: {score.num3P,-3} 3PA: {score.num3PA,-3} Steals: {score.STL} Blocks: {score.BLK} TO: {score.TOV} Date: {score.Date.ToString("dd-MM-yyyy")}");
        }

        public static void PlayersViewer(List<Player> players)
        {
            foreach (var player in players)
            {
                Console.WriteLine(player.Name.ToString());
                foreach (var game in player.Scores)
                {
                    Console.WriteLine($"Rk: {game.Rk,-3} Name: {game.BasketballPlayer.Name,-30} Pts: {game.PTS,-3} Rebound: {game.TRB,-3} Assists: {game.AST,-3} FG: {game.FG,-3} FGA: {game.FGA,-3} FT: {game.FT,-2} FTA: {game.FTA,-2} 3P: {game.num3P,-3} 3PA: {game.num3PA,-3} Steals: {game.STL} Blocks: {game.BLK} TO: {game.TOV} Date: {game.Date.ToString("dd-MM-yyyy")}");
                }

                
            }
        }
    }
}
