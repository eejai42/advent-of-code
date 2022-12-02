using NUnit.Framework;
using System;
using System.IO;

namespace TestProject4
{
    public class Tests
    {
        internal StrategyGuide StrategyGuide { get; private set; }

        [SetUp]
        public void Setup()
        {
            var data = File.ReadAllText("../../../../sample-data.txt");
            this.StrategyGuide = new StrategyGuide(data);
        }

        [Test]
        public void Test1()
        {
            Int32 value = this.StrategyGuide.GetTotal();
            var expectedValue = this.StrategyGuide.GetExpecteGameScore();
            Assert.That(value, Is.EqualTo(12535));
        }
    }
}