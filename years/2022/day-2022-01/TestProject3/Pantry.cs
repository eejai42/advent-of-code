using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject3
{
    internal class Pantry : IPantry
    {

        public Pantry(string rawFoodInvventoryText)
        {
            this.RawFoodInventory = rawFoodInvventoryText.Split(Environment.NewLine)
                                                        .Select(item => String.IsNullOrEmpty(item) ? -1 : Int32.Parse(item))
                                                        .ToList();
        }

        public List<Int32> RawFoodInventory { get; }
        public List<Int32> FoodItemsWithCalories { get => this.RawFoodInventory.Where(item => item > 0).ToList(); }
        public bool HasMoreFoodWithCalories { get => this.FoodItemsWithCalories.Any(); }
        public Int32 NextFoodCalorieCount { get => this.HasMoreFoodWithCalories ? this.RawFoodInventory.FirstOrDefault() : -1; }

        public List<Elf> GetFedElves()
        {
            var elves = new List<Elf>();
            while (this.HasMoreFoodWithCalories)
            {
                var elf = new Elf();
                while (this.NextFoodCalorieCount != -1)
                {
                    elf.AddCalories(this.GetNextRawCalorieValue());
                }
                this.GetNextRawCalorieValue();
                elves.Add(elf);

            }
            return elves;
        }

        private Int32 GetNextRawCalorieValue()
        {
            if (!this.RawFoodInventory.Any()) return -1;
            else
            {
                var next = this.RawFoodInventory.First();
                this.RawFoodInventory.RemoveAt(0);
                return next;
            }
        }
    }
}