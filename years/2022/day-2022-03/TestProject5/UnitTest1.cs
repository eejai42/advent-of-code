using NUnit.Framework;
using System.IO;

namespace TestProject5
{
    public class Tests
    {
        internal RuckPacker RuckPacker { get; private set; }

        [SetUp]
        public void Setup()
        {
            var data = File.ReadAllText("../../../../sample-data.txt");
            this.RuckPacker = new RuckPacker(data);
        }

        [Test]
        public void Test1()
        {
            var score = this.RuckPacker.GetScore();
            Assert.That(score, Is.EqualTo(157));
        }
    }
}