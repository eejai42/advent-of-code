using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestProject3
{
    public class Tests
    {
        internal Pantry Pantry { get; private set; }
        internal List<Elf> Elves { get; private set; }

        [SetUp]
        public void Setup()
        {
            var file = File.ReadAllText("../../../data.txt");
            this.Pantry = new Pantry(file);
            this.Elves = this.Pantry.GetFedElves().OrderByDescending(elf => elf.CarryingCalories).ToList();
        }

        [Test]
        public void Test1()
        {
            var biggestElf = this.Elves.FirstOrDefault();
            Assert.That(biggestElf.CarryingCalories, Is.EqualTo(68802));
        }


        [Test]
        public void Test2()
        {
            var biggest3Elves = this.Elves.Take(3);
            var top3Calories = biggest3Elves.Sum(elf => elf.CarryingCalories);
            Assert.That(top3Calories, Is.EqualTo(68802));
        }
    }
}