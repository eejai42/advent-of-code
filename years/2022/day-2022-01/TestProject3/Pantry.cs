using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject3
{
    internal class Pantry
    {
        
        public Pantry(string food)
        {
            this.FoodItems = food.Split(Environment.NewLine)
                                    .Select(item => String.IsNullOrEmpty(item) ? -1 : Int32.Parse(item))
                                    .ToList();
        }

        public List<Int32> FoodItems { get; }
        public List<Int32> FoodItemsWithCalories { get => this.FoodItems.Where(item => item > 0).ToList(); }
        public Int32 NextItem { get => this.HasMoreFood ? this.FoodItems.FirstOrDefault() : -1; }
        public bool HasMoreFood { get => this.FoodItemsWithCalories.Any(); }

        internal List<Elf> GetFedElves()
        {
            var elves = new List<Elf>();
            while (this.HasMoreFood)
            {
                var elf = new Elf();
                while (this.NextItem != -1)
                {
                    elf.AddCalories(this.GetNextFoodItem());
                }
                this.GetNextFoodItem();
                elves.Add(elf);

            }
            return elves;
        }

        private Int32 GetNextFoodItem()
        {
            if (!this.FoodItems.Any()) return -1;
            else
            {
                var next = this.FoodItems.First();
                this.FoodItems.RemoveAt(0);
                return next;
            }
        }
    }
}