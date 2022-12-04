using NUnit.Framework;

namespace Day05Tests
{
    public class Tests
    {
        internal Worker Worker { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.Worker = new Worker();
        }

        [Test]
        public void SampleTest1()
        {
            this.Worker.LoadData("../../../../sample-data.txt");
            var result = this.Worker.GetAnswerWork(); 
            Assert.That(result, Is.EqualTo(42));
        }

        [Test]
        public void RealTest1()
        {
            this.Worker.LoadData("../../../../real-data.txt");
            var result = this.Worker.GetAnswerWork();
            Assert.That(result, Is.EqualTo(42));
        }

        [Test]
        public void SampleTest2()
        {
            this.Worker.LoadData("../../../../sample-data.txt");
            var result = this.Worker.GetAnswerWork2();
            Assert.That(result, Is.EqualTo(42));
        }

        [Test]
        public void RealTest2()
        {
            this.Worker.LoadData("../../../../real-data.txt");
            var result = this.Worker.GetAnswerWork();
            Assert.That(result, Is.EqualTo(42));
        }

    }
}