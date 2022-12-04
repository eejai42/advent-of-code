using System;
using System.Collections.Generic;
using System.Linq;

namespace Day12Tests
{
    internal class PathFind
    {

        public PathFind(string data)
        {
            this.Data = data.Split(Environment.NewLine).ToList();
            this.Caves = new List<Cave>();
            this.Tunnels = new List<Tunnel>();
            this.Data.ForEach(line => this.AddTunnel(line));
            this.InsideCaves = this.Caves.Where(cave => !cave.IsStart && !cave.IsEnd).ToList();
            this.LargeCaves = this.InsideCaves.Where(cave => cave.IsLarge).ToList();
            this.SmallCaves = this.InsideCaves.Where(cave => cave.IsSmall).ToList();
            this.ConnectAllCaves();
        }


        private void ConnectAllCaves()
        {
            this.Caves.ForEach(cave => this.ConnectCaveToOtherCaves(cave));
        }

        private void ConnectCaveToOtherCaves(Cave cave)
        {
            cave.Tunnels = this.Tunnels.Where(tunnel => cave == tunnel.LeftCave || cave == tunnel.RightCave).ToList();
            cave.SeparateTunnels();
        }

        private Tunnel AddTunnel(string line)
        {
            var parts = line.Split("-");
            var leftCave = this.GetOrAddCave(parts[0]);
            var rightCave = this.GetOrAddCave(parts[1]);
            return this.BuildTunnel(leftCave, rightCave);
        }

        private Tunnel BuildTunnel(Cave leftCave, Cave rightCave)
        {
            var newTunnel = new Tunnel()
            {
                LeftCave = leftCave,
                RightCave = rightCave
            };
            this.Tunnels.Add(newTunnel);
            return newTunnel;
        }

        private Cave GetOrAddCave(string name)
        {
            var cave = this.Caves.FirstOrDefault(fod => fod.Name == name);
            if (cave is null)
            {
                cave = new Cave()
                {
                    Name = name
                };
                this.Caves.Add(cave);
            }
            return cave;
        }

        public List<string> Data { get; }
        public List<Cave> Caves { get; }
        public List<Cave> InsideCaves { get; }
        public List<Cave> LargeCaves { get; }
        public List<Cave> SmallCaves { get; }
        public List<Tunnel> Tunnels { get; }
        public List<string> Paths { get; private set; }

        internal int CountPaths2()
        {
            this.Paths = new List<String>();
            var startNode = this.Caves.First(cave => cave.IsStart);
            var cavesVisited = new List<Cave>();
            cavesVisited.Add(startNode);
            this.FollowPath2(startNode, cavesVisited);
            return this.Paths.Count;
        }

        private void FollowPath2(Cave startNode, List<Cave> cavesVisited)
        {
            if (startNode.IsEnd)
            {
                this.AddPath(cavesVisited);
            }
            else
            {
                var canStillVisitSmallCavesTwice = this.CanStillVisitSmallCavesTwice(cavesVisited);
                var smallCavesVisited = cavesVisited.Where(cave => cave.IsSmall && !canStillVisitSmallCavesTwice);
                var visitableCaves = startNode.VisitableCaves.Select(tunnel => startNode.GetOtherCave(tunnel)).ToList();
                var unvisitedCaves = visitableCaves.Where(cave => !smallCavesVisited.Contains(cave));
                foreach (var caveToVisit in unvisitedCaves)
                {
                    var cavesVisitedNow = cavesVisited.ToList();
                    cavesVisitedNow.Add(caveToVisit);
                    this.FollowPath2(caveToVisit, cavesVisitedNow);
                }
            }
        }

        private bool CanStillVisitSmallCavesTwice(List<Cave> cavesVisited)
        {
            var smallCaves = cavesVisited.Where(cave => cave.IsSmall);
            var groupedByName = smallCaves.GroupBy(cave => cave.Name);
            return !groupedByName.Any(grp => grp.Count() > 1);
        }

        internal int CountPaths()
        {
            this.Paths = new List<String>();
            var startNode = this.Caves.First(cave => cave.IsStart);
            var cavesVisited = new List<Cave>();
            cavesVisited.Add(startNode);
            this.FollowPath(startNode, cavesVisited);
            return this.Paths.Count;
        }

        private void FollowPath(Cave startNode, List<Cave> cavesVisited)
        {
            if (startNode.IsEnd)
            {
                this.AddPath(cavesVisited);
            } else
            {
                var smallCavesVisited = cavesVisited.Where(cave => cave.IsSmall);
                var visitableCaves = startNode.VisitableCaves.Select(tunnel => startNode.GetOtherCave(tunnel)).ToList();
                var unvisitedCaves = visitableCaves.Where(cave => !smallCavesVisited.Contains(cave));
                foreach (var caveToVisit in unvisitedCaves)
                {
                    var cavesVisitedNow = cavesVisited.ToList();
                    cavesVisitedNow.Add(caveToVisit);
                    this.FollowPath(caveToVisit, cavesVisitedNow);
                }
            }
        }

        private void AddPath(List<Cave> cavesVisited)
        {
            var path = String.Join("->", cavesVisited);
            this.Paths.Add(path);
        }
    }
}