using System;
using System.Collections.Generic;
using System.Linq;

namespace Day15Tests
{
    internal class RiskLevel
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int RiskValue { get; }

        public Predictor Predictor { get; }

        public RiskLevel(int x, int y, string riskValue, Predictor predictor)
        {
            this.X = x;
            this.Y = y;
            this.RiskValue = Int32.Parse(riskValue);
            this.Predictor = predictor;
        }


        public override string ToString()
        {
            return $"{X}x{this.Y} = {this.RiskValue}";
        }

        private List<RiskLevel> _nearbyKeys;
        internal List<RiskLevel> GetNearbyKeys()
        {
            if (_nearbyKeys is null)
            {
                _nearbyKeys = this.Predictor.RiskLevels
                                            .Where(riskLevel => riskLevel.IsNearby(this))
                                            .ToList();
            }
            return _nearbyKeys;
        }

        private bool IsNearby(RiskLevel riskLevel)
        {
            if (((this.X == riskLevel.X - 1) && (this.Y == riskLevel.Y)) ||
                ((this.X == riskLevel.X + 1) && (this.Y == riskLevel.Y)) ||
                ((this.Y == riskLevel.Y - 1) && (this.X == riskLevel.X)) ||
                ((this.Y == riskLevel.Y + 1) && (this.X == riskLevel.X)))
            {
                return true;
            }
            else return false;
        }
    }
} 