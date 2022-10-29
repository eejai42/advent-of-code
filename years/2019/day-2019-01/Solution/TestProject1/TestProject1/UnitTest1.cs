using adventofcode.Lib.DataClasses;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestTestData()
        {
            var values = File.ReadLines("../../../TestData.txt");
            var fuelRequired = values.ToList()
                                  .Select(value => new QuantityOfMass(Int32.Parse(value)))
                                  .Sum(module => module.FuelRequired);
            Assert.That(fuelRequired, Is.EqualTo(3256794));
        }

        [Test]
        public void TestTestDataPart2()
        {
            var values = File.ReadLines("../../../TestData.txt");
            var finalFuelRequired = values.ToList()
                                  .Select(value => new QuantityOfMass(Int32.Parse(value)))
                                  .Sum(module => module.FinalFuelRequired);
            Assert.That(finalFuelRequired, Is.EqualTo(4882337));
        }


        [Test]
        public void Test1()
        {
            var module = new QuantityOfMass(12);
            Assert.That(module.FuelRequired, Is.EqualTo(2));
        }
    }
}