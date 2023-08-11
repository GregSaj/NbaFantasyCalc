using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NbaFantasyCalc
{
    public class Player : Score
    {
        public string Name { get; set; }
        public string Team { get; set; }
   
        public List<Score> Scores { get; set; }

        public Player(string name)
        {
            Name = name;
            Scores = new List<Score>();
        }

        public void AddScore(Score score)
        {
            Scores.Add(score);
            score.BasketballPlayer = this;
        }

        public decimal StartingPlayerPoints() //działa
        {
            //PointsCalculator pointsCalculator = new PointsCalculator();
            //return pointsCalculator.StartingPlayerPoints(this);

            return PointsCalculator.StartingPlayerPoints(this);
        }

        public decimal BenchPlayerPoints() //działa
        {
            PointsCalculator pointsCalculator = new PointsCalculator();
            //return pointsCalculator.StartingPlayerPoints(this);

            return PointsCalculator.BenchPlayerPoints(this);
        }

    }

}
