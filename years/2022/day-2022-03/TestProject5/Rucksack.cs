using System.Linq;

namespace TestProject5
{
    internal class Rucksack
    {
        private string RawData { get; }

        public string Compartment1 { get; }
        public string Compartment2 { get; }
        public char ItemType { get; }

        public Rucksack(string line)
        {
            this.RawData = line;
            this.Compartment1 = line.Substring(0, line.Length / 2);
            this.Compartment2 = line.Substring(line.Length / 2);
            this.ItemType = Compartment1.First(chr => this.Compartment2.Contains(chr));
        }
    }
}