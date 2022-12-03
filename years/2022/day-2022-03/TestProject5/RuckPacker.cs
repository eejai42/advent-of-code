using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject5
{
    internal class RucksackPacker
    {
        private string RawData;

        public RucksackPacker(string rawData)
        {
            var index = 0;
            this.RawData = rawData;
            this.Rucksacks = this.RawData
                                .Split(Environment.NewLine)
                                .Select(line => new Rucksack(line, this, index++))
                                .ToList();
        }

        public List<Rucksack> Rucksacks { get; private set; }

        internal int GetScore()
        {
            var priorities = this.Rucksacks.Sum(rucksack => this.GetPriority(rucksack.ItemType));
            return priorities;
        }

        internal int GetBadgeScore()
        {
            var groups = this.Rucksacks.GroupBy(rucksack => Math.Floor(rucksack.PackIndex / 3.0));
            var badgeCodes = groups.Select(grp => (char)grp.First().FindBadge(grp.ToList())).ToList();
            var priorites = badgeCodes.Sum(badgeCode => this.GetPriority(badgeCode));
            return priorites;
        }

        private int GetPriority(char itemType)
        {
            int charCode = (int)itemType;
            var priority = charCode < 97 ? charCode - 64 + 26: charCode - 96;
            return priority;
        }
    }
}