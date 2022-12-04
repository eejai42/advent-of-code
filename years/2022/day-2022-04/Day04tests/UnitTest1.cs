using NUnit.Framework;

namespace Day04tests
{
    public class Tests
    {
        internal Scheduler Scheduler { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.Scheduler = new Scheduler();
        }

        [Test]
        public void Test1()
        {
            this.Scheduler.LoadData("../../../../sample-data.txt");
            var redundantPairs = this.Scheduler.GetRedudantPairs();
            Assert.That(redundantPairs, Is.EqualTo(2));
        }


        [Test]
        public void Test2()
        {
            this.Scheduler.LoadData("../../../../puzzle1.txt");
            var redundantPairs = this.Scheduler.GetRedudantPairs();
            Assert.That(redundantPairs, Is.EqualTo(466));
        }


        [Test]
        public void Test3()
        {
            this.Scheduler.LoadData("../../../../puzzle1.txt");
            var redundantPairs = this.Scheduler.GetAnyRedudantPairs();
            Assert.That(redundantPairs, Is.EqualTo(865));
        }

    }
}