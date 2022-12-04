using System;

namespace TestProject6
{
    internal class SeaCucumber
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool IsEast { get; }
        public char Direction { get; }

        public Predictor Predictor { get; }

        public SeaCucumber(int x, int y, char direction, Predictor predictor)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
            this.IsEast = direction == '>';
            this.Predictor = predictor;
        }

        public bool CanMove
        {
            get
            {
                return (Predictor.CanMove(this));
            }
        }

        internal void Move()
        {
            if (this.IsEast) this.X = (this.X + 1) % this.Predictor.Width;
            else this.Y = (this.Y + 1) % this.Predictor.Height;
        }

        public override string ToString()
        {
            return $"{X}x{this.Y}:{(this.IsEast ? ">" : "V")}";
        }
    }
} 