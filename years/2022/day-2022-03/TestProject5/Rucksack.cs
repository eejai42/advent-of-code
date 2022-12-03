using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject5
{
    internal class Rucksack
    {
        private string RawData { get; }
        public int PackIndex { get; }
        public RucksackPacker RuckPacker { get; }
        public string Compartment1 { get; }
        public string Compartment2 { get; }
        public char ItemType { get; }

        public Rucksack(string line, RucksackPacker ruckPacker, int index)
        {
            this.RawData = line;
            this.PackIndex = index;
            this.RuckPacker = ruckPacker;
            this.Compartment1 = line.Substring(0, line.Length / 2);
            this.Compartment2 = line.Substring(line.Length / 2);
            this.ItemType = Compartment1.First(chr => this.Compartment2.Contains(chr));
        }

        internal char FindBadge(List<Rucksack> rucksacks)
        {
            var badge = this.RawData.First(chr => rucksacks.All(rucksack => rucksack.RawData.Contains(chr)));
            return badge;
        }
    }
}