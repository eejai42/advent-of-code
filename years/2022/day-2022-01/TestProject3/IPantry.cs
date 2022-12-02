using System.Collections.Generic;

namespace TestProject3
{
    internal interface IPantry
    {
        List<int> RawFoodInventory { get; }
        List<int> FoodItemsWithCalories { get; }
        bool HasMoreFoodWithCalories { get; }
        int NextFoodCalorieCount { get; }

        List<Elf> GetFedElves();
    }
}