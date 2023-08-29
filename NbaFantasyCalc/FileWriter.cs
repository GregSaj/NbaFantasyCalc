using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using NbaFantasyCalc.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NbaFantasyCalc
{
    public class FileWriter
    {
        
        //public static void JsonWriterSingleDay() //jak to zrobić żeby wyglądało jak w vieverze na stronie www
        //{

        //    //metoda pojedynczego zapisu pliku
        //    List<Score> sth = BasketballStatsScraper.ScrapeBasketballStats();
        //    string fileName = "nba-fantasy-calc-daily.json";
        //    string jsonString = JsonSerializer.Serialize(sth);
        //    File.WriteAllText(fileName, jsonString);


        //    //List<Player> weeklyScoresCollection = new(); //eexception 429
        //    //int day;
        //    //for (day = 15; day < day + 5; day++)
        //    //{
        //    //    string date = $"month=01&day={day}&year=2010";
        //    //    string url = "https://www.basketball-reference.com/friv/dailyleaders.fcgi?" + date;
        //    //    List<Player> dailyScoresColletion = BasketballStatsScraper.ScrapeBasketballStats(url);
        //    //    weeklyScoresCollection.AddRange(dailyScoresColletion);
        //    //}                      

        //    //string fileName = "nba-fantasy-calc-weekly.json";
        //    //string jsonString = JsonSerializer.Serialize(weeklyScoresCollection);
        //    //File.WriteAllText(fileName, jsonString);
        //}

        /// <summary>
        /// Method returns results for given timespan. Month format: 01, 02, 03... 11, 12
        /// </summary>
        /// <param name="month">"Format 01, 02, 03... 11, 12"</param>
        /// <param name="day"></param>
        /// <param name="year"></param>
        /// <param name="range"></param>
        public static void JsonWriterTimeSpan(int month, int day, int year, int range) 
        {

            List<Score> weeklyScoresCollection = new();

            int dayInLink = 0;
            
            for (int i = 0; i <= range; i++)
            {
                dayInLink = day + i;
                string date = $"month={month}&day={dayInLink}&year={year}";
                string url = "https://www.basketball-reference.com/friv/dailyleaders.fcgi?" + date;
                List<Score> dailyScoresColletion = BasketballStatsScraper.ScrapeBasketballStats(url);
                weeklyScoresCollection.AddRange(dailyScoresColletion);                
            }

            string fileName = "nba-fantasy-calc-weekly.json";
            string jsonString = JsonSerializer.Serialize(weeklyScoresCollection);
            File.WriteAllText(fileName, jsonString);
        }

        public static void JsonWriterTimeSpan(List<Score> scores)
        {
            string fileName = "nba-fantasy-calc-range.json";
            string jsonString = JsonSerializer.Serialize(scores);
            File.WriteAllText(fileName, jsonString);
        }

        public static List<Score> JsonDeserializeToScores()
        {
            string fileName = "nba-fantasy-calc-range.json";
            string jsonContent = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<Score>>(jsonContent);            
        }

        public static List<Score> JsonDeserializeToScoreFromSingleDay()
        {
            string fileName = "nba-fantasy-calc-daily.json";
            string jsonContent = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<Score>>(jsonContent);
        }     
        
        public static void JsonPlayersSerializaer(List<Player> players) // problem z object cycle
        {
            string fileName = "nba-fantasy-calc-players-range.json";
            string jsonString = JsonSerializer.Serialize(players);
            File.WriteAllText(fileName, jsonString);
        }


        
    }
}
