using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
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
        
        public static void JsonWriterSingleDay() //jak to zrobić żeby wyglądało jak w vieverze na stronie www
        {

            //metoda pojedynczego zapisu pliku
            List<Player> sth = BasketballStatsScraper.ScrapeBasketballStats();
            string fileName = "nba-fantasy-calc-daily.json";
            string jsonString = JsonSerializer.Serialize(sth);
            File.WriteAllText(fileName, jsonString);


            //List<Player> weeklyScoresCollection = new(); //eexception 429
            //int day;
            //for (day = 15; day < day + 5; day++)
            //{
            //    string date = $"month=01&day={day}&year=2010";
            //    string url = "https://www.basketball-reference.com/friv/dailyleaders.fcgi?" + date;
            //    List<Player> dailyScoresColletion = BasketballStatsScraper.ScrapeBasketballStats(url);
            //    weeklyScoresCollection.AddRange(dailyScoresColletion);
            //}                      

            //string fileName = "nba-fantasy-calc-weekly.json";
            //string jsonString = JsonSerializer.Serialize(weeklyScoresCollection);
            //File.WriteAllText(fileName, jsonString);
        }

        /// <summary>
        /// Method returns results for given timespan. Month format: 01, 02, 03... 11, 12
        /// </summary>
        /// <param name="month">"Format 01, 02, 03... 11, 12"</param>
        /// <param name="day"></param>
        /// <param name="year"></param>
        /// <param name="range"></param>
        public static void JsonWriterTimeSpan(int month, int day, int year, int range) 
        {

            List<Player> weeklyScoresCollection = new();

            int dayInLink = 0;
            
            for (int i = 0; i <= range; i++)
            {
                dayInLink = day + i;
                string date = $"month={month}&day={dayInLink}&year={year}";
                string url = "https://www.basketball-reference.com/friv/dailyleaders.fcgi?" + date;
                List<Player> dailyScoresColletion = BasketballStatsScraper.ScrapeBasketballStats(url);
                weeklyScoresCollection.AddRange(dailyScoresColletion);                
            }

            string fileName = "nba-fantasy-calc-weekly.json";
            string jsonString = JsonSerializer.Serialize(weeklyScoresCollection);
            File.WriteAllText(fileName, jsonString);
        }

        public static List<Player> JsonDeserializeToPlayer()
        {
            string fileName = "nba-fantasy-calc-weekly.json";
            string jsonContent = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<Player>>(jsonContent);            
        }

        public static List<Player> JsonDeserializeToPlayerFromSingleDay()
        {
            string fileName = "nba-fantasy-calc-daily.json";
            string jsonContent = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<Player>>(jsonContent);
        }




        public static void ExcelWriter(List<Player> players) 
        {
            List<Player> sth = BasketballStatsScraper.ScrapeBasketballStats();
            var workbook = new XLWorkbook();
            workbook.AddWorksheet("fantasy-points");
            var ws = workbook.Worksheet("fantasy-points");

            int row = 1;
            foreach (object player in sth)
            {
                ws.Cell("A" + row.ToString()).Value = player.ToString();
                row++;
            }

            workbook.SaveAs("fantasy-points.xlsx");
        }
        
    }
}
