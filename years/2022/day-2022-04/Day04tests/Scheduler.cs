using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day04tests
{
    internal class Scheduler
    {
        public string[] RawPairs { get; private set; }
        public List<Team> Pairs{ get; private set; }

        public Scheduler()
        {
        }

        internal void LoadData(string path)
        {
            var data = File.ReadAllText(path);
            this.RawPairs = data.Split(Environment.NewLine);
            this.ProcessRawPairs();
        }

        private void ProcessRawPairs()
        {
            this.Pairs = new List<Team>();
            foreach (var pair in this.RawPairs)
            {
                this.AddPair(pair);
            }
        }

        private void AddPair(string pair)
        {
            var ranges = pair.Split(",");
            var elves = ranges.Select(range => new Elf(range)).ToList();
            this.Pairs.Add(new Team(elves));
        }

        internal object GetAnyRedudantPairs()
        {
            return this.Pairs.Count(pair => pair.IsAtAllRedundant);
        }

        internal int GetRedudantPairs()
        {
            return this.Pairs.Count(pair => pair.IsRedundant);
        }
    }
}