using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Ink;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using NbaFantasyCalc.Entities;
using System.Diagnostics.Metrics;

namespace NbaFantasyCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var scores = BasketballStatsScraper.ScrapeBasketballStats(02, 10, 2023, 5);
            //FileWriter.JsonWriterTimeSpan(scores);
            //var scoresFromJson = FileWriter.JsonDeserializeToScores();
            Viewer.ScoresViewer(scores);

            //var players = BasketballStatsScraper.GetPlayersFromScores(scores);

            //Viewer.PlayersViewer(players);

            var shais = scores.Where(x => x.Player.Name == "Shai Gilgeous-Alexander").ToList();

            Viewer.ScoresViewer(shais);

            var context = new ScoreContext();

            //var playersFromDB = context.Players.ToList();

            //foreach (var playerz in playersFromDB)
            //{
            //    context.Remove(playerz);
            //}

            //var scoresFromDB = context.Scores.ToList();

            //foreach (var score in scoresFromDB)
            //{
            //    context.Remove(score);
            //}

            //context.SaveChanges();


            foreach (var score in scores)
            {
                //var existingPlayer = context.Players.FirstOrDefault(p => p.Name == score.BasketballPlayer.Name);

                //if (existingPlayer == null)
                //{
                //    // Tworzymy nowego gracza tylko jeśli go jeszcze nie ma
                //    existingPlayer = new Player(score.BasketballPlayer.Name)
                //    {
                //        Team = score.BasketballPlayer.Team
                //    };
                //    context.Players.Add(existingPlayer);

                //    context.SaveChanges();
                //}


                context.Scores.Add(score);
                //{
                //    Rk = score.Rk,
                //    Player = score.Player,
                //    PlayerName = score.Player.Name,
                //    Tm = score.Tm,
                //    Opp = score.Opp,
                //    MP = score.MP,
                //    FG = score.FG,
                //    FGA = score.FGA,
                //    FGper = score.FGper,
                //    num3P = score.num3P,
                //    num3PA = score.num3PA,
                //    num3Pper = score.num3Pper,
                //    FT = score.FT,
                //    FTA = score.FTA,
                //    ORB = score.ORB,
                //    DRB = score.DRB,
                //    TRB = score.TRB,
                //    AST = score.AST,
                //    STL = score.STL,
                //    BLK = score.BLK,
                //    TOV = score.TOV,
                //    PF = score.PF,
                //    PTS = score.PTS,
                //    GmSc = score.GmSc,
                //    Date = score.Date,
                //    Player_additional = score.Player_additional,
                //    FTper = score.FTper,

                //}) ;

            }

            context.SaveChanges();





            //Viewer.ScoresViewer(scoresFromDB);
















            //using (var context2 = new ScoreContext())
            //{
            //    foreach (var score in scores)
            //    {
            //        // Attach the existing BasketballPlayer to the context if it's not already attached
            //        if (score.BasketballPlayer != null && context2.Entry(score.BasketballPlayer).State == EntityState.Detached)
            //        {
            //            context2.Attach(score.BasketballPlayer);
            //        }

            //        var scr = new Score()
            //        {
            //            Rk = score.Rk,
            //            BasketballPlayer = score.BasketballPlayer,
            //            Tm = score.Tm,
            //            Opp = score.Opp,
            //            MP = score.MP,
            //            FG = score.FG,
            //            FGA = score.FGA,
            //            FGper = score.FGper,
            //            num3P = score.num3P,
            //            num3PA = score.num3PA,
            //            num3Pper = score.num3Pper,
            //            FT = score.FT,
            //            FTA = score.FTA,
            //            ORB = score.ORB,
            //            DRB = score.DRB,
            //            AST = score.AST,
            //            BLK = score.BLK,
            //            TOV = score.TOV,
            //            PF = score.PF,
            //            PTS = score.PTS,
            //            GmSc = score.GmSc,
            //            Date = score.Date,
            //            Player_additional = score.Player_additional
            //        };

            //        context2.Scores.Add(scr);
            //    }

            //    context2.SaveChanges();
            //}


            //var context = new ScoreContext();

            //var joelsFromDB = context.Scores.Where(x=>x.BasketballPlayer.Name == "Joel Embiid").ToList();
            //Viewer.ScoresViewer(joelsFromDB);

            //context.SaveChanges();

            //var context = new ScoreContext();
            //var scoresFromDB = context.Scores.ToList();

            //foreach (var score in scoresFromDB)
            //{
            //    context.Remove(score);
            //}

            //context.SaveChanges();










            ////var sth = BasketballStatsScraper.ScrapeBasketballStats();

            ////foreach (var item in sth)
            ////{
            ////    Console.WriteLine($"Rk: {item.Rk,-3} Name: {item.Name,-30} Pts: {item.PTS,-3} Rebound: {item.TRB,-3} Assists: {item.AST,-3} FG: {item.FG,-3} FGA: {item.FGA,-3} FT: {item.FT,-2} FTA: {item.FTA,-2} 3P: {item.num3P,-3} 3PA: {item.num3PA,-3} Steals: {item.STL} Blocks: {item.BLK} TO: {item.TOV} ");
            ////}


            ////Console.WriteLine("---------------------------------------------------------------------------------");

            ////var starting5 = sth.Take(5).ToArray();
            ////var bench = sth.TakeLast(3).ToArray();

            ////Console.WriteLine("Starting 5:");
            ////foreach (var player in starting5)
            ////{
            ////    Console.WriteLine($"Name: {player.Name} Pts: {player.PTS} Asyst: {player.AST}");
            ////    Console.WriteLine($"Points total: {player.PlayerFromStarting5PointsTotal()}");
            ////}

            ////Console.WriteLine("Bench:");
            ////foreach (var player in bench)
            ////{
            ////    Console.WriteLine($"Name: {player.Name} Pts: {player.PTS} Asyst: {player.AST}");
            ////    Console.WriteLine($"Points total: {player.PlayerFromBenchPointsTotal()}");

            ////}

            ////Team bullets = new Team(starting5[0], starting5[1], starting5[2], starting5[3], starting5[4], bench[0], bench[1], bench[2]);


            ////Console.WriteLine($"fantasy points from this day: {bullets.TeamPoints()}");

            ////FileWriter.JsonWriterTimeSpan(12, 03, 2018, 3); //works

            ////FileWriter.JsonWriterSingleDay();



            ////var scores = BasketballStatsScraper.ScrapeBasketballStats(12, 03, 2018, 3);

            ////FileWriter.JsonPlayersSerializaer(scores);

            ////var scores = FileWriter.JsonDeserializeToScores();

            ////Viewer.ScoresViewer(scores);

            ////var players = BasketballStatsScraper.GetPlayersFromScores(scores).Distinct();

            ////foreach (var player in players)
            ////{
            ////    Console.WriteLine(player.Name);
            ////}

            ////var durants = scores.Where(p => p.BasketballPlayer.Name == "Kevin Durant").ToList();

            ////Viewer.ScoresViewer(durants);

            ////var holidays = scores.Where(p => p.BasketballPlayer.Name == "Jrue Holiday").ToList();

            ////Viewer.ScoresViewer(holidays);

            ////Console.WriteLine("---------------------------------------------------------------------------------");


            ////Player selectedPlayer = players.FirstOrDefault(player => player.Name == "Kevin Durant");

            ////if (selectedPlayer != null)
            ////{
            ////    Console.WriteLine($"Zsumowane wyniki dla gracza {selectedPlayer.Name}:");

            ////    decimal startingPoints = PointsCalculator.StartingPlayerPoints(selectedPlayer);
            ////    decimal fantasyPTS = PointsCalculator.PointsCalc(selectedPlayer);

            ////    Console.WriteLine($"Punkty fantasy zsumowane startującego zawodnika: {startingPoints}");
            ////    Console.WriteLine($"Fantasy punkty zawodnika: {fantasyPTS}");
            ////}
            ////else
            ////{
            ////    Console.WriteLine($"Gracz {selectedPlayer.Name} nie został znaleziony.");
            ////}
            //Console.WriteLine("---------------------------------------------------------------------------------");

            //var playersFromURL = BasketballStatsScraper.GetPlayersWithScores(12, 03, 2018, 3);

            //Viewer.PlayersViewer(playersFromURL);

            //Console.WriteLine("---------------------------------------------------------------------------------");

            //var starting5 = playersFromURL.Take(5).ToArray();
            //var bench = playersFromURL.TakeLast(3).ToArray();

            //Console.WriteLine("Starting 5:");


            //foreach (var player in starting5)
            //{
            //    Console.WriteLine($"Name: {player.Name} Pts: {player.Scores.Sum(x => x.PTS)} Asyst: {player.Scores.Sum(x => x.AST)}");
            //    Console.WriteLine($"Points total: {player.StartingPlayerPoints()}");
            //}

            //Console.WriteLine("Bench:");
            //foreach (var player in bench)
            //{
            //    Console.WriteLine($"Name: {player.Name} Pts: {player.Scores.Sum(x => x.PTS)} Asyst: {player.Scores.Sum(x => x.AST)}");
            //    Console.WriteLine($"Points total: {player.BenchPlayerPoints()}");

            //}

            //Team bullets = new Team(starting5[0], starting5[1], starting5[2], starting5[3], starting5[4], bench[0], bench[1], bench[2]);


            //Console.WriteLine($"fantasy points from this day: {bullets.TeamPoints()}");

            //FileWriter.JsonPlayersSerializaer(playersFromURL);


        }

    }
}