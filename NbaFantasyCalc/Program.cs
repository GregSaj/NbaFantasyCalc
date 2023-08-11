using DocumentFormat.OpenXml.Vml.Spreadsheet;

namespace NbaFantasyCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var sth = BasketballStatsScraper.ScrapeBasketballStats();

            //foreach (var item in sth)
            //{
            //    Console.WriteLine($"Rk: {item.Rk,-3} Name: {item.Name,-30} Pts: {item.PTS,-3} Rebound: {item.TRB,-3} Assists: {item.AST,-3} FG: {item.FG,-3} FGA: {item.FGA,-3} FT: {item.FT,-2} FTA: {item.FTA,-2} 3P: {item.num3P,-3} 3PA: {item.num3PA,-3} Steals: {item.STL} Blocks: {item.BLK} TO: {item.TOV} ");
            //}


            //Console.WriteLine("---------------------------------------------------------------------------------");

            //var starting5 = sth.Take(5).ToArray();
            //var bench = sth.TakeLast(3).ToArray();

            //Console.WriteLine("Starting 5:");
            //foreach (var player in starting5)
            //{
            //    Console.WriteLine($"Name: {player.Name} Pts: {player.PTS} Asyst: {player.AST}");
            //    Console.WriteLine($"Points total: {player.PlayerFromStarting5PointsTotal()}");
            //}

            //Console.WriteLine("Bench:");
            //foreach (var player in bench)
            //{
            //    Console.WriteLine($"Name: {player.Name} Pts: {player.PTS} Asyst: {player.AST}");
            //    Console.WriteLine($"Points total: {player.PlayerFromBenchPointsTotal()}");

            //}

            //Team bullets = new Team(starting5[0], starting5[1], starting5[2], starting5[3], starting5[4], bench[0], bench[1], bench[2]);


            //Console.WriteLine($"fantasy points from this day: {bullets.TeamPoints()}");

            //FileWriter.JsonWriterTimeSpan(12, 03, 2018, 3); //works

            //FileWriter.JsonWriterSingleDay();



            //var scores = BasketballStatsScraper.ScrapeBasketballStats(12, 03, 2018, 3);

            //FileWriter.JsonWriterTimeSpan(scores);

            var scores = FileWriter.JsonDeserializeToScores();

            Viewer.ScoresViewer(scores);

            var players = BasketballStatsScraper.GetPlayersFromScores(scores).Distinct();

            foreach (var player in players)
            {
                Console.WriteLine(player.Name);
            }

            var durants = scores.Where(p => p.BasketballPlayer.Name == "Kevin Durant").ToList();

            Viewer.ScoresViewer(durants);

            var holidays = scores.Where(p => p.BasketballPlayer.Name == "Jrue Holiday").ToList();

            Viewer.ScoresViewer(holidays);

            Console.WriteLine("---------------------------------------------------------------------------------");
            

            Player selectedPlayer = players.FirstOrDefault(player => player.Name == "Kevin Durant");

            if (selectedPlayer != null)
            {
                Console.WriteLine($"Zsumowane wyniki dla gracza {selectedPlayer.Name}:");

                decimal startingPoints = PointsCalculator.StartingPlayerPoints(selectedPlayer);
                decimal fantasyPTS = PointsCalculator.PointsCalc(selectedPlayer);

                Console.WriteLine($"Punkty fantasy zsumowane startującego zawodnika: {startingPoints}");
                Console.WriteLine($"Fantasy punkty zawodnika: {fantasyPTS}");
            }
            else
            {
                Console.WriteLine($"Gracz {selectedPlayer.Name} nie został znaleziony.");
            }
            Console.WriteLine("---------------------------------------------------------------------------------");

            var playersFromURL = BasketballStatsScraper.GetPlayersWithScores(12, 03, 2018, 3);
            
            Viewer.PlayersViewer(playersFromURL);

            Console.WriteLine("---------------------------------------------------------------------------------");

            var starting5 = players.Take(5).ToArray();
            var bench = players.TakeLast(3).ToArray();

            Console.WriteLine("Starting 5:");


            foreach (var player in starting5)
            {
                Console.WriteLine($"Name: {player.Name} Pts: {player.Scores.Sum(x => x.PTS)} Asyst: {player.Scores.Sum(x => x.AST)}");
                Console.WriteLine($"Points total: {player.StartingPlayerPoints()}");
            }

            Console.WriteLine("Bench:");
            foreach (var player in bench)
            {
                Console.WriteLine($"Name: {player.Name} Pts: {player.Scores.Sum(x => x.PTS)} Asyst: {player.Scores.Sum(x => x.AST)}");
                Console.WriteLine($"Points total: {player.BenchPlayerPoints()}");

            }

            Team bullets = new Team(starting5[0], starting5[1], starting5[2], starting5[3], starting5[4], bench[0], bench[1], bench[2]);


            Console.WriteLine($"fantasy points from this day: {bullets.TeamPoints()}");


        }
    }
}