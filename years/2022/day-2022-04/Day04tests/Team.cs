using System.Collections.Generic;
using System.Linq;

namespace Day04tests
{
    public class Team
    {
        private List<Elf> elves;

        public Team(List<Elf> elves)
        {
            this.elves = elves;
        }

        public bool IsRedundant
        {
            get
            {
                var first = this.elves.FirstOrDefault();
                var last = this.elves.Skip(1).FirstOrDefault();
                if (first.Min <= last.Min && first.Max >= last.Max) return true;
                if (last.Min <= first.Min && last.Max >= first.Max) return true;
                else return false;
            }
        }

        public bool IsAtAllRedundant
        {
            get
            {
                var first = this.elves.FirstOrDefault();
                var last = this.elves.Skip(1).FirstOrDefault();
                if (first.Min >= last.Min && first.Min <= last.Max) return true;
                if (first.Max >= last.Min && first.Max <= last.Max) return true;
                if (last.Min >= first.Min && last.Min <= first.Max) return true;
                if (last.Max >= first.Min && last.Max <= first.Max) return true;
                else return false;
            }
        }

        public override string ToString()
        {
            return $"{this.elves.Count} elves - {this.IsRedundant}";
        }
    }
}