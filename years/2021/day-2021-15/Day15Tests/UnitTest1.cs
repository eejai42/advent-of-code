using NUnit.Framework;
using System.IO;

namespace Day15Tests
{
    public class Tests
    {
        internal Predictor Predictor { get; private set; }

        [SetUp]
        public void Setup()
        {
            var data = File.ReadAllText("../../../../sample-data.txt");
            this.Predictor = new Predictor(data);
        }

        [Test]
        public void Test1()
        {
            var shortestPath = this.Predictor.CalculateShortestPath();
            Assert.That(shortestPath, Is.EqualTo(40));
        }
    }
}