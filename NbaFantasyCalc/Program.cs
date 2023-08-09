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

            //FileWriter.JsonWriterTimeSpan(12, 03, 2019, 3); //works

            //FileWriter.JsonWriterSingleDay();

            var players = FileWriter.JsonDeserializeToPlayer();

            Viewer.PlayersViewer(players);

            //var westbrooks = players.Where(player => player.Name == "Russell Westbrook").ToList();
            //var pointsTotal = westbrooks.Select(x=>x.PTS).Sum();

            

            //Viewer.PlayersViewer(westbrooks);

            //Console.WriteLine(PointsCalculatorLinq.PointsCalc(players, "Russell Westbrook"));
            //Player player = new Player("Russell Westbrook");
            //Console.WriteLine(PointsCalculatorLinq.ReboundsCalc(players, player));
            //Console.WriteLine(pointsTotal);



        }
    }
}