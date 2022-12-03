using NUnit.Framework;
using System.IO;

namespace TestProject5
{
    public class Tests
    {
        internal RucksackPacker RuckPacker { get; private set; }

        [SetUp]
        public void Setup()
        {
            var data = File.ReadAllText("../../../../sample-data.txt");
            this.RuckPacker = new RucksackPacker(data);
        }

        [Test]
        public void Test1()
        {
            var score = this.RuckPacker.GetScore();
            Assert.That(score, Is.EqualTo(7850));
            //Assert.That(score, Is.EqualTo(157));
        }

        [Test]
        public void Test2()
        {
            var score = this.RuckPacker.GetBadgeScore();
            Assert.That(score, Is.EqualTo(2581));
            //Assert.That(score, Is.EqualTo(70));
        }
    }
}