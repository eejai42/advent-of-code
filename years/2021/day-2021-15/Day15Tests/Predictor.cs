using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day15Tests
{
    internal class Predictor
    {

        public List<RiskLevel> RiskLevels { get; private set; }
        public Dictionary<string, RiskLevel> RiskLevelsByLocation { get; private set; }

        public int Width { get { return this.Lines[0].Length; } }
        public int Height { get { return this.Lines.Count; } }

        public List<string> Lines { get; }
        public int BestPathRisk { get; private set; }
        public List<RiskLevel> BestPath { get; private set; }

        public Predictor(string data)
        {
            this.Lines = data.Split(Environment.NewLine).ToList();

            this.LoadBoard();
            this.PrintBoard(-1);
        }

        private void LoadBoard()
        {
            this.RiskLevels = new List<RiskLevel>();
            this.RiskLevelsByLocation = new Dictionary<String, RiskLevel>();
            for (int y = 0; y < this.Height; y++)
            {
                var line = this.Lines[y];
                for (int x = 0; x < this.Width; x++)
                {
                    var riskValue = line[x].ToString();
                    var riskLevel = new RiskLevel(x, y, riskValue, this);
                    this.RiskLevels.Add(riskLevel);
                    this.RiskLevelsByLocation[$"{x}x{y}"] = riskLevel;
                }
            }
        }

        internal int CalculateShortestPath()
        {
            this.BestPathRisk = int.MaxValue;
            List<RiskLevel> shortestPath = new List<RiskLevel>();
            List<RiskLevel> pathLocation = new List<RiskLevel>();
            var startingRL = this.RiskLevelsByLocation["0x0"];
            this.PrintBoard(0);
            this.FollowPathFrom(startingRL, pathLocation, 0);
            return this.BestPathRisk;
        }

        private void FollowPathFrom(RiskLevel riskLevel, List<RiskLevel> pathLocation, int totalPathRisk)
        {
            if (pathLocation.Count > 300)
            {
            Console.WriteLine($"COUNT: {pathLocation.Count} - {riskLevel}");
                return;
            }
            if (pathLocation.Count > 10000)
            {
                object o = 1;
            }
            try
            {
                if (riskLevel.X + 1 == this.Width && riskLevel.Y + 1 == this.Height)
                {
                    if (totalPathRisk < this.BestPathRisk)
                    {
                        this.BestPathRisk = totalPathRisk;
                        this.BestPath = pathLocation;
                    }
                    return;
                }
                else if (totalPathRisk > this.BestPathRisk) return;
                else
                {
                    var nearbyKeys = riskLevel.GetNearbyKeys();
                    var unusedNearbyKeys = nearbyKeys.Where(key => !pathLocation.Any(any => any == key)).ToList();
                    foreach (var unusedKey in unusedNearbyKeys)
                    {
                        var newPath = pathLocation.ToList();
                        newPath.Add(riskLevel);
                        this.FollowPathFrom(unusedKey, newPath, totalPathRisk + unusedKey.RiskValue);
                    }
                }
            }
            catch (Exception ex)
            {
                object o = ex;
            }
        }

        private void PrintBoard(int steps)
        {
            var sb = new StringBuilder();
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    var riskLevel = this.RiskLevels.FirstOrDefault(fod => fod.X == x && fod.Y == y);
                    sb.Append(riskLevel.RiskValue);
                }
                sb.AppendLine();
            }
            File.WriteAllText($"../../../../step_{steps}.txt", sb.ToString());
        }
    }
}