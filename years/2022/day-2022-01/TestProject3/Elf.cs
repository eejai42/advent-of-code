using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject3
{
    internal class Elf
    {
        public Elf()
        {
            this.Food = new List<Int32>();
        }

        public List<int> Food { get; }
        public Int32 CarryingCalories { get => this.Food.Sum(food => food); }

        internal void AddCalories(Int32 calories)
        {
            this.Food.Add(calories);
        }

    }
}