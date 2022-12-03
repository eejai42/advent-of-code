using System;
using System.Linq;

namespace TestProject5
{
    internal class RuckPacker
    {
        private string data;

        public RuckPacker(string data)
        {
            this.data = data;
        }

        internal int GetScore()
        {
            var rucksacks = this.data
                                .Split(Environment.NewLine)
                                .Select(line => new Rucksack(line))
                                .ToList();
            var priorities = rucksacks.Sum(rucksack => this.GetPriority(rucksack.ItemType));
            return priorities;
        }

        private int GetPriority(char itemType)
        {
            int charCode = (int)itemType;
            var priority = charCode < 97 ? charCode - 64 + 26: charCode - 96;
            return priority;
        }
    }
}