using System;

namespace Day04tests
{
    public class Elf
    {

        public Elf()
        {
        }

        public Elf(string range)
        {
            Range = range;
            this.ParseRange();
        }

        private void ParseRange()
        {
            var parts = this.Range.Split("-");
            this.Min = Int32.Parse(parts[0]);
            this.Max = Int32.Parse(parts[1]);
        }

        public string Range { get; }
        public int Min { get; private set; }
        public int Max { get; private set; }
    }
}