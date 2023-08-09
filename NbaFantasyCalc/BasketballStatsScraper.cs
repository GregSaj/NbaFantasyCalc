using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using HtmlAgilityPack;
using NbaFantasyCalc;

public class BasketballStatsScraper
{

    public static List<Player> ScrapeBasketballStats(string url)
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
            List<Player> players = TransformToPlayers(tableData, matchDate);

            return players;
        }
        else
        {
            Console.WriteLine("Nie znaleziono tabeli o id=\"stats\" na stronie.");
            return new List<Player>();
        }
    }

    public static List<Player> ScrapeBasketballStats()
    {
        string url = "https://www.basketball-reference.com/friv/dailyleaders.fcgi?month=01&day=16&year=2010";

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
            List<Player> players = TransformToPlayers(tableData, matchDate);

            return players;
        }
        else
        {
            Console.WriteLine("Nie znaleziono tabeli o id=\"stats\" na stronie.");
            return new List<Player>();
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

    private static List<Player> TransformToPlayers(List<List<string>> tableData, DateTime matchDate)
    {
        List<Player> players = new List<Player>();
        int rkCounter = 1; // Licznik numerków Rk

        foreach (var rowData in tableData)
        {
            Player player = new Player
            {
                // Przypisujemy odpowiednie wartości z listy rowData do pól obiektu Player
                Rk = rkCounter,
                Name = rowData[0],
                Tm = rowData[1],
                Opp = rowData[3],
                MP = rowData[5],
                FG = ConvertToInt(rowData[6]),
                FGA = ConvertToInt(rowData[7]),
                FGper = ConvertToDouble(rowData[8]),
                num3P = ConvertToInt(rowData[9]),
                num3PA = ConvertToInt(rowData[10]),
                num3Pper = ConvertToDouble(rowData[11]),
                FT = ConvertToInt(rowData[12]),
                FTA = ConvertToInt(rowData[13]),
                FTper = ConvertToDouble(rowData[14]),
                ORB = ConvertToInt(rowData[15]),
                DRB = ConvertToInt(rowData[16]),
                TRB = ConvertToInt(rowData[17]),
                AST = ConvertToInt(rowData[18]),
                STL = ConvertToInt(rowData[19]),
                BLK = ConvertToInt(rowData[20]),
                TOV = ConvertToInt(rowData[21]),
                PF = ConvertToInt(rowData[22]),
                PTS = ConvertToInt(rowData[23]),
                GmSc = ConvertToDouble(rowData[24]),
                Date = matchDate,
                Player_additional = rowData[25]
               
            };

            rkCounter++; // Zwiększamy licznik numerków Rk dla następnego gracza
            players.Add(player);
        }

        return players;
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













}

