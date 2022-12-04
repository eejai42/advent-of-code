using NUnit.Framework;
using System.IO;

namespace TestProject6
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
            int steps = this.Predictor.CountSteps();
            Assert.That(steps, Is.EqualTo(598));
        }
    }
}