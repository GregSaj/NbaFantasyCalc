using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using HtmlAgilityPack;
using NbaFantasyCalc;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class BasketballStatsScraper
{
    private static Dictionary<string, Player> playersDictionary = new Dictionary<string, Player>();
    public static List<Score> ScrapeBasketballStats(int month, int day, int year, int range)
    {
        int dayInLink = 0;
        List<Score> results = new List<Score>();

        for (int i = 0; i <= range; i++)
        {
            dayInLink = day + i;
            string date = $"month={month}&day={dayInLink}&year={year}";
            string url = "https://www.basketball-reference.com/friv/dailyleaders.fcgi?" + date;

            WebClient webClient = new WebClient();
            string htmlContent = webClient.DownloadString(url);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);

            HtmlNode tableNode = doc.GetElementbyId("stats");

            if (tableNode != null)
            {
                DateTime matchDate = ExtractMatchDateFromUrl(url);
                List<List<string>> tableData = GetTableData(tableNode);
                List<Score> scores = TransformToScores(tableData, matchDate);

                results.AddRange(scores);
            }
            else
            {
                Console.WriteLine("Nie znaleziono tabeli o id=\"stats\" na stronie.");
                return new List<Score>();
            }
        }

        return results;
    }


    public static List<Score> ScrapeBasketballStats(string url)
    {
        Console.WriteLine("URL: " + url);

        WebClient webClient = new WebClient();
        string htmlContent = webClient.DownloadString(url);

        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(htmlContent);

        HtmlNode tableNode = doc.GetElementbyId("stats");

        if (tableNode != null)
        {

            // Pobieramy datę meczu (np. z URL)
            DateTime matchDate = ExtractMatchDateFromUrl(url);

            // Pobieramy zawartość tabeli jako listę listy stringów
            List<List<string>> tableData = GetTableData(tableNode);

            // Przekształcamy dane tabeli na listę obiektów Player
            List<Score> scores = TransformToScores(tableData, matchDate);

            return scores;
        }
        else
        {
            Console.WriteLine("Nie znaleziono tabeli o id=\"stats\" na stronie.");
            return new List<Score>();
        }
    }

  


    private static List<List<string>> GetTableData(HtmlNode tableNode)
    {
        List<List<string>> tableData = new List<List<string>>();
        var rows = tableNode.SelectNodes("tbody/tr");
        foreach (var row in rows)
        {
            var cells = row.SelectNodes("td");
            if (cells != null)
            {
                List<string> rowData = new List<string>();
                foreach (var cell in cells)
                {
                    rowData.Add(cell.InnerText.Trim());
                }
                tableData.Add(rowData);
            }
        }
        return tableData;
    }

    private static List<Score> TransformToScores(List<List<string>> tableData, DateTime matchDate)
    {
        List<Score> scores = new List<Score>();
        int rkCounter = 1; // Licznik numerków Rk

        foreach (var rowData in tableData)
        {
            string playerName = rowData[0];

            // Sprawdzamy, czy istnieje już obiekt typu Score dla danego gracza
            Score score = scores.FirstOrDefault(s => s.BasketballPlayer != null && s.BasketballPlayer.Name == playerName);

            if (score == null)
            {
                // Sprawdź, czy zawodnik jest już w słowniku, jeśli nie, dodaj go
                if (!playersDictionary.ContainsKey(playerName))
                {
                    Player existingPlayer = new Player(playerName);
                    playersDictionary.Add(playerName, existingPlayer);
                }

                // Pobierz zawodnika z słownika i przypisz go do wyniku
                Player player = playersDictionary[playerName];
                score = new Score(player);
                scores.Add(score);
                player.AddScore(score);
            }

            // Przypisujemy odpowiednie wartości z listy rowData do pól obiektu Score
            score.Rk = rkCounter;
            score.Tm = rowData[1];
            score.Opp = rowData[3];
            score.MP = rowData[5];
            score.FG = ConvertToInt(rowData[6]);
            score.FGA = ConvertToInt(rowData[7]);
            score.FGper = ConvertToDouble(rowData[8]);
            score.num3P = ConvertToInt(rowData[9]);
            score.num3PA = ConvertToInt(rowData[10]);
            score.num3Pper = ConvertToDouble(rowData[11]);
            score.FT = ConvertToInt(rowData[12]);
            score.FTA = ConvertToInt(rowData[13]);
            score.FTper = ConvertToDouble(rowData[14]);
            score.ORB = ConvertToInt(rowData[15]);
            score.DRB = ConvertToInt(rowData[16]);
            score.TRB = ConvertToInt(rowData[17]);
            score.AST = ConvertToInt(rowData[18]);
            score.STL = ConvertToInt(rowData[19]);
            score.BLK = ConvertToInt(rowData[20]);
            score.TOV = ConvertToInt(rowData[21]);
            score.PF = ConvertToInt(rowData[22]);
            score.PTS = ConvertToInt(rowData[23]);
            score.GmSc = ConvertToDouble(rowData[24]);
            score.Date = matchDate;
            score.Player_additional = rowData[25];          
          

            rkCounter++; // Zwiększamy licznik numerków Rk dla następnego gracza
        }

        return scores;
    }



    private static int ConvertToInt(string value)
    {
        if (int.TryParse(value, out int result))
        {
            return result;
        }

        // Wartość nie może zostać sparsowana, zwracamy wartość domyślną (0)
        return 0;
    }

    private static double ConvertToDouble(string value)
    {
        if (double.TryParse(value, out double result))
        {
            return result;
        }

        // Wartość nie może zostać sparsowana, zwracamy wartość domyślną (0.0)
        return 0.0;
    }

    private static DateTime ExtractMatchDateFromUrl(string url)
    {
        Uri uri = new Uri(url);
        string query = uri.Query;

        string[] queryParams = query.Split('&');

        int day = 0, month = 0, year = 0;

        foreach (string param in queryParams)
        {
            string[] keyValue = param.Split('=');

            if (keyValue.Length == 2)
            {
                if (keyValue[0] == "day")
                {
                    int.TryParse(keyValue[1], out day);
                }
                else if (keyValue[0] == "?month")
                {
                    int.TryParse(keyValue[1], out month);
                }
                else if (keyValue[0] == "year")
                {
                    int.TryParse(keyValue[1], out year);
                }
            }
        }

        if (day > 0 && month > 0 && year > 0)
        {
            try
            {
                DateTime matchDate = new DateTime(year, month, day);
                return matchDate;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd w parsowaniu daty: " + ex.Message);
            }
        }

        return DateTime.MinValue; // W przypadku błędu zwracamy wartość domyślną
    }

    public static List<Player> ScrapePlayers(string url)
    {
        List<Score> scores = ScrapeBasketballStats(url);
        List<Player> players = scores.Select(score => score.BasketballPlayer).ToList();
        return players;
    }
   

    public static List<Player> GetPlayersFromScores(List<Score> scores)
    {
        List<Player> players = scores.Select(score => score.BasketballPlayer).ToList();
        return players;
    }

    public static List<Player> GetPlayersWithScores(int month, int day, int year, int range)
    {
        List<Score> scores = ScrapeBasketballStats(month, day, year, range);
        List<Player> playersWithScores = playersDictionary.Values.ToList();
        return playersWithScores;
    }

}

