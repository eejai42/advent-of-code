using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestProject6
{
    internal class Predictor
    {

        public List<SeaCucumber> SeaCucumbers { get; private set; }
        public int Width { get { return this.Lines[0].Length; } }
        public int Height { get { return this.Lines.Count; } }

        public List<string> Lines { get; }

        public Predictor(string data)
        {
            this.Lines = data.Split(Environment.NewLine).ToList();

            this.LoadBoard();
            this.PrintBoard(-1);
        }

        private void LoadBoard()
        {
            this.SeaCucumbers = new List<SeaCucumber>();
            for (int y = 0; y < this.Height; y++)
            {
                var line = this.Lines[y];
                for (int x = 0; x < this.Width; x++)
                {
                    var cucumberDirection = line[x];
                    if (cucumberDirection != '.')
                    {
                        this.SeaCucumbers.Add(new SeaCucumber(x, y, cucumberDirection, this));
                    }
                }
            }
        }

        internal bool CanMove(SeaCucumber seaCucumber)
        {
            // find next cucumber
            if (seaCucumber.IsEast)
            {
                var targetX = (seaCucumber.X + 1) % this.Width;
                return !this.SeaCucumbers.Any(any => any.X == targetX && any.Y == seaCucumber.Y);
            }
            else
            {
                var targetY = (seaCucumber.Y + 1) % this.Height;
                return !this.SeaCucumbers.Any(any => any.X == seaCucumber.X && any.Y == targetY);
            }
            return true;
        }

        internal int CountSteps()
        {
            var steps = 0;
            var cucsThatCanMove = this.SeaCucumbers.Where(cuc => cuc.IsEast && cuc.CanMove).ToList();
            bool walkingEast = false;
            while (cucsThatCanMove.Any())
            {
                this.PrintBoard(steps);
                cucsThatCanMove.ForEach(cuc => cuc.Move());
                steps++;
                cucsThatCanMove = this.SeaCucumbers.Where(cuc => cuc.IsEast == walkingEast && cuc.CanMove).ToList();
                walkingEast = !walkingEast;
                cucsThatCanMove.ForEach(cuc => cuc.Move());
                cucsThatCanMove = this.SeaCucumbers.Where(cuc => cuc.IsEast == walkingEast && cuc.CanMove).ToList();
                walkingEast = !walkingEast;
            }
            return steps + 1;
        }

        private void PrintBoard(int steps)
        {
            var sb = new StringBuilder();
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    var cuc = this.SeaCucumbers.FirstOrDefault(fod => fod.X == x && fod.Y == y);
                    if (cuc is null) sb.Append(".");
                    else if (cuc.IsEast) sb.Append(">");
                    else sb.Append("v");
                }
                sb.AppendLine();
            }
            File.WriteAllText($"../../../../step_{steps}.txt", sb.ToString());
        }
    }
}