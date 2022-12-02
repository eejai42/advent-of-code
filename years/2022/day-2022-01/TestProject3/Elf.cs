using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject3
{
    internal class Elf : IElf
    {
        public Elf()
        {
            this.ItemWithCalories = new List<Int32>();
        }

        public List<int> ItemWithCalories { get; }
        public Int32 TotalCaloriesCarried { get => this.ItemWithCalories.Sum(food => food); }

        internal void AddCalories(Int32 calories)
        {
            this.ItemWithCalories.Add(calories);
        }

    }

}