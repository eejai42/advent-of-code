using System.Collections.Generic;

namespace TestProject3
{
    internal interface IElf
    {
        int TotalCaloriesCarried { get; }
        List<int> ItemWithCalories { get; }
    }
}