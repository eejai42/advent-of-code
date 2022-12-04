using System;
using System.Collections.Generic;

namespace Day12Tests
{
    public class Cave
    {
        public Cave()
        {
            this.LargeCaves = new List<Tunnel>();
            this.SmallCaves = new List<Tunnel>();
            this.VisitableCaves = new List<Tunnel>();
        }

        public string Name { get; internal set; }
        public bool IsStart { get { return String.Equals(this.Name, "start", StringComparison.OrdinalIgnoreCase); } }
        public bool IsEnd { get { return String.Equals(this.Name, "end", StringComparison.OrdinalIgnoreCase); } }

        public bool IsLarge { get { return this.Name == this.Name.ToUpper(); } }
        public bool IsSmall { get { return this.Name == this.Name.ToLower(); } }

        public List<Tunnel> Tunnels { get; internal set; }
        public List<Tunnel> LargeCaves { get; set; }
        public List<Tunnel> SmallCaves { get; set; }
        public bool IsInsideCave { get { return !this.IsStart && !this.IsEnd; } }

        public List<Tunnel> VisitableCaves { get; private set; }

        public override string ToString()
        {
            return this.Name;
        }

        internal void SeparateTunnels()
        {
            this.Tunnels.ForEach(tunnel => this.SeparateTunnel(tunnel));
        }

        private void SeparateTunnel(Tunnel tunnel)
        {
            Cave otherCave = this.GetOtherCave(tunnel);
            if (otherCave.IsInsideCave)
            {
                if (otherCave.IsSmall) this.SmallCaves.Add(tunnel);
                else this.LargeCaves.Add(tunnel);
            }
            if (!otherCave.IsStart) this.VisitableCaves.Add(tunnel);
        }

        public Cave GetOtherCave(Tunnel tunnel)
        {
            return (tunnel.LeftCave == this) ? tunnel.RightCave : tunnel.LeftCave;
        }
    }
}