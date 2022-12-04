using NUnit.Framework;
using System.IO;

namespace Day12Tests
{
    public class Tests
    {
        internal PathFind PathFind { get; private set; }

        [SetUp]
        public void Setup()
        {
            var data = File.ReadAllText("../../../../sample-data.txt");
            this.PathFind = new PathFind(data);
        }

        [Test]
        public void Test1()
        {
            var countOfPaths = this.PathFind.CountPaths(); 
            //Assert.That(countOfPaths, Is.EqualTo(10));
            Assert.That(countOfPaths, Is.EqualTo(4912));
        }

        [Test]
        public void Test2()
        {
            var countOfPaths = this.PathFind.CountPaths2();
            //Assert.That(countOfPaths, Is.EqualTo(36));
            Assert.That(countOfPaths, Is.EqualTo(150004));
        }
    }
}